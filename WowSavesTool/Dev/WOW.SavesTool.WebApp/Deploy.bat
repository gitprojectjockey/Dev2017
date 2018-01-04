@ECHO OFF
setlocal enabledelayedexpansion
SET source.dir=%~dp0

SET dev.servers=il-svr-dv11 il-svr-dv12
SET test.servers=il-svr-dv11 il-svr-dv12
SET prod.servers=il-svr-ws11 il-svr-ws12

SET dev.app.path=\e$\Websites\apptoolstest\GuiOverlayDev
SET test.app.path=\e$\Websites\apptoolstest\GuiOverlayQA
SET prod.app.path=\e$\Websites\apptools\GuiOverlay

SET /p env=Please enter environment (DEV/TEST/PROD):

if {%env%}=={PROD} (
  SET servers=%prod.servers%
  SET app.path=%prod.app.path%
  ECHO Will run deploy for PROD environment on servers: !servers! from !source.dir!
) else if {%env%}=={TEST} (
  SET servers=%test.servers%
  SET app.path=%test.app.path%
  ECHO Will run deploy for TEST environment on servers: !servers! from !source.dir!
) else if {%env%}=={DEV} (
  SET servers=%dev.servers%
  SET app.path=%dev.app.path%
  ECHO Will run deploy for DEV environment on servers: !servers! from !source.dir!
) else (
  ECHO Invalid entry - environment must be DEV/TEST/PROD. Batch will now exit.
  PAUSE
  EXIT
)

PAUSE

if {1} == {%time:~0,1%} (
  SET Z=%time:~0,1%
) else if {2} == {%time:~0,1%} (
  SET Z=%time:~0,1%
) else (
  SET Z=0
)

SET deploy.hour=%Z%%time:~1,1%

for %%b in (%servers%) do (
  ECHO Creating a backup of server/endpoint: %%b%app.path%

  robocopy \\%%b%app.path% \\%%b%app.path%\backups\%date:~10,4%%date:~4,2%%date:~7,2%.%deploy.hour%%time:~3,2%%time:~6,2% /MIR /XF deploy.bat /XD logs backups /MT
)

for %%e in (%servers%) do (
  ECHO Taking offline server/endpoint: %%e%app.path% 
 
)

for %%s in (%servers%) do (
  ECHO Deploying to server/endpoint: %%s%app.path%

  robocopy %source.dir% \\%%s%app.path% /MIR /XF app_offline.htm deploy.bat deployment_log.log /XD logs backups /MT >> \\%%s%app.path%\backups\deployment_log.log
   
)

PAUSE


