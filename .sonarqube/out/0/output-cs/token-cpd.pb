¥
uC:\Users\Krystsina_Pulatava\Documents\rp-automation\rp-automation\Src\RP.Automation.Driver\Factories\ChromeFactory.cs
	namespace 	
RP
 
. 

Automation 
. 
Driver 
. 
	Factories (
{ 
public 

class 
ChromeFactory 
:  
IWebDriverFactory! 2
{ 
public		 
Type		 

DriverType		 
=>		 !
typeof		" (
(		( )
ChromeDriver		) 5
)		5 6
;		6 7
private

 
ChromeDriverService

 #
_service

$ ,
;

, -
public 
virtual 
bool 
IsMatch #
(# $
string$ *

driverName+ 5
)5 6
{ 	
return 

driverName 
? 
. 
Equals %
(% &
$str& .
,. /
StringComparison0 @
.@ A&
InvariantCultureIgnoreCaseA [
)[ \
??] _
false` e
;e f
} 	
public 

IWebDriver 
Create  
(  !
)! "
{ 	
_service 
= 
ChromeDriverService *
.* + 
CreateDefaultService+ ?
(? @
)@ A
;A B
var 
driver 
= 
new 
ChromeDriver )
() *
_service* 2
)2 3
;3 4$
WebDriverProcessRegistry $
.$ %
Current% ,
., -
Add- 0
(0 1
driver1 7
,7 8
_service9 A
.A B
	ProcessIdB K
)K L
;L M
return 
driver 
; 
} 	
public 
void 
Destroy 
( 

IWebDriver &
	webDriver' 0
)0 1
{ 	$
WebDriverProcessRegistry $
.$ %
Current% ,
., -
Remove- 3
(3 4
	webDriver4 =
,= >
_service? G
.G H
	ProcessIdH Q
)Q R
;R S
} 	
} 
} «
vC:\Users\Krystsina_Pulatava\Documents\rp-automation\rp-automation\Src\RP.Automation.Driver\Factories\FirefoxFactory.cs
	namespace 	
RP
 
. 

Automation 
. 
Driver 
. 
	Factories (
{ 
public 

class 
FirefoxFactory 
:  !
IWebDriverFactory" 3
{ 
public		 
Type		 

DriverType		 
=>		 !
typeof		" (
(		( )
FirefoxDriver		) 6
)		6 7
;		7 8
private

  
FirefoxDriverService

 $
_service

% -
;

- .
public 
virtual 
bool 
IsMatch #
(# $
string$ *

driverName+ 5
)5 6
{ 	
return 

driverName 
? 
. 
Equals %
(% &
$str& /
,/ 0
StringComparison1 A
.A B&
InvariantCultureIgnoreCaseB \
)\ ]
??^ `
falsea f
;f g
} 	
public 

IWebDriver 
Create  
(  !
)! "
{ 	
_service 
=  
FirefoxDriverService +
.+ , 
CreateDefaultService, @
(@ A
)A B
;B C
var 
driver 
= 
new 
FirefoxDriver *
(* +
_service+ 3
)3 4
;4 5$
WebDriverProcessRegistry $
.$ %
Current% ,
., -
Add- 0
(0 1
driver1 7
,7 8
_service9 A
.A B
	ProcessIdB K
)K L
;L M
return 
driver 
; 
} 	
public 
void 
Destroy 
( 

IWebDriver &
	webDriver' 0
)0 1
{ 	$
WebDriverProcessRegistry $
.$ %
Current% ,
., -
Remove- 3
(3 4
	webDriver4 =
,= >
_service? G
.G H
	ProcessIdH Q
)Q R
;R S
} 	
} 
} Ö
yC:\Users\Krystsina_Pulatava\Documents\rp-automation\rp-automation\Src\RP.Automation.Driver\Factories\IWebDriverFactory.cs
	namespace 	
RP
 
. 

Automation 
. 
Driver 
. 
	Factories (
{ 
public 

	interface 
IWebDriverFactory &
{ 
Type 

DriverType 
{ 
get 
; 
}  
bool

 
IsMatch

 
(

 
string

 

driverName

 &
)

& '
;

' (

IWebDriver 
Create 
( 
) 
; 
void 
Destroy 
( 

IWebDriver 
	webDriver  )
)) *
;* +
} 
} í
xC:\Users\Krystsina_Pulatava\Documents\rp-automation\rp-automation\Src\RP.Automation.Driver\Factories\WebDriverFactory.cs
	namespace 	
RP
 
. 

Automation 
. 
Driver 
. 
	Factories (
{ 
public 

static 
class 
WebDriverFactory (
{		 
private

 
static

 
readonly

 
IList

  %
<

% &
IWebDriverFactory

& 7
>

7 8
	Factories

9 B
=

C D
new 
List 
< 
IWebDriverFactory &
>& '
{ 
new 
ChromeFactory !
(! "
)" #
,# $
new 
FirefoxFactory "
(" #
)# $
} 
; 
public 
static 

IWebDriver  
Create! '
(' (
string( .

driverName/ 9
)9 :
{ 	
var 
factory 
= 
	Factories #
.# $
FirstOrDefault$ 2
(2 3
f3 4
=>5 7
f8 9
.9 :
IsMatch: A
(A B

driverNameB L
)L M
)M N
;N O
return 
factory 
. 
Create !
(! "
)" #
;# $
} 	
public 
static 
void 
TerminateWebDriver -
(- .

IWebDriver. 8
	webDriver9 B
)B C
{ 	
var 
factory 
= 
	Factories #
.# $
FirstOrDefault$ 2
(2 3
f3 4
=>5 7
f8 9
.9 :

DriverType: D
==E G
	webDriverH Q
.Q R
GetTypeR Y
(Y Z
)Z [
)[ \
;\ ]
try 
{ 
	webDriver 
. 
Quit 
( 
)  
;  !
	webDriver 
. 
Dispose !
(! "
)" #
;# $
} 
catch 
( 
	Exception 
) 
{   
factory!! 
.!! 
Destroy!! 
(!!  
	webDriver!!  )
)!!) *
;!!* +
}"" 
}## 	
}$$ 
}%% ›
€C:\Users\Krystsina_Pulatava\Documents\rp-automation\rp-automation\Src\RP.Automation.Driver\Factories\WebDriverProcessRegistry.cs
	namespace 	
RP
 
. 

Automation 
. 
Driver 
. 
	Factories (
{ 
internal 
class $
WebDriverProcessRegistry +
{		 
private

 $
WebDriverProcessRegistry

 (
(

( )
)

) *
{ 	
DriverProcesses 
= 
new ! 
ConcurrentDictionary" 6
<6 7

IWebDriver7 A
,A B
intC F
>F G
(G H
)H I
;I J
} 	
private  
ConcurrentDictionary $
<$ %

IWebDriver% /
,/ 0
int1 4
>4 5
DriverProcesses6 E
{F G
getH K
;K L
}M N
public 
static $
WebDriverProcessRegistry .
Current/ 6
=>7 9
new: =$
WebDriverProcessRegistry> V
(V W
)W X
;X Y
public 
void 
Add 
( 

IWebDriver "
	webDriver# ,
,, -
int. 1
	processId2 ;
); <
{ 	
DriverProcesses 
. 
TryAdd "
(" #
	webDriver# ,
,, -
	processId. 7
)7 8
;8 9
} 	
public 
void 
Remove 
( 

IWebDriver %
	webDriver& /
,/ 0
int1 4
	processId5 >
)> ?
{ 	
if 
( 
! 
DriverProcesses  
.  !
	TryRemove! *
(* +
	webDriver+ 4
,4 5
out6 9
var: =
webDriverInfo> K
)K L
)L M
returnN T
;T U
ManageExecution 
( 
( 
) 
=> !
{ 
var 
process 
= 
Process %
.% &
GetProcessById& 4
(4 5
	processId5 >
)> ?
;? @
process 
. 
Kill 
( 
) 
; 
} 
) 
; 
}   	
private"" 
static"" 
void"" 
ManageExecution"" +
(""+ ,
Action"", 2
action""3 9
)""9 :
{## 	
action$$ 
?$$ 
.$$ 
Invoke$$ 
($$ 
)$$ 
;$$ 
}%% 	
}&& 
}'' 