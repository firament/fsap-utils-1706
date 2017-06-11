using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.IO;
using NLog;

namespace fsap.EntityMetadataClassGen
{

	public enum ReturnStatus	// Value maps directly to return status
	{
		OK = 0,
		FILE_EXISTS = 1,
		SRC_ROOT_NO_ACCESS = 2,
		DEST_DIR_NO_ACCESS = 3,
		TEMPLATE_MISSING = 4,
		TEMPLATE_FORMAT_BAD = 5,
		SRC_FILE_NO_ACCESS = 6,
		SRC_FILE_READ_ERR = 7,
		SRC_FILE_PROCESS_ERR = 8,
		SOURCE_DATA_ERR = 9,
		DEST_FILE_WRITE_ERR = 10,
		UNKNOWN = 99
	}

	public class InputData : IDisposable
	{
		public string SourceRootFolder				{ get; set; }
		public string DestinationFolder				{ get; set; }
		public string AnnotationNameSpaceSegment	{ get; set; } = @"Annotations";
		public string MetaDataClassSuffix			{ get; set; } = @"_Metadata";
		public string MetaDataFileTemplate			{ get; set; } = @"MDTemplate.txt";
		public string PropertyPadLeft				{ get; set; } = @"    ";
		public InputData(){}
		public void Dispose(){/* Nothing to be done*/}
	}

	class MDGenerator
	{
		static NLog.Logger log = NLog.LogManager.GetCurrentClassLogger();

		private const string MC_KEY_NSPACE		= @"namespace ";
		private const string MC_KEY_CLASS		= @"    public partial class ";
		private const string MC_KEY_PROP		= @"        public ";
		private const string MC_DEF_TEMPLATE	= @"MDTemplate.txt";

		public MDGenerator(){}

		public static int? Generate(InputData poInput)
		{
			// Validation
			// input readable
			// output writable

			// log.Debug("START public static int? Generate(InputData poInput)");

			int liRetVal = -1;
			string lsTemplateFile = string.Empty;
			string lsText = string.Empty;
			InputDataEx loInput = new InputDataEx(poInput);

			// Write out output recieved
			log.Info("Using INPUT DATA: _________  ");
			log.Info("          SourceRootFolder = '" + loInput.SourceRootFolder			+ "'");
			log.Info("         DestinationFolder = '" + loInput.DestinationFolder			+ "'");
			log.Info("       MetaDataClassSuffix = '" + loInput.MetaDataClassSuffix			+ "'");
			log.Info("AnnotationNameSpaceSegment = '" + loInput.AnnotationNameSpaceSegment	+ "'");
			log.Info("      MetaDataFileTemplate = '" + loInput.MetaDataFileTemplate		+ "'");
			log.Info("           PropertyPadLeft = '" + loInput.PropertyPadLeft				+ "'");

			log.Info("           DestinationRoot = '" + loInput.DestinationRoot				+ "'");
			log.Info("              NameSpaceTag = '" + loInput.NameSpaceTag				+ "'");
			log.Info("       NameSpaceAnnnoteTag = '" + loInput.NameSpaceAnnnoteTag			+ "'");
			log.Info("              ClassNameTag = '" + loInput.ClassNameTag				+ "'");
			log.Info("           MetaClassSfxTag = '" + loInput.MetaClassSfxTag				+ "'");
			log.Info("                   BodyTag = '" + loInput.BodyTag						+ "'");
			log.Info("");

			if (string.IsNullOrWhiteSpace(loInput.MetaDataFileTemplate))
			{
				lsTemplateFile = MC_DEF_TEMPLATE;
			}
			else if (File.Exists(loInput.MetaDataFileTemplate))
			{
				lsTemplateFile = loInput.MetaDataFileTemplate;
			}

			// If it is filename, get the contents
			if (!string.IsNullOrWhiteSpace(lsTemplateFile))
			{
				try
				{
					lsText = File.ReadAllText(lsTemplateFile);
					if (!string.IsNullOrWhiteSpace(lsText))
					{
						loInput.MetaDataFileTemplate = lsText;
					}
					else
					{
						liRetVal = (int)ReturnStatus.TEMPLATE_MISSING;
					}
				}
				catch (Exception Ex)
				{
					log.Error("Unable to get Template");
					liRetVal = (int)ReturnStatus.TEMPLATE_MISSING;
				}
			}

			// Check if all tags exist in the template
			lsText = loInput.MetaDataFileTemplate;
			if (
				   (liRetVal <= 0)
				&& (lsText.Contains(loInput.NameSpaceTag))
				&& (lsText.Contains(loInput.NameSpaceAnnnoteTag))
				&& (lsText.Contains(loInput.ClassNameTag))
				&& (lsText.Contains(loInput.MetaClassSfxTag))
				&& (lsText.Contains(loInput.BodyTag))
				)
			{
				// TAGS ARE GOOD
			}
			else
			{
				log.Error("TEMPLATE DATA IS UNUSABLE");
				liRetVal = (int)ReturnStatus.TEMPLATE_FORMAT_BAD;
			}


			if (liRetVal > 0)
			{
				return liRetVal;
			}

			
			// All GOOD, process now
			DateTime ldtStart = DateTime.Now, ldtFinish;    // Report processing time
			ExecuteStatus ES = ProcessFolder(loInput);
			ldtFinish = DateTime.Now;
			liRetVal = (int)ES.ExitStatus;

			// Write out summary
			log.Info("Processing Summary:");
			log.Info("Files Total : " + ES.FilesTotal);
			log.Info("in Folders  : " + ES.FoldersTotal);
			log.Info("Processed   : " + ES.FilesGenerated);
			log.Info("Started at  : " + ldtStart.ToString("HH:mm:ss.ffff"));
			log.Info("Finished at : " + ldtFinish.ToString("HH:mm:ss.ffff"));
			log.Info("Took (mS)   : " + ldtFinish.Subtract(ldtStart).TotalMilliseconds);


			return liRetVal;
		}

		private static ExecuteStatus ProcessFolder(InputDataEx poInput)
		{
			ExecuteStatus voES, loES = new ExecuteStatus() { FoldersTotal = 1 };

			log.Info(KEYS.FOLDER_NAME_LOG, poInput.SourceRootFolder);

			// Process all CS files
			foreach (string vsFilePath in Directory.EnumerateFiles(poInput.SourceRootFolder, "*.cs"))
			{
				voES = ProcessFile(poInput, Path.GetFileName(vsFilePath));	// Pass only file name, need to getit again later
				loES.FilesTotal++;
				if (voES.ExitStatus == ReturnStatus.OK)
				{
					loES.FilesGenerated += voES.FilesGenerated;
				} else
				{
					// add message to list
					loES.Messages.AppendLine(voES.Message);
					loES.Messages.AppendLine(voES.Messages.ToString());
				}
			}   // foreach (string vsFilePath in Dir

			// Process all Subfolders
			string lsDestFolder = poInput.DestinationFolder;	// Remember stsrting folder, to POP
			foreach (string vSubDir in Directory.EnumerateDirectories(poInput.SourceRootFolder))
			{
				// if same as target dir, skip
				if (vSubDir == poInput.DestinationRoot)
				{
					log.Info(KEYS.SKIP_DESTINATION, vSubDir);
					loES.Messages.AppendFormat(KEYS.SKIP_DESTINATION, vSubDir);
					loES.Messages.AppendLine();
					continue;
				}

				// PUSH the subfolder
				poInput.SourceRootFolder = vSubDir;
				poInput.DestinationFolder = Path.Combine(lsDestFolder, Path.GetFileName(vSubDir));

				// Call ourself, treating this as root
				voES = ProcessFolder(poInput);
				if (voES.ExitStatus == ReturnStatus.OK)
				{
					// Update counts for the report
					loES.FilesTotal += voES.FilesTotal;
					loES.FoldersTotal += voES.FoldersTotal;
					loES.FilesGenerated += voES.FilesGenerated;
				}
				else
				{
					// add messages to list. See if Enumeration is needed
					loES.Messages.AppendLine(voES.Messages.ToString());
				}

			}   // foreach (string vSubDir in Dir

			loES.ExitStatus = ReturnStatus.OK;
			return loES;
		}

		private static ExecuteStatus ProcessFile(InputDataEx poInput, string psSourceFileName)
		{
			bool lbHasError = false;
			ExecuteStatus ES = new ExecuteStatus();

			string lsEntityNameSpace = null;
			string lsEntityClassName = null;
			string lsEntityBody		 = null;

			string lsAllLines = string.Empty;
			string lsText;
			int lsIndex = 0, lsLinesDone = 0;
			StringBuilder lsbProps = new StringBuilder();

			log.Info(KEYS.FILE_NAME_LOG, psSourceFileName, poInput.SourceRootFolder);

			// Check if file exists, we dont want to overwrite customized code
			if (File.Exists(Path.Combine(poInput.DestinationFolder, psSourceFileName)))
			{
				log.Debug("\tFile Exist in destination, Not processing.");
				ES.ExitStatus = ReturnStatus.FILE_EXISTS;
				ES.Message = psSourceFileName;
				ES.Messages.AppendLine("File Exists, skipping. " + psSourceFileName);
				return ES;
			}

			try
			{
				foreach (string lsLine in File.ReadAllLines(Path.Combine(poInput.SourceRootFolder, psSourceFileName)))
				{
					lbHasError = false; // reset for each loop, we dont want carry-overs
					lsLinesDone++;

					if (lsLine.StartsWith(MC_KEY_NSPACE))
					{
						lsText = lsLine.Split(' ')[1] ?? string.Empty;   // drop any comments after namespace
						lbHasError = string.IsNullOrWhiteSpace(lsText);
						if (lbHasError)
						{
							// create error note and exit
						} else
						{
							lsEntityNameSpace = lsText.Trim();
							log.Debug("lsEntityNameSpace = {0}", lsEntityNameSpace);
						}
					}
					else if (lsLine.StartsWith(MC_KEY_CLASS))
					{
						lsIndex = 0;
						lsText = lsLine.Remove(0, MC_KEY_CLASS.Length);
						lbHasError = string.IsNullOrWhiteSpace(lsText);
						if (lbHasError)
						{
							// create error note and exit
						}
						else
						{
							lsIndex = lsText.IndexOf(" ");
							if (lsIndex > 0)
							{
								lsText = lsText.Substring(0, lsIndex);
							}
							lsEntityClassName = lsText.Trim();
							log.Debug("lsEntityClassName = {0}", lsEntityClassName);
						}
					}
					else if (lsLine.StartsWith(MC_KEY_PROP) && lsLine.Contains("{"))	// Quick fix, identify constructor properly
					{
						lsbProps.AppendLine();	// need an blank line above to add annotations
						lsbProps.AppendLine(poInput.PropertyPadLeft + lsLine);
						log.Debug("lsLine (Property) = {0}", lsLine);
					}

					if (lbHasError)
					{
						// process errors for caller to get
						log.Error(lsLine);
						ES.Messages.AppendLine("Error Processing line");
						ES.Messages.AppendLine(lsLine);
						ES.Messages.AppendLine("of File > " + psSourceFileName);
						//break;	// analyze errors to see if any code fix needed
						continue;
					}
				}   // foreach (string lsLine in 

				log.Info("Lines Processed = {0}", lsLinesDone);
				lsEntityBody = lsbProps.ToString();

			}
			catch (Exception Ex)
			{
				log.Error(Ex, psSourceFileName);
				ES.ExitStatus = ReturnStatus.SRC_FILE_PROCESS_ERR;
				ES.Message = psSourceFileName;
			}

			// Verify all tags have data

			if (
				   string.IsNullOrWhiteSpace(lsEntityNameSpace)
				|| string.IsNullOrWhiteSpace(lsEntityClassName)
				|| string.IsNullOrWhiteSpace(lsEntityBody)
				)
			{
				log.Error(KEYS.DATA_MISSING);
				log.Error("lsEntityNameSpace = {0}", lsEntityNameSpace);
				log.Error("lsEntityClassName = {0}", lsEntityClassName);
				log.Error("lsEntityBody      = \n{0}", lsEntityBody);
				ES.ExitStatus = ReturnStatus.SOURCE_DATA_ERR;
				ES.Message = psSourceFileName;
				return ES;
			}

			//log.Debug("Replacing placeholders in template");
			//log.Debug("{0} -> {1}", poInput.NameSpaceTag, lsEntityNameSpace);
			//log.Debug("{0} -> {1}", poInput.NameSpaceAnnnoteTag, poInput.AnnotationNameSpaceSegment);
			//log.Debug("{0} -> {1}", poInput.ClassNameTag, lsEntityClassName);
			//log.Debug("{0} -> {1}", poInput.MetaClassSfxTag, poInput.MetaDataClassSuffix);
			//// log.Debug("{0} -> {1}", poInput.BodyTag, lsEntityBody);
			// log.Debug("INSPECT OUTPUT FOR CORRECTNESS");

			// Process the template
			lsEntityBody = poInput.MetaDataFileTemplate
				.Replace(poInput.NameSpaceTag, lsEntityNameSpace)
				.Replace(poInput.NameSpaceAnnnoteTag, poInput.AnnotationNameSpaceSegment)
				.Replace(poInput.ClassNameTag, lsEntityClassName)
				.Replace(poInput.MetaClassSfxTag, poInput.MetaDataClassSuffix)
				.Replace(poInput.BodyTag, lsEntityBody)
				;

			// Does destination exist? Create if needed,
			// do check just before write to avoid creating empty folders
			if (!Directory.Exists(poInput.DestinationFolder))
			{
				DirectoryInfo vNewDir = null;
				try
				{
					vNewDir = Directory.CreateDirectory(poInput.DestinationFolder);
				}
				catch (Exception eX)
				{
					// log the error
				}
				// Check Again, to see if it is created
				if (!Directory.Exists(poInput.DestinationFolder))
				{
					log.Error(KEYS.DEST_FOLDER_NOACCESS, poInput.DestinationFolder);
					ES.ExitStatus = ReturnStatus.DEST_DIR_NO_ACCESS;
					ES.Message = poInput.DestinationFolder;
					return ES;
				}
			}   // if (!Directory.Exists(poInput.DestinationFolder))

			try
			{
				File.WriteAllText(Path.Combine(poInput.DestinationFolder, psSourceFileName), lsEntityBody);
				ES.FilesGenerated++;
				ES.ExitStatus = ReturnStatus.OK;
			}
			catch (Exception Ex)
			{
				log.Error(Ex, psSourceFileName);
				ES.ExitStatus = ReturnStatus.DEST_FILE_WRITE_ERR;
				ES.Message = psSourceFileName;
			}

			return ES;
		}

		/**********************************************************************************************************/
		/* HELPER FUNCTIONS
		/**********************************************************************************************************/

		/*
		 * 
		 * PRIVATE CLASSES FOR FUNCTIONALITY
		 * 
		 */


		private class KEYS
		{
			//			log.Debug("[ FOLDER ]" + lsText);

			public const string FOLDER_NAME_LOG = @"[ FOLDER ] {0}";
			public const string FILE_NAME_LOG   = @"[   FILE ] {0} in {1}";
			public const string DEST_FOLDER_NOACCESS = @"Unable to Create Destination Folder '{0}'";
			public const string DATA_MISSING = @"Data for all tags is not availaible, aborting.";
			public const string SKIP_DESTINATION = @"[Not Processing] Destination Folder '{0}'";
			public const string D = @"";
			public const string E = @"";
			public const string F = @"";
			public const string G = @"";
			public const string H = @"";
			public const string I = @"";
		}

		private class InputDataEx : InputData
		{
			public string DestinationRoot { get; set; }

			public string NameSpaceTag { get; set; }		= @"${ENTITY_NAME_SPACE}";
			public string NameSpaceAnnnoteTag { get; set; }	= @"${ANNOTATION_NAME_SPACE}";
			public string ClassNameTag { get; set; }		= @"${ENTITY_CLASS_NAME}";
			public string MetaClassSfxTag { get; set; }		= @"${METADATA_CLASS_SUFFIX}";
			public string BodyTag { get; set; }				= @"${ENTITY_BODY}";

			public InputDataEx(){}
			public InputDataEx(InputData pIData) {
				SourceRootFolder			= pIData.SourceRootFolder;
				DestinationFolder			= pIData.DestinationFolder;
				DestinationRoot				= pIData.DestinationFolder;
				AnnotationNameSpaceSegment	= pIData.AnnotationNameSpaceSegment;
				MetaDataClassSuffix			= pIData.MetaDataClassSuffix;
				MetaDataFileTemplate		= pIData.MetaDataFileTemplate;
				PropertyPadLeft				= pIData.PropertyPadLeft;
			}
		}

		private class ExecuteStatus : IDisposable
		{
			public ReturnStatus ExitStatus { get; set; } = ReturnStatus.UNKNOWN;
			public int ExceptionCount { get; set; } = 0;
			public string Message { get; set; }
			public StringBuilder Messages { get; set; } = new StringBuilder();
			public string ExceptionData { get; set; }

			// For summary reporting
			public int FilesTotal { get; set; } = 0;
			public int FoldersTotal { get; set; } = 0;
			public int FilesGenerated { get; set; } = 0;

			public ExecuteStatus():base(){}
			public void Dispose() {/* Nothing to be done*/}
		}

		
	}

}
