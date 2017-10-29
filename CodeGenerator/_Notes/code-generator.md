# Code Generator

- Console (or IU) to generate code strings, using GUUID as seed
- Code generated will contain
	- Segments, seperated by `-`
	-

## Inputs

|  S# | Parameter         | Type   | Description                                           | User Specified |
| ---:|:----------------- |:------ |:----------------------------------------------------- | -------------- |
|     | Segment Size      | Number | Number of characters per segment                      |                |
|     | Segment Seperator | String | String to use for seperating segments. Default is `-` |                |
|     | Segments per Code | Number | Number of segments per code string                    |                |
|     | Iterations        | Number | Number of iterations to run in the batch              |                |

## Calculation - Code count per iteration

- (Segment Size * Segment Count) <= 32
- Divide 32 by (Segment Size * Segment Count) till Remainder is zero
  - Repeat by multiplying 32 by integer until reminder is zero
