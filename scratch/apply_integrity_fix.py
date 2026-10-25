import os

# 1. Update Servicios/Auditoria/ServicioEvento.cs
evento_path = r"Servicios\Auditoria\ServicioEvento.cs"
with open(evento_path, "r", encoding="utf-8") as f:
    evento_content = f.read()

old_grabar = """        public void GrabarBitacora(string accion, string modulo, int nivelCriticidad)
        {
            ServicioEvento registro = new ServicioEvento();"""

new_grabar = """        public void GrabarBitacora(string accion, string modulo, int nivelCriticidad)
        {
            if (accion != null && accion.Length > 50) accion = accion.Substring(0, 50);
            if (modulo != null && modulo.Length > 50) modulo = modulo.Substring(0, 50);

            ServicioEvento registro = new ServicioEvento();"""

assert old_grabar in evento_content, "old_grabar not found in ServicioEvento.cs"
evento_content = evento_content.replace(old_grabar, new_grabar, 1)

with open(evento_path, "w", encoding="utf-8") as f:
    f.write(evento_content)
print("ServicioEvento.cs updated.")

# 2. Update DAL/DALPrestamo.cs
dal_path = r"DAL\DALPrestamo.cs"
with open(dal_path, "r", encoding="utf-8") as f:
    dal_content = f.read()

old_guardar = """        public int GuardarPrestamo(BEPrestamo prestamo)
        {
            string query = @"INSERT INTO Prestamo (DNI, ISBN, IdFactura, FechaInicio, FechaDevolucion, FechaRealDevolucion, Estado, MontoPrestamo, MontoRecargo, DVH) 
                             VALUES (@DNI, @ISBN, @IdFactura, @FechaInicio, @FechaDevolucion, @FechaRealDevolucion, @Estado, @MontoPrestamo, @MontoRecargo, @DVH);
                             SELECT CAST(SCOPE_IDENTITY() AS INT);";

            using (SqlConnection conexion = new SqlConnection(cadena))
            {
                using (SqlCommand comando = new SqlCommand(query, conexion))
                {
                    comando.Parameters.Add("@DNI", SqlDbType.Int).Value = prestamo.DNI;
                    comando.Parameters.Add("@ISBN", SqlDbType.VarChar, 13).Value = prestamo.ISBN;
                    comando.Parameters.Add("@IdFactura", SqlDbType.Int).Value = (object?)prestamo.IdFactura ?? DBNull.Value;
                    comando.Parameters.Add("@FechaInicio", SqlDbType.Date).Value = prestamo.FechaInicio.Date;
                    comando.Parameters.Add("@FechaDevolucion", SqlDbType.Date).Value = prestamo.FechaDevolucion.Date;
                    comando.Parameters.Add("@FechaRealDevolucion", SqlDbType.Date).Value = prestamo.FechaRealDevolucion.HasValue ? prestamo.FechaRealDevolucion.Value.Date : DBNull.Value;
                    comando.Parameters.Add("@Estado", SqlDbType.VarChar, 30).Value = prestamo.Estado ?? "Pendiente";
                    comando.Parameters.Add("@MontoPrestamo", SqlDbType.Decimal).Value = prestamo.MontoPrestamo;
                    comando.Parameters.Add("@MontoRecargo", SqlDbType.Decimal).Value = prestamo.MontoRecargo;
                    comando.Parameters.Add("@DVH", SqlDbType.VarChar, 64).Value = (object?)prestamo.DVH ?? DBNull.Value;

                    conexion.Open();
                    int idGenerado = Convert.ToInt32(comando.ExecuteScalar());
                    prestamo.IdPrestamo = idGenerado;
                    return idGenerado;
                }
            }
        }"""

new_guardar = """        public int GuardarPrestamo(BEPrestamo prestamo)
        {
            string query = @"INSERT INTO Prestamo (DNI, ISBN, IdFactura, FechaInicio, FechaDevolucion, FechaRealDevolucion, Estado, MontoPrestamo, MontoRecargo, DVH) 
                             VALUES (@DNI, @ISBN, @IdFactura, @FechaInicio, @FechaDevolucion, @FechaRealDevolucion, @Estado, @MontoPrestamo, @MontoRecargo, @DVH);
                             SELECT CAST(SCOPE_IDENTITY() AS INT);";

            using (SqlConnection conexion = new SqlConnection(cadena))
            {
                using (SqlCommand comando = new SqlCommand(query, conexion))
                {
                    comando.Parameters.Add("@DNI", SqlDbType.Int).Value = prestamo.DNI;
                    comando.Parameters.Add("@ISBN", SqlDbType.VarChar, 13).Value = prestamo.ISBN;
                    comando.Parameters.Add("@IdFactura", SqlDbType.Int).Value = (object?)prestamo.IdFactura ?? DBNull.Value;
                    comando.Parameters.Add("@FechaInicio", SqlDbType.Date).Value = prestamo.FechaInicio.Date;
                    comando.Parameters.Add("@FechaDevolucion", SqlDbType.Date).Value = prestamo.FechaDevolucion.Date;
                    comando.Parameters.Add("@FechaRealDevolucion", SqlDbType.Date).Value = prestamo.FechaRealDevolucion.HasValue ? prestamo.FechaRealDevolucion.Value.Date : DBNull.Value;
                    comando.Parameters.Add("@Estado", SqlDbType.VarChar, 30).Value = prestamo.Estado ?? "Pendiente";
                    comando.Parameters.Add("@MontoPrestamo", SqlDbType.Decimal).Value = (decimal)(long)prestamo.MontoPrestamo;
                    comando.Parameters.Add("@MontoRecargo", SqlDbType.Decimal).Value = (decimal)(long)prestamo.MontoRecargo;
                    comando.Parameters.Add("@DVH", SqlDbType.VarChar, 64).Value = DBNull.Value;

                    conexion.Open();
                    int idGenerado = Convert.ToInt32(comando.ExecuteScalar());
                    prestamo.IdPrestamo = idGenerado;

                    GeneradorDigVerificador generador = new GeneradorDigVerificador();
                    prestamo.DVH = generador.GenerarDVH(prestamo);

                    using (SqlCommand cmdDVH = new SqlCommand("UPDATE Prestamo SET DVH = @DVH WHERE IdPrestamo = @IdPrestamo;", conexion))
                    {
                        cmdDVH.Parameters.Add("@DVH", SqlDbType.VarChar, 64).Value = prestamo.DVH;
                        cmdDVH.Parameters.Add("@IdPrestamo", SqlDbType.Int).Value = idGenerado;
                        cmdDVH.ExecuteNonQuery();
                    }

                    return idGenerado;
                }
            }
        }"""

assert old_guardar in dal_content, "old_guardar not found in DALPrestamo.cs"
dal_content = dal_content.replace(old_guardar, new_guardar, 1)

old_finalizar = """                    comando.Parameters.Add("@MontoRecargo", SqlDbType.Decimal).Value = prestamo.MontoRecargo;"""
new_finalizar = """                    comando.Parameters.Add("@MontoRecargo", SqlDbType.Decimal).Value = (decimal)(long)prestamo.MontoRecargo;"""
assert old_finalizar in dal_content, "old_finalizar not found in DALPrestamo.cs"
dal_content = dal_content.replace(old_finalizar, new_finalizar, 1)

old_mapear = """                MontoPrestamo = Convert.ToDecimal(reader["MontoPrestamo"]),
                MontoRecargo = Convert.ToDecimal(reader["MontoRecargo"]),"""
new_mapear = """                MontoPrestamo = (decimal)(long)Convert.ToDecimal(reader["MontoPrestamo"]),
                MontoRecargo = (decimal)(long)Convert.ToDecimal(reader["MontoRecargo"]),"""
assert old_mapear in dal_content, "old_mapear not found in DALPrestamo.cs"
dal_content = dal_content.replace(old_mapear, new_mapear, 1)

with open(dal_path, "w", encoding="utf-8") as f:
    f.write(dal_content)
print("DALPrestamo.cs updated.")

# 3. Update BLL/BLLPrestamo.cs
bll_path = r"BLL\BLLPrestamo.cs"
with open(bll_path, "r", encoding="utf-8") as f:
    bll_content = f.read()

old_solicitud = """            BEPrestamo prestamo = new BEPrestamo
            {
                DNI = dni,
                ISBN = isbn,
                IdFactura = null,
                FechaInicio = DateTime.Today,
                FechaDevolucion = fechaDevolucion.Date,
                FechaRealDevolucion = null,
                Estado = "Pendiente",
                MontoPrestamo = monto,
                MontoRecargo = 0m
            };
            prestamo.DVH = generador.GenerarDVH(prestamo);
            int id = dalPrestamo.GuardarPrestamo(prestamo);
            prestamo.IdPrestamo = id;
            servicioDVV.RecalcularDVVPrestamo();
            return prestamo;"""

new_solicitud = """            BEPrestamo prestamo = new BEPrestamo
            {
                DNI = dni,
                ISBN = isbn,
                IdFactura = null,
                FechaInicio = DateTime.Today,
                FechaDevolucion = fechaDevolucion.Date,
                FechaRealDevolucion = null,
                Estado = "Pendiente",
                MontoPrestamo = (decimal)(long)monto,
                MontoRecargo = 0m
            };
            int id = dalPrestamo.GuardarPrestamo(prestamo);
            prestamo.IdPrestamo = id;
            servicioDVV.RecalcularDVVPrestamo();
            return prestamo;"""

assert old_solicitud in bll_content, "old_solicitud not found in BLLPrestamo.cs"
bll_content = bll_content.replace(old_solicitud, new_solicitud, 1)

old_concretar = """            BEPrestamo prestamoParaDVH = new BEPrestamo
            {
                IdPrestamo = prestamo.IdPrestamo,
                DNI = prestamo.DNI,
                ISBN = prestamo.ISBN,
                IdFactura = idFactura,
                FechaInicio = prestamo.FechaInicio,
                FechaDevolucion = prestamo.FechaDevolucion,
                FechaRealDevolucion = prestamo.FechaRealDevolucion,
                Estado = "Activo",
                MontoPrestamo = prestamo.MontoPrestamo,
                MontoRecargo = prestamo.MontoRecargo
            };
            prestamo.DVH = generador.GenerarDVH(prestamoParaDVH);
            dalPrestamo.ActualizarPrestamoCobrado(prestamo.IdPrestamo, idFactura, prestamo.DVH);
            servicioDVV.RecalcularDVVPrestamo();

            BELibro? libro = bllLibro.ObtenerLibros().FirstOrDefault(l => l.ISBN_657SGA == prestamo.ISBN);
            if (libro != null)
            {
                libro.ExistenciasPrestamo = 0;
                bllLibro.ModificarLibro(libro, libro.ISBN_657SGA);
            }

            bitacora.GrabarBitacora($"Préstamo cobrado y activado. ID: {prestamo.IdPrestamo}, Factura: {factura.NumeroFactura}", "Préstamo", 1);"""

new_concretar = """            BEPrestamo prestamoParaDVH = new BEPrestamo
            {
                IdPrestamo = prestamo.IdPrestamo,
                DNI = prestamo.DNI,
                ISBN = prestamo.ISBN,
                IdFactura = idFactura,
                FechaInicio = prestamo.FechaInicio,
                FechaDevolucion = prestamo.FechaDevolucion,
                FechaRealDevolucion = prestamo.FechaRealDevolucion,
                Estado = "Activo",
                MontoPrestamo = (decimal)(long)prestamo.MontoPrestamo,
                MontoRecargo = (decimal)(long)prestamo.MontoRecargo
            };
            prestamo.DVH = generador.GenerarDVH(prestamoParaDVH);
            prestamo.IdFactura = idFactura;
            prestamo.Estado = "Activo";
            dalPrestamo.ActualizarPrestamoCobrado(prestamo.IdPrestamo, idFactura, prestamo.DVH);
            servicioDVV.RecalcularDVVPrestamo();

            BELibro? libro = bllLibro.ObtenerLibros().FirstOrDefault(l => l.ISBN_657SGA == prestamo.ISBN);
            if (libro != null)
            {
                libro.ExistenciasPrestamo = 0;
                bllLibro.ModificarLibro(libro, libro.ISBN_657SGA);
            }

            bitacora.GrabarBitacora($"Cobro Préstamo ID:{prestamo.IdPrestamo} FC:{factura.NumeroFactura}", "Préstamo", 1);"""

assert old_concretar in bll_content, "old_concretar not found in BLLPrestamo.cs"
bll_content = bll_content.replace(old_concretar, new_concretar, 1)

old_mora_bita = """            bitacora.GrabarBitacora($"Cobro de recargo por mora. Préstamo ID: {prestamo.IdPrestamo}, Factura: {factura.NumeroFactura}, Monto: {montoMora}", "Préstamo", 1);"""
new_mora_bita = """            bitacora.GrabarBitacora($"Cobro Mora ID:{prestamo.IdPrestamo} FC:{factura.NumeroFactura}", "Préstamo", 1);"""
assert old_mora_bita in bll_content, "old_mora_bita not found in BLLPrestamo.cs"
bll_content = bll_content.replace(old_mora_bita, new_mora_bita, 1)

old_devolucion = """            BEPrestamo prestamoParaDVH = new BEPrestamo
            {
                IdPrestamo = prestamo.IdPrestamo,
                DNI = prestamo.DNI,
                ISBN = prestamo.ISBN,
                IdFactura = prestamo.IdFactura,
                FechaInicio = prestamo.FechaInicio,
                FechaDevolucion = prestamo.FechaDevolucion,
                FechaRealDevolucion = prestamo.FechaRealDevolucion,
                Estado = prestamo.Estado,
                MontoPrestamo = prestamo.MontoPrestamo,
                MontoRecargo = prestamo.MontoRecargo
            };
            prestamo.DVH = generador.GenerarDVH(prestamoParaDVH);
            dalPrestamo.FinalizarPrestamo(prestamo);
            servicioDVV.RecalcularDVVPrestamo();

            BELibro? libro = bllLibro.ObtenerLibros().FirstOrDefault(l => l.ISBN_657SGA == prestamo.ISBN);
            if (libro != null)
            {
                libro.ExistenciasPrestamo = 1;
                bllLibro.ModificarLibro(libro, libro.ISBN_657SGA);
            }

            BECliente cliente = bllCliente.BuscarClientePorDNI(prestamo.DNI);

            if (!string.IsNullOrWhiteSpace(rutaPdfDevolucion))
            {
                GenerarComprobantePDF(prestamo, cliente, libro, rutaPdfDevolucion);
            }

            bitacora.GrabarBitacora($"Devolución de préstamo registrada. ID: {prestamo.IdPrestamo}, Estado: {prestamo.Estado}", "Préstamo", 1);"""

new_devolucion = """            BEPrestamo prestamoParaDVH = new BEPrestamo
            {
                IdPrestamo = prestamo.IdPrestamo,
                DNI = prestamo.DNI,
                ISBN = prestamo.ISBN,
                IdFactura = prestamo.IdFactura,
                FechaInicio = prestamo.FechaInicio,
                FechaDevolucion = prestamo.FechaDevolucion,
                FechaRealDevolucion = prestamo.FechaRealDevolucion,
                Estado = prestamo.Estado,
                MontoPrestamo = (decimal)(long)prestamo.MontoPrestamo,
                MontoRecargo = (decimal)(long)prestamo.MontoRecargo
            };
            prestamo.DVH = generador.GenerarDVH(prestamoParaDVH);
            dalPrestamo.FinalizarPrestamo(prestamo);
            servicioDVV.RecalcularDVVPrestamo();

            BELibro? libro = bllLibro.ObtenerLibros().FirstOrDefault(l => l.ISBN_657SGA == prestamo.ISBN);
            if (libro != null)
            {
                libro.ExistenciasPrestamo = 1;
                bllLibro.ModificarLibro(libro, libro.ISBN_657SGA);
            }

            BECliente cliente = bllCliente.BuscarClientePorDNI(prestamo.DNI);

            if (!string.IsNullOrWhiteSpace(rutaPdfDevolucion))
            {
                GenerarComprobantePDF(prestamo, cliente, libro, rutaPdfDevolucion);
            }

            bitacora.GrabarBitacora($"Devolución Préstamo ID:{prestamo.IdPrestamo}", "Préstamo", 1);"""

assert old_devolucion in bll_content, "old_devolucion not found in BLLPrestamo.cs"
bll_content = bll_content.replace(old_devolucion, new_devolucion, 1)

with open(bll_path, "w", encoding="utf-8") as f:
    f.write(bll_content)
print("BLLPrestamo.cs updated.")
