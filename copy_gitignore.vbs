'###################################################################
'######
'######
'###### THIS SCRIPT IS CREATED FOR COPY GITIGNORE FILE FOR ALL SUBDIRECTORY
'######
'######
'###################################################################

'########################################
'##########    SHELL OBJECTS     ########
'########################################
' create shell object
set wshShell = CreateObject( "WScript.Shell" )

set objFSO = CreateObject("Scripting.FileSystemObject")

'########################################
'##########     CONSTANTS      ##########
'########################################
const FILE_GITIGNORE_NAME = ".gitignore"


'########################################
'##########     FUNCTIONS      ##########
'########################################
dim CurrentDirectory
ProceedArguments()
CopyGitignoreToSubfolders()

function ProceedArguments()
	set ObjArg = WScript.Arguments
	
	if ObjArg.Length < 1 then
		WScript.echo "Error, enter current directory path, please!"
		wscript.quit 1
	end if
	
	CurrentDirectory = ObjArg(0)
end function 

function CopyGitignoreToSubfolders()
	set objFolder = objFSO.GetFolder(CurrentDirectory)

	Set colFiles = objFolder.SubFolders
	For Each objFile in colFiles
		wscript.echo objFile
		If (objFSO.FileExists(filespec)) then
			wscript.echo "file exist"
			cmdLine = "copy " & FILE_GITIGNORE_NAME & " """ & objFile & """"
			wshShell.Exec(  cmdLine  )
		else
			wscript.echo "file not exist"
		end if	
	Next
end function






