with open('DAL/DALPrestamo.cs', 'rb') as f:
    data = f.read()

target1 = b'SELECT IdPrestamo, DNI, ISBN, IdFactura, FechaInicio, FechaDevolucion, FechaRealDevolucion, Estado, MontoPrestamo, MontoRecargo, DVH \r\n                             FROM Prestamo \r\n                             ORDER BY IdPrestamo DESC;'
replacement1 = b'SELECT p.IdPrestamo, p.DNI, p.ISBN, p.IdFactura, p.FechaInicio, p.FechaDevolucion, p.FechaRealDevolucion, p.Estado, p.MontoPrestamo, p.MontoRecargo, p.DVH, f.NumeroFactura \r\n                             FROM Prestamo p \r\n                             LEFT JOIN Factura f ON p.IdFactura = f.IdFactura \r\n                             ORDER BY p.IdPrestamo DESC;'

assert target1 in data, "target1 not found"
data = data.replace(target1, replacement1, 1)

target2 = b'            return new BEPrestamo\r\n            {\r\n                IdPrestamo = Convert.ToInt32(reader["IdPrestamo"]),\r\n                DNI = Convert.ToInt32(reader["DNI"]),\r\n                ISBN = reader["ISBN"].ToString() ?? string.Empty,\r\n                IdFactura = reader["IdFactura"] == DBNull.Value ? null : Convert.ToInt32(reader["IdFactura"]),\r\n                FechaInicio = Convert.ToDateTime(reader["FechaInicio"]),\r\n                FechaDevolucion = Convert.ToDateTime(reader["FechaDevolucion"]),\r\n                FechaRealDevolucion = reader["FechaRealDevolucion"] == DBNull.Value ? null : Convert.ToDateTime(reader["FechaRealDevolucion"]),\r\n                Estado = reader["Estado"].ToString() ?? string.Empty,\r\n                MontoPrestamo = (decimal)(long)Convert.ToDecimal(reader["MontoPrestamo"]),\r\n                MontoRecargo = (decimal)(long)Convert.ToDecimal(reader["MontoRecargo"]),\r\n                DVH = reader["DVH"]?.ToString() ?? string.Empty\r\n            };'

replacement2 = b'''            var p = new BEPrestamo
            {
                IdPrestamo = Convert.ToInt32(reader["IdPrestamo"]),
                DNI = Convert.ToInt32(reader["DNI"]),
                ISBN = reader["ISBN"].ToString() ?? string.Empty,
                IdFactura = reader["IdFactura"] == DBNull.Value ? null : Convert.ToInt32(reader["IdFactura"]),
                FechaInicio = Convert.ToDateTime(reader["FechaInicio"]),
                FechaDevolucion = Convert.ToDateTime(reader["FechaDevolucion"]),
                FechaRealDevolucion = reader["FechaRealDevolucion"] == DBNull.Value ? null : Convert.ToDateTime(reader["FechaRealDevolucion"]),
                Estado = reader["Estado"].ToString() ?? string.Empty,
                MontoPrestamo = (decimal)(long)Convert.ToDecimal(reader["MontoPrestamo"]),
                MontoRecargo = (decimal)(long)Convert.ToDecimal(reader["MontoRecargo"]),
                DVH = reader["DVH"]?.ToString() ?? string.Empty
            };
            for (int i = 0; i < reader.FieldCount; i++)
            {
                if (reader.GetName(i).Equals("NumeroFactura", StringComparison.OrdinalIgnoreCase))
                {
                    p.NumeroFactura = reader[i] != DBNull.Value ? reader[i].ToString() : string.Empty;
                    break;
                }
            }
            return p;'''.replace(b'\n', b'\r\n')

assert target2 in data, "target2 not found"
data = data.replace(target2, replacement2, 1)

with open('DAL/DALPrestamo.cs', 'wb') as f:
    f.write(data)
print('Updated DALPrestamo.cs successfully')
