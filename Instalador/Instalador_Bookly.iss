; Script de Inno Setup para Bookly - Sistema de Gestion Bibliografica
; Autora: Sofia Gesualdo Antonini (UAI - Trabajo de Diploma 2026)

#define MyAppName "Bookly - Libros que te acompañan"
#define MyAppVersion "2.0"
#define MyAppPublisher "Sofia Gesualdo Antonini"
#define MyAppExeName "Venta y Préstamo de Libros.exe"

[Setup]
AppId={{B00C1984-7F89-4D65-8E92-E7A4A2B99C42}}
AppName={#MyAppName}
AppVersion={#MyAppVersion}
AppPublisher={#MyAppPublisher}
DefaultDirName={autopf}\Bookly
DefaultGroupName=Bookly
OutputDir=.\Salida
OutputBaseFilename=Setup_Bookly_v2.0
Compression=lzma2/max
SolidCompression=yes
WizardStyle=modern
UsePreviousAppDir=yes
DisableProgramGroupPage=yes
ArchitecturesInstallIn64BitMode=x64compatible
PrivilegesRequired=admin

[Languages]
Name: "spanish"; MessagesFile: "compiler:Languages\Spanish.isl"

[Tasks]
Name: "desktopicon"; Description: "{cm:CreateDesktopIcon}"; GroupDescription: "{cm:AdditionalIcons}"

[Files]
; Archivos binarios compilados de la aplicacion
Source: "..\Venta Productos Cosméticos\bin\Debug\net8.0-windows\*"; DestDir: "{app}"; Flags: ignoreversion recursesubdirs createallsubdirs
; Manual de usuario
Source: "..\ManualDeUsuario.pdf"; DestDir: "{app}"; Flags: ignoreversion
; Scripts para instalacion limpia de base de datos
Source: "Instalacion_Limpia_EverGlow.sql"; DestDir: "{app}\Database"; Flags: ignoreversion
Source: "Ejecutar_Script_BD.bat"; DestDir: "{app}\Database"; Flags: ignoreversion

[Icons]
Name: "{group}\{#MyAppName}"; Filename: "{app}\{#MyAppExeName}"
Name: "{group}\Manual de Usuario"; Filename: "{app}\ManualDeUsuario.pdf"
Name: "{group}\{cm:UninstallProgram,{#MyAppName}}"; Filename: "{uninstallexe}"
Name: "{autodesktop}\{#MyAppName}"; Filename: "{app}\{#MyAppExeName}"; Tasks: desktopicon

[Run]
Filename: "{app}\{#MyAppExeName}"; Description: "{cm:LaunchProgram,{#StringChange(MyAppName, '&', '&&')}}"; Flags: nowait postinstall skipifsilent

[Code]
var
  PageModoInstalacion: TInputOptionWizardPage;

procedure InitializeWizard;
begin
  PageModoInstalacion := CreateInputOptionPage(
    wpSelectDir,
    'Tipo de Instalación del Sistema',
    'Seleccione la modalidad de despliegue correspondiente:',
    'Por favor elija si desea realizar una instalación inicial de cero o una reinstalación/actualización sobre un entorno previo.',
    True, False);

  PageModoInstalacion.Add('Instalación Inicial de Cero (Crea la base de datos limpia EverGlow y usuario administrador inicial)');
  PageModoInstalacion.Add('Reinstalación / Actualización (Conserva la base de datos existente intacta sin sobrescribirla)');

  PageModoInstalacion.SelectedValueIndex := 0;
end;

procedure CurPageChanged(CurPageID: Integer);
begin
  if CurPageID = PageModoInstalacion.ID then
  begin
    if DirExists(WizardDirValue) then
      PageModoInstalacion.SelectedValueIndex := 1
    else
      PageModoInstalacion.SelectedValueIndex := 0;
  end;
end;

function NextButtonClick(CurPageID: Integer): Boolean;
begin
  Result := True;

  if CurPageID = PageModoInstalacion.ID then
  begin
    if PageModoInstalacion.SelectedValueIndex = 1 then
    begin
      MsgBox('MODO REINSTALACIÓN SELECCIONADO:' + #13#10#13#10 +
             'Se conservará la base de datos existente (EverGlow) con todos sus registros intactos.' + #13#10#13#10 +
             'RECOMENDACIÓN: Por precaución operativa, asegúrese de haber generado una copia de seguridad (Backup) de la base de datos antes de continuar.',
             mbInformation, MB_OK);
    end
    else
    begin
      if MsgBox('MODO INSTALACIÓN DE CERO:' + #13#10#13#10 +
                'Esta opción ejecutará el script para inicializar la base de datos EverGlow con el catálogo base y el usuario administrador inicial.' + #13#10#13#10 +
                '¿Desea continuar?', mbConfirmation, MB_YESNO) = IDNO then
      begin
        Result := False;
      end;
    end;
  end;
end;

procedure CurStepChanged(CurStep: TSetupStep);
var
  ResultCode: Integer;
  BatPath: string;
begin
  if CurStep = ssPostInstall then
  begin
    // Solo si el usuario eligio Instalacion Inicial de Cero ejecutamos el script SQL
    if PageModoInstalacion.SelectedValueIndex = 0 then
    begin
      BatPath := ExpandConstant('{app}\Database\Ejecutar_Script_BD.bat');
      if FileExists(BatPath) then
      begin
        Exec(BatPath, '', ExpandConstant('{app}\Database'), SW_HIDE, ewWaitUntilTerminated, ResultCode);
      end;
    end;
  end;
end;
