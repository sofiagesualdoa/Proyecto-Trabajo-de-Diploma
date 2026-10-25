with open('BLL/BLLPrestamo.cs', 'rb') as f:
    data = f.read()

target = '''                documento.Close();
            }
        }
    }
}'''

new_methods = '''                documento.Close();
            }
        }

        public List<BEPrestamo> ObtenerTodosLosPrestamos()
        {
            return dalPrestamo.ObtenerTodosLosPrestamos();
        }

        public List<BEPrestamo> FiltrarPrestamos(DateTime? fechaDesde, DateTime? fechaHasta, int? dniCliente)
        {
            var prestamos = ObtenerTodosLosPrestamos();
            if (fechaDesde.HasValue)
            {
                prestamos = prestamos.Where(p => p.FechaInicio.Date >= fechaDesde.Value.Date).ToList();
            }
            if (fechaHasta.HasValue)
            {
                prestamos = prestamos.Where(p => p.FechaInicio.Date <= fechaHasta.Value.Date).ToList();
            }
            if (dniCliente.HasValue && dniCliente.Value > 0)
            {
                prestamos = prestamos.Where(p => p.DNI.ToString().Contains(dniCliente.Value.ToString())).ToList();
            }
            return prestamos;
        }

        public List<BEDetallePrestamo> ObtenerDetallesPorPrestamo(BEPrestamo prestamo)
        {
            if (prestamo == null) return new List<BEDetallePrestamo>();

            BELibro? libro = bllLibro.ObtenerLibros().FirstOrDefault(l => l.ISBN_657SGA == prestamo.ISBN);
            BECliente? cliente = bllCliente.BuscarClientePorDNI(prestamo.DNI);

            BEDetallePrestamo detalle = new BEDetallePrestamo
            {
                IdPrestamo = prestamo.IdPrestamo,
                ISBN = prestamo.ISBN,
                Título = libro?.Título_657SGA ?? "N/A",
                Autor = libro?.Autor_657SGA ?? "N/A",
                Editorial = libro?.Editorial_657SGA ?? "N/A",
                Cliente = cliente != null ? $"{cliente.Nombre_657SGA} {cliente.Apellido_657SGA}" : "N/A",
                DNICliente = prestamo.DNI,
                Teléfono = cliente != null ? cliente.Teléfono_657SGA.ToString() : "N/A",
                Email = cliente?.Email_657SGA ?? "N/A",
                MontoPrestamo = prestamo.MontoPrestamo,
                MontoRecargo = prestamo.MontoRecargo
            };

            return new List<BEDetallePrestamo> { detalle };
        }

        public List<BEDetallePrestamo> ObtenerDetallesPorPrestamo(int idPrestamo)
        {
            BEPrestamo? p = dalPrestamo.ObtenerPrestamoPorId(idPrestamo);
            if (p == null) return new List<BEDetallePrestamo>();
            return ObtenerDetallesPorPrestamo(p);
        }
    }
}'''

target_bytes = target.replace('\n', '\r\n').encode('utf-8')
new_methods_bytes = new_methods.replace('\n', '\r\n').encode('utf-8')

assert target_bytes in data, "target not found in BLLPrestamo.cs"
data = data.replace(target_bytes, new_methods_bytes, 1)

with open('BLL/BLLPrestamo.cs', 'wb') as f:
    f.write(data)
print('Updated BLLPrestamo.cs successfully')
