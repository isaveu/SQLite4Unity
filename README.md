# SQLite4Unity
SQLite3 for unity


Mono.Data.Sqlite.dll
System.Data.dll you can find from "Unity\Editor\Data\MonoBleedingEdge\lib\mono\2.0"

sqlite3.dll download from http://www.sqlite.org/download.html

test.db size=32.8M, load time=0.0401926s

table vs:

     Table 	  |  Size  | Record Number | Search Time
--------------|--------|---------------|------------
Phone 		  |  16.2M |    300105     |  0.04498291s 
identitycard  |  264KB |     6336      |  0.00073242s


read vs:

read method |  Size  | Record Number| Load Time |Search Time
------------|--------|--------------|-----------|------------
SQLite3	    | 16.2M  |	300105		| 0.0401926s|0.04498291s
StreamReader| 16.2M  |	300105		| 1.906061s	|0.09459782s


![](https://github.com/tomtc123/GitHub-Resources/blob/master/SQLite4Unity/20160807214131.png)
