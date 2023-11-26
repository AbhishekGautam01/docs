# Encoding 

## base64 encoding 
* This is a binary to text encoding scheme. 
* when we send data over internet, it gets encoded during with some characters may get lost. 
* It takes binary data and converts it into base64 text string. 
### how base64 works? 
* All data is stored in binaries
* 1 Byte = 8 bits 
* base64 doesnt care about your data, as it takes just the binary form of your data.
* It divides the binary in group of 6. 
* If we can 6 places where each place can have 0, 1 so all together can contain 2^6 = 64 combination of possible binary string
* It creates a table of all 64 previous values mapped to an alphabet like 000000 = a, 000001 = b 
* It supports A-Z, a-z, 0-9, +, / 
* Our computer then take each char one by one and get back the binary. 
* The size would always be greater than your input string. as all computers normally store char atleast 1 Byte = 8 bits , so base64 tries to encode 8 bit of data in 6 bits of information. 
* The increase if roughly 33% which comes from (8/6) X Size of data. 