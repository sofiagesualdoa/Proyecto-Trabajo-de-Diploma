import os
import shutil
import zipfile

def main():
    base_dir = r'c:\Users\usuario\OneDrive\Facultad\3° Año\2° Cuatrimestre\Trabajo de Diploma\Carpeta\Proyecto-Trabajo-de-Diploma'
    zip_path = os.path.join(base_dir, 'Proyecto.zip')
    backup_path = os.path.join(base_dir, 'Proyecto_backup.zip')
    fixed_docx = os.path.join(base_dir, 'scratch', 'Proyecto_fixed.docx')

    # Backup original zip if not already backed up
    if not os.path.exists(backup_path):
        print(f"Creating backup at {backup_path}...")
        shutil.copy2(zip_path, backup_path)
    else:
        print(f"Backup already exists at {backup_path}")

    # Write new Proyecto.zip containing Proyecto.docx
    temp_zip = os.path.join(base_dir, 'Proyecto_temp.zip')
    print("Writing new zip archive...")
    with zipfile.ZipFile(temp_zip, 'w', compression=zipfile.ZIP_DEFLATED) as z:
        z.write(fixed_docx, arcname='Proyecto.docx')

    # Replace original zip
    shutil.move(temp_zip, zip_path)
    print(f"Updated {zip_path} successfully!")

    # Verify zip content
    with zipfile.ZipFile(zip_path, 'r') as z:
        for info in z.infolist():
            print(f"Verified in zip: {info.filename} ({info.file_size} bytes)")

if __name__ == '__main__':
    main()
