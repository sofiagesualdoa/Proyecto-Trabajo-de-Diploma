with open(r'BLL\BLLFactura.cs', 'r', encoding='utf-8') as f_in:
    content = f_in.read()

target = '                Paragraph subtitulo = new Paragraph("FACTURA ELECTRÓNICA OFICIAL DE VENTA\\n\\n", fuenteSubtitulo);'

replacement = '''                string textoSubtitulo = "FACTURA ELECTRÓNICA OFICIAL DE VENTA";
                if (!string.IsNullOrWhiteSpace(factura.NumeroFactura))
                {
                    if (factura.NumeroFactura.StartsWith("FC-R"))
                    {
                        textoSubtitulo = "FACTURA ELECTRÓNICA OFICIAL - RECARGO POR MORA";
                    }
                    else if (factura.NumeroFactura.StartsWith("FC-P"))
                    {
                        textoSubtitulo = "FACTURA ELECTRÓNICA OFICIAL - ALQUILER DE PRÉSTAMO";
                    }
                }
                Paragraph subtitulo = new Paragraph(textoSubtitulo + "\\n\\n", fuenteSubtitulo);'''

if target in content:
    content = content.replace(target, replacement)
    with open(r'BLL\BLLFactura.cs', 'w', encoding='utf-8') as f_out:
        f_out.write(content)
    print('SUCCESS')
else:
    print('TARGET NOT FOUND')
