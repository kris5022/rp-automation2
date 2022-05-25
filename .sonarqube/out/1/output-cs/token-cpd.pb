è
iC:\Users\Krystsina_Pulatava\Documents\rp-automation\rp-automation\Src\RP.Automation.Core\ConfigManager.cs
	namespace 	
RP
 
. 

Automation 
. 
Core 
{ 
public 

class 
ConfigManager 
{ 
private		 
readonly		 
Lazy		 
<		 
IConfiguration		 ,
>		, -
_configuration		. <
;		< =
private

 
readonly

 
string

 
_configurationFile

  2
;

2 3
public 
ConfigManager 
( 
string #
configurationFile$ 5
)5 6
{ 	
_configurationFile 
=  
configurationFile! 2
;2 3
_configuration 
= 
new  
Lazy! %
<% &
IConfiguration& 4
>4 5
(5 6
GetConfiguration6 F
)F G
;G H
} 	
public 
IConfiguration 
Configuration +
=>, .
_configuration/ =
.= >
Value> C
;C D
private 
IConfiguration 
GetConfiguration /
(/ 0
)0 1
{ 	
var  
configurationBuilder $
=% &
new' * 
ConfigurationBuilder+ ?
(? @
)@ A
;A B
var 
directoryName 
= 
Path  $
.$ %
GetDirectoryName% 5
(5 6
typeof6 <
(< =
ConfigManager= J
)J K
.K L
AssemblyL T
.T U
LocationU ]
)] ^
;^ _ 
configurationBuilder  
.  !
AddJsonFile! ,
(, -
Path- 1
.1 2
Combine2 9
(9 :
directoryName 
??  
throw! &
new' *%
InvalidOperationException+ D
(D E
$strE d
)d e
,e f
_configurationFile "
)" #
)# $
;$ %
return  
configurationBuilder '
.' (
Build( -
(- .
). /
;/ 0
} 	
} 
} û
pC:\Users\Krystsina_Pulatava\Documents\rp-automation\rp-automation\Src\RP.Automation.Core\Utilities\Randomizer.cs
	namespace 	
RP
 
. 

Automation 
. 
Core 
. 
	Utilities &
{ 
public 

static 
class 

Randomizer "
{ 
readonly 
static 
Random 
random %
=& '
new( +
Random, 2
(2 3
)3 4
;4 5
public		 
static		 
int		 
RandomDigits		 &
(		& '
)		' (
{

 	
return 
random 
. 
Next 
( 
$num &
,& '
$num( /
)/ 0
;0 1
} 	
} 
} 