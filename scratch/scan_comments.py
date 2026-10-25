import os
import re

projects = ['BE', 'BLL', 'DAL', 'Servicios', 'Venta Productos Cosméticos']
matches = []

for proj in projects:
    for root, dirs, files in os.walk(proj):
        if 'bin' in dirs: dirs.remove('bin')
        if 'obj' in dirs: dirs.remove('obj')
        if '.vs' in dirs: dirs.remove('.vs')
        for f in files:
            if f.endswith('.cs') and not f.endswith('.Designer.cs'):
                fpath = os.path.join(root, f)
                with open(fpath, 'r', encoding='utf-8', errors='ignore') as fp:
                    lines = fp.readlines()
                for num, line in enumerate(lines, 1):
                    code_no_strings = re.sub(r'"(?:\\.|[^"\\])*"', '""', line)
                    if '//' in code_no_strings or '/*' in code_no_strings or '*/' in code_no_strings:
                        matches.append((fpath, num, line.strip()))

print(f'Total matches: {len(matches)}')
for m in matches:
    print(f'{m[0]}:{m[1]}: {m[2]}')
