set MQADDR=192.168.92.129:5672
set MSG_IN=EnvoieMessage
set MSG_OUT=RetourMessage


start "EDI" "cmd /c MQDemo.exe %MSG_IN%:CRM.%MSG_IN% %MSG_OUT%:Client.%MSG_OUT% EDI:%MQADDR%"
start "CRM" "cmd /c MQDemo.exe %MSG_IN%:ERP.%MSG_IN% %MSG_OUT%:EDI.%MSG_OUT% CRM:%MQADDR%"
start "ERP" "cmd /c MQDemo.exe %MSG_IN%:MES.%MSG_IN% %MSG_OUT%:CRM.%MSG_OUT% ERP:%MQADDR%"
start "MES" "cmd /c MQDemo.exe %MSG_IN%:SIMUL.%MSG_IN% %MSG_OUT%:ERP.%MSG_OUT% MES:%MQADDR%"
start "SIMUL" "cmd /c MQDemo.exe %MSG_IN%:MES.%MSG_OUT% SIMUL:%MQADDR%"