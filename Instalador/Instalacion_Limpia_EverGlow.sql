USE [master]
GO
IF EXISTS (SELECT name FROM sys.databases WHERE name = N'EverGlow')
BEGIN
    ALTER DATABASE [EverGlow] SET SINGLE_USER WITH ROLLBACK IMMEDIATE;
    DROP DATABASE [EverGlow];
END
GO
CREATE DATABASE [EverGlow];
GO
USE [EverGlow];
GO
CREATE TABLE [dbo].[Cliente](
	[DNI_657SGA] [int] NOT NULL,
	[Nombre_657SGA] [varchar](100) NOT NULL,
	[Apellido_657SGA] [varchar](100) NOT NULL,
	[Email_657SGA] [nvarchar](100) NOT NULL,
	[Teléfono_657SGA] [int] NOT NULL,
	[Dirección_657SGA] [nvarchar](500) NULL,
	[Activo_657SGA] [bit] NOT NULL,
	[DVH] [varchar](64) NULL,
 CONSTRAINT [PK_Cliente] PRIMARY KEY CLUSTERED 
(
	[DNI_657SGA] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Objeto: Table [dbo].[DetalleFactura] Fecha de script: 13/11/2026 23:28:00 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[DetalleFactura](
	[IdDetalleFactura] [int] IDENTITY(1,1) NOT NULL,
	[IdFactura] [int] NOT NULL,
	[ISBN_657SGA] [varchar](13) NOT NULL,
	[Cantidad] [int] NOT NULL,
	[Precio] [decimal](18, 2) NOT NULL,
	[DVH] [varchar](64) NULL,
 CONSTRAINT [PK_DetalleFactura] PRIMARY KEY CLUSTERED 
(
	[IdDetalleFactura] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Objeto: Table [dbo].[DVV] Fecha de script: 13/11/2026 23:28:00 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[DVV](
	[NombreTabla] [varchar](50) NOT NULL,
	[Digito] [varchar](64) NOT NULL,
 CONSTRAINT [PK__DVV__5BCFB3890DC57862] PRIMARY KEY CLUSTERED 
(
	[NombreTabla] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Objeto: Table [dbo].[Evento] Fecha de script: 13/11/2026 23:28:00 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Evento](
	[IdEvento] [int] IDENTITY(1,1) NOT NULL,
	[Login] [varchar](50) NULL,
	[Criticidad] [int] NULL,
	[Fecha] [date] NULL,
	[Hora] [time](7) NULL,
	[NombreEvento] [varchar](50) NULL,
	[Modulo] [varchar](50) NULL,
	[DNI] [int] NOT NULL,
	[DVH] [varchar](64) NULL,
 CONSTRAINT [PK_Evento] PRIMARY KEY CLUSTERED 
(
	[IdEvento] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Objeto: Table [dbo].[Factura] Fecha de script: 13/11/2026 23:28:00 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Factura](
	[IdFactura] [int] IDENTITY(1,1) NOT NULL,
	[NumeroFactura] [varchar](50) NOT NULL,
	[Fecha] [date] NOT NULL,
	[Hora] [time](7) NOT NULL,
	[Total] [decimal](18, 2) NOT NULL,
	[DNICliente] [int] NOT NULL,
	[DVH] [varchar](64) NULL,
PRIMARY KEY CLUSTERED 
(
	[IdFactura] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Objeto: Table [dbo].[Familia] Fecha de script: 13/11/2026 23:28:00 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Familia](
	[IdFamilia] [int] IDENTITY(1,1) NOT NULL,
	[Nombre] [varchar](50) NOT NULL,
	[DVH] [varchar](64) NULL,
 CONSTRAINT [PK_Familia] PRIMARY KEY CLUSTERED 
(
	[IdFamilia] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Objeto: Table [dbo].[Familia_x_Familia] Fecha de script: 13/11/2026 23:28:00 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Familia_x_Familia](
	[IdFamiliaPadre] [int] NOT NULL,
	[IdFamiliaHijo] [int] NOT NULL,
	[DVH] [varchar](64) NULL,
 CONSTRAINT [PK_Familia_x_Familia] PRIMARY KEY CLUSTERED 
(
	[IdFamiliaPadre] ASC,
	[IdFamiliaHijo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Objeto: Table [dbo].[Idioma] Fecha de script: 13/11/2026 23:28:00 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Idioma](
	[IdIdioma] [int] IDENTITY(1,1) NOT NULL,
	[Nombre] [varchar](50) NOT NULL,
	[Codigo] [varchar](10) NOT NULL,
	[DVH] [varchar](64) NULL,
PRIMARY KEY CLUSTERED 
(
	[IdIdioma] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Objeto: Table [dbo].[Libro] Fecha de script: 13/11/2026 23:28:00 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Libro](
	[Título_657SGA] [nvarchar](100) NULL,
	[ISBN_657SGA] [varchar](13) NOT NULL,
	[Precio_657SGA] [decimal](18, 0) NULL,
	[Existencias_657SGA] [int] NULL,
	[Editorial_657SGA] [nvarchar](100) NULL,
	[Autor_657SGA] [varchar](max) NULL,
	[Activo_657SGA] [bit] NULL,
	[DVH] [varchar](64) NULL,
	[EsParaPrestamo] [bit] NOT NULL,
	[ExistenciasPrestamo] [int] NOT NULL,
 CONSTRAINT [PK_Libro] PRIMARY KEY CLUSTERED 
(
	[ISBN_657SGA] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Objeto: Table [dbo].[Libro_C] Fecha de script: 13/11/2026 23:28:00 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Libro_C](
	[IdLibroC] [int] IDENTITY(1,1) NOT NULL,
	[ISBN] [varchar](13) NOT NULL,
	[Titulo] [nvarchar](100) NULL,
	[Precio] [decimal](18, 2) NULL,
	[Existencias] [int] NULL,
	[ExistenciasPrestamo] [int] NULL,
	[Editorial] [nvarchar](100) NULL,
	[Autor] [varchar](max) NULL,
	[EsParaPrestamo] [bit] NULL,
	[Activo] [bit] NULL,
	[DVH] [varchar](64) NULL,
	[Fecha] [date] NOT NULL,
	[Hora] [time](7) NOT NULL,
	[Act] [bit] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[IdLibroC] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Objeto: Table [dbo].[Perfil] Fecha de script: 13/11/2026 23:28:00 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Perfil](
	[IdPerfil] [int] IDENTITY(1,1) NOT NULL,
	[Nombre] [varchar](50) NOT NULL,
	[DVH] [varchar](64) NULL,
 CONSTRAINT [PK_Perfil] PRIMARY KEY CLUSTERED 
(
	[IdPerfil] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Objeto: Table [dbo].[Perfil_x_Familia] Fecha de script: 13/11/2026 23:28:00 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Perfil_x_Familia](
	[IdPerfil] [int] NOT NULL,
	[IdFamilia] [int] NOT NULL,
	[DVH] [varchar](64) NULL,
 CONSTRAINT [PK_Perfil_x_Familia] PRIMARY KEY CLUSTERED 
(
	[IdPerfil] ASC,
	[IdFamilia] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Objeto: Table [dbo].[Perfil_x_Permiso] Fecha de script: 13/11/2026 23:28:00 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Perfil_x_Permiso](
	[IdPerfil] [int] NOT NULL,
	[IdPermiso] [int] NOT NULL,
	[DVH] [varchar](64) NULL,
 CONSTRAINT [PK_Perfil_x_Permiso] PRIMARY KEY CLUSTERED 
(
	[IdPerfil] ASC,
	[IdPermiso] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Objeto: Table [dbo].[Permiso] Fecha de script: 13/11/2026 23:28:00 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Permiso](
	[IdPermiso] [int] IDENTITY(1,1) NOT NULL,
	[Nombre] [varchar](50) NOT NULL,
	[DVH] [varchar](64) NULL,
 CONSTRAINT [PK_Permiso] PRIMARY KEY CLUSTERED 
(
	[IdPermiso] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Objeto: Table [dbo].[Permiso_x_Familia] Fecha de script: 13/11/2026 23:28:00 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Permiso_x_Familia](
	[IdFamilia] [int] NOT NULL,
	[IdPermiso] [int] NOT NULL,
	[DVH] [varchar](64) NULL,
 CONSTRAINT [PK_Permiso_x_Familia] PRIMARY KEY CLUSTERED 
(
	[IdFamilia] ASC,
	[IdPermiso] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Objeto: Table [dbo].[Prestamo] Fecha de script: 13/11/2026 23:28:00 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Prestamo](
	[IdPrestamo] [int] IDENTITY(1,1) NOT NULL,
	[DNI] [int] NOT NULL,
	[ISBN] [varchar](13) NOT NULL,
	[IdFactura] [int] NULL,
	[FechaInicio] [date] NOT NULL,
	[FechaDevolucion] [date] NOT NULL,
	[FechaRealDevolucion] [date] NULL,
	[Estado] [varchar](30) NOT NULL,
	[MontoPrestamo] [decimal](18, 0) NOT NULL,
	[MontoRecargo] [decimal](18, 0) NOT NULL,
	[DVH] [varchar](64) NULL,
 CONSTRAINT [PK_Prestamo] PRIMARY KEY CLUSTERED 
(
	[IdPrestamo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Objeto: Table [dbo].[Usuario] Fecha de script: 13/11/2026 23:28:00 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Usuario](
	[DNI] [int] NOT NULL,
	[Nombre] [varchar](50) NULL,
	[Apellido] [varchar](50) NULL,
	[NombreUsuario] [varchar](50) NOT NULL,
	[Bloqueado] [bit] NULL,
	[Activo] [bit] NULL,
	[Contraseña] [varchar](64) NOT NULL,
	[IntentosInicio] [int] NULL,
	[Email] [varchar](50) NULL,
	[IdPerfil] [int] NOT NULL,
	[IdIdioma] [int] NULL,
	[DVH] [varchar](64) NULL,
 CONSTRAINT [PK_Usuario] PRIMARY KEY CLUSTERED 
(
	[DNI] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
INSERT [dbo].[Cliente] ([DNI_657SGA], [Nombre_657SGA], [Apellido_657SGA], [Email_657SGA], [Teléfono_657SGA], [Dirección_657SGA], [Activo_657SGA], [DVH]) VALUES (1234567, N'aaa', N'a', N'a', 1, N'GELeurzrvn/nHXkSY2TTwA==', 1, N'Ab7JuUCVEaQkYzZwYpkd7C767DCJR1iPRvpme6QOras=')
INSERT [dbo].[Cliente] ([DNI_657SGA], [Nombre_657SGA], [Apellido_657SGA], [Email_657SGA], [Teléfono_657SGA], [Dirección_657SGA], [Activo_657SGA], [DVH]) VALUES (7777777, N'a', N'g', N'aaaa', 1234567890, N'29CSUBA8JmBjnCYUxgXfHA==', 0, N'lU+saJ89yfF7exkAAFcqcSkdYgdXYp9erXjkPgxCmi4=')
INSERT [dbo].[Cliente] ([DNI_657SGA], [Nombre_657SGA], [Apellido_657SGA], [Email_657SGA], [Teléfono_657SGA], [Dirección_657SGA], [Activo_657SGA], [DVH]) VALUES (11223344, N'a', N'a', N'a', 1, N'GELeurzrvn/nHXkSY2TTwA==', 1, N'0VPtD6RNSWH4zwqWpDnbui8W/6P1NwHwd2IOWXGzdjo=')
INSERT [dbo].[Cliente] ([DNI_657SGA], [Nombre_657SGA], [Apellido_657SGA], [Email_657SGA], [Teléfono_657SGA], [Dirección_657SGA], [Activo_657SGA], [DVH]) VALUES (18118401, N'alberto', N'gesualdo', N'ag@gmail.com', 15, N'38IKxA2j1oWARSSzPHpRUpS8hpXMjK76l65fUvYPj2A=', 1, N'Wes41AarbY5kgRKaShr/5UCrCubhYswpZ/ZtYxOzKyY=')
INSERT [dbo].[Cliente] ([DNI_657SGA], [Nombre_657SGA], [Apellido_657SGA], [Email_657SGA], [Teléfono_657SGA], [Dirección_657SGA], [Activo_657SGA], [DVH]) VALUES (44657897, N'Juan', N'Perez', N'juanp@gmail.com', 12345678, N'X1aeQUMIYjiiSD6+rtalGw==', 1, N'bfkuLe3qKudRc5aS2jEM5XNsi0fSW/8M2X3x8tVsWDA=')
INSERT [dbo].[Cliente] ([DNI_657SGA], [Nombre_657SGA], [Apellido_657SGA], [Email_657SGA], [Teléfono_657SGA], [Dirección_657SGA], [Activo_657SGA], [DVH]) VALUES (46956657, N'Sofia', N'Gesualdo', N'sofigesualdo@gmail.com', 1112345678, N'38IKxA2j1oWARSSzPHpRUmPt/o3FKM3Z2xzWk2abaD4=', 1, N'LeSqySKiygda/sATqh4LhjigfFVEnFWoyu5GtyRsNjs=')
INSERT [dbo].[Cliente] ([DNI_657SGA], [Nombre_657SGA], [Apellido_657SGA], [Email_657SGA], [Teléfono_657SGA], [Dirección_657SGA], [Activo_657SGA], [DVH]) VALUES (88888888, N's', N's', N's', 1, N'2bBvqH0idUUph2lBP9dmHg==', 1, N'1u0gfIgUl7nb0LvihDRu58Jy+NRqXTkKS5eW1bQgoFc=')
GO
SET IDENTITY_INSERT [dbo].[DetalleFactura] ON 

INSERT [dbo].[DetalleFactura] ([IdDetalleFactura], [IdFactura], [ISBN_657SGA], [Cantidad], [Precio], [DVH]) VALUES (1, 3, N'9789878591341', 1, CAST(25000.00 AS Decimal(18, 2)), N'n0S+WtGHax2lyofa0/HrJEU67wNjs58dT7C0vPAF+YM=')
INSERT [dbo].[DetalleFactura] ([IdDetalleFactura], [IdFactura], [ISBN_657SGA], [Cantidad], [Precio], [DVH]) VALUES (2, 4, N'9789878950341', 1, CAST(20000.00 AS Decimal(18, 2)), N'C/epUxW2lLG5iXH9V8j2eyn583WOx1xQJsG5MdYg8HY=')
INSERT [dbo].[DetalleFactura] ([IdDetalleFactura], [IdFactura], [ISBN_657SGA], [Cantidad], [Precio], [DVH]) VALUES (3, 5, N'9784587653215', 1, CAST(2000.00 AS Decimal(18, 2)), N'8StqesIyfao8EuNFovMHVSO7UsV8BvkRF7qQiBqA3JE=')
INSERT [dbo].[DetalleFactura] ([IdDetalleFactura], [IdFactura], [ISBN_657SGA], [Cantidad], [Precio], [DVH]) VALUES (4, 6, N'9784587653215', 1, CAST(2800.00 AS Decimal(18, 2)), N'H+WSB4rAvNo4Yzxb49nQGmg/SKUXCjXcwVbRm1CcwQ0=')
INSERT [dbo].[DetalleFactura] ([IdDetalleFactura], [IdFactura], [ISBN_657SGA], [Cantidad], [Precio], [DVH]) VALUES (5, 7, N'9781526369874', 1, CAST(20000.00 AS Decimal(18, 2)), N'Gd2E0f/HXctS6PaBEGz/7JHr8ItHYRwYIVGraqvw36A=')
INSERT [dbo].[DetalleFactura] ([IdDetalleFactura], [IdFactura], [ISBN_657SGA], [Cantidad], [Precio], [DVH]) VALUES (6, 8, N'9781526369874', 1, CAST(2000.00 AS Decimal(18, 2)), N'5bD6iD/1/SvuM5WXtc7WVP0llO9KYImBg159Ab1ew4Y=')
INSERT [dbo].[DetalleFactura] ([IdDetalleFactura], [IdFactura], [ISBN_657SGA], [Cantidad], [Precio], [DVH]) VALUES (7, 9, N'9781526369874', 1, CAST(2000.00 AS Decimal(18, 2)), N'M8eqY4AyJVMS8G/nQx6fDEnMpKOLWOnsg3fF3PVIKbE=')
INSERT [dbo].[DetalleFactura] ([IdDetalleFactura], [IdFactura], [ISBN_657SGA], [Cantidad], [Precio], [DVH]) VALUES (8, 10, N'9781526369874', 1, CAST(2000.00 AS Decimal(18, 2)), N'vhBOLMIEf84xYRW/4/8E/uEYZ60UQ/5IfV2DMN91BQw=')
INSERT [dbo].[DetalleFactura] ([IdDetalleFactura], [IdFactura], [ISBN_657SGA], [Cantidad], [Precio], [DVH]) VALUES (9, 11, N'9781526369874', 1, CAST(7000.00 AS Decimal(18, 2)), N'eZ/A2sERfGry75XmHNnwG+6fHkaQ74eHBItKFHNOiJw=')
INSERT [dbo].[DetalleFactura] ([IdDetalleFactura], [IdFactura], [ISBN_657SGA], [Cantidad], [Precio], [DVH]) VALUES (10, 12, N'9781526369874', 1, CAST(2000.00 AS Decimal(18, 2)), N'ZbmvRoLUl9D77BdG4ASjI2NXrgV0Ti1LNu7sj0lUC/M=')
INSERT [dbo].[DetalleFactura] ([IdDetalleFactura], [IdFactura], [ISBN_657SGA], [Cantidad], [Precio], [DVH]) VALUES (11, 13, N'9784587653215', 1, CAST(400.00 AS Decimal(18, 2)), N'ZJefVIdSvJyNK3y5advf3aZ8zRyHpa4k4kYI0iHOp/Y=')
INSERT [dbo].[DetalleFactura] ([IdDetalleFactura], [IdFactura], [ISBN_657SGA], [Cantidad], [Precio], [DVH]) VALUES (12, 14, N'9781526369874', 1, CAST(20000.00 AS Decimal(18, 2)), N'cmP5Q/JL6/1eqSMW/2UMX6KzkLtTqrO9FOziL8MP2js=')
INSERT [dbo].[DetalleFactura] ([IdDetalleFactura], [IdFactura], [ISBN_657SGA], [Cantidad], [Precio], [DVH]) VALUES (13, 15, N'9784587653215', 1, CAST(3000.00 AS Decimal(18, 2)), N'6KLxvD4JjOJ9vvXd7xv3EQJ1WT85jW8XK5HqwD6/k2s=')
SET IDENTITY_INSERT [dbo].[DetalleFactura] OFF
GO
INSERT [dbo].[DVV] ([NombreTabla], [Digito]) VALUES (N'Evento', N'2931490')
INSERT [dbo].[DVV] ([NombreTabla], [Digito]) VALUES (N'Familia', N'11724')
INSERT [dbo].[DVV] ([NombreTabla], [Digito]) VALUES (N'Familia_x_Familia', N'5405')
INSERT [dbo].[DVV] ([NombreTabla], [Digito]) VALUES (N'Idioma', N'8170')
INSERT [dbo].[DVV] ([NombreTabla], [Digito]) VALUES (N'Libro', N'22628')
INSERT [dbo].[DVV] ([NombreTabla], [Digito]) VALUES (N'Perfil', N'12037')
INSERT [dbo].[DVV] ([NombreTabla], [Digito]) VALUES (N'Perfil_x_Familia', N'1611')
INSERT [dbo].[DVV] ([NombreTabla], [Digito]) VALUES (N'Perfil_x_Permiso', N'164190')
INSERT [dbo].[DVV] ([NombreTabla], [Digito]) VALUES (N'Permiso', N'76239')
INSERT [dbo].[DVV] ([NombreTabla], [Digito]) VALUES (N'Permiso_x_Familia', N'16622')
INSERT [dbo].[DVV] ([NombreTabla], [Digito]) VALUES (N'Prestamo', N'30211')
INSERT [dbo].[DVV] ([NombreTabla], [Digito]) VALUES (N'Usuario', N'15492')
GO
SET IDENTITY_INSERT [dbo].[Evento] ON 

INSERT [dbo].[Evento] ([IdEvento], [Login], [Criticidad], [Fecha], [Hora], [NombreEvento], [Modulo], [DNI], [DVH]) VALUES (2, N'vicky', 1, CAST(N'2026-06-23' AS Date), CAST(N'17:53:13.6995426' AS Time), N'Login', N'Usuario', 12345678, N'Y+ZSl3CKUsZKH5Bekf9PXdUGa5UbajippzINSTceWnc=')
INSERT [dbo].[Evento] ([IdEvento], [Login], [Criticidad], [Fecha], [Hora], [NombreEvento], [Modulo], [DNI], [DVH]) VALUES (3, N'vicky', 1, CAST(N'2026-06-23' AS Date), CAST(N'17:53:27.4760376' AS Time), N'Logout', N'Usuario', 12345678, N'7emRTeUSAN+sfi62gcmsOIAC+lyPjcXjR33cmEvHMbQ=')
INSERT [dbo].[Evento] ([IdEvento], [Login], [Criticidad], [Fecha], [Hora], [NombreEvento], [Modulo], [DNI], [DVH]) VALUES (4, N'vicky', 1, CAST(N'2026-06-23' AS Date), CAST(N'18:50:00.4112258' AS Time), N'Login', N'Usuario', 12345678, N'aqx7hu89kf2MBXhZuvic2Ct2OaQ5ZNXOHFd4MBad5IQ=')
INSERT [dbo].[Evento] ([IdEvento], [Login], [Criticidad], [Fecha], [Hora], [NombreEvento], [Modulo], [DNI], [DVH]) VALUES (5, N'vicky', 1, CAST(N'2026-06-23' AS Date), CAST(N'18:51:27.1145500' AS Time), N'Login', N'Usuario', 12345678, N'8hdXga8JCvaI0DQ5gSxv9v4w1lR6vEi8oPMi54l5wi0=')
INSERT [dbo].[Evento] ([IdEvento], [Login], [Criticidad], [Fecha], [Hora], [NombreEvento], [Modulo], [DNI], [DVH]) VALUES (6, N'vicky', 1, CAST(N'2026-06-23' AS Date), CAST(N'18:56:21.2866110' AS Time), N'Login', N'Usuario', 12345678, N'nIJomxcsOy8BzLNt7ktoloHPsx0sv9k3fQ3oIK65Q0Q=')
INSERT [dbo].[Evento] ([IdEvento], [Login], [Criticidad], [Fecha], [Hora], [NombreEvento], [Modulo], [DNI], [DVH]) VALUES (7, N'vicky', 1, CAST(N'2026-06-23' AS Date), CAST(N'18:56:25.4020841' AS Time), N'Logout', N'Usuario', 12345678, N'4gneEL8M41gc5TB3DgLgVys7ei1eBFjyxOWh4KoGIsg=')
INSERT [dbo].[Evento] ([IdEvento], [Login], [Criticidad], [Fecha], [Hora], [NombreEvento], [Modulo], [DNI], [DVH]) VALUES (8, N'vicky', 1, CAST(N'2026-06-23' AS Date), CAST(N'18:56:32.8885782' AS Time), N'Login', N'Usuario', 12345678, N'uA9DY5wJuT/0BwUkiIaWG7pnns1KdBQ6RkFo/LTfyEw=')
INSERT [dbo].[Evento] ([IdEvento], [Login], [Criticidad], [Fecha], [Hora], [NombreEvento], [Modulo], [DNI], [DVH]) VALUES (9, N'vicky', 1, CAST(N'2026-06-23' AS Date), CAST(N'18:56:53.9820382' AS Time), N'Cambiar Clave', N'Usuario', 12345678, N'1Z8hegYPPDJvithlOpzs7NDkTitJl5e1S0dqJGms+qI=')
INSERT [dbo].[Evento] ([IdEvento], [Login], [Criticidad], [Fecha], [Hora], [NombreEvento], [Modulo], [DNI], [DVH]) VALUES (10, N'vicky', 1, CAST(N'2026-06-23' AS Date), CAST(N'18:56:55.1969489' AS Time), N'Logout', N'Usuario', 12345678, N'10hA/AZflobEOB1ekdQogFzSQHmH3ahQoynQ1But0Z0=')
INSERT [dbo].[Evento] ([IdEvento], [Login], [Criticidad], [Fecha], [Hora], [NombreEvento], [Modulo], [DNI], [DVH]) VALUES (11, N'vicky', 1, CAST(N'2026-06-23' AS Date), CAST(N'18:57:00.1910672' AS Time), N'Login', N'Usuario', 12345678, N'sMm9FrMt8sRxZzTTJ4v3Oj0XIY0/WG8b3+b5N/Bxyvg=')
INSERT [dbo].[Evento] ([IdEvento], [Login], [Criticidad], [Fecha], [Hora], [NombreEvento], [Modulo], [DNI], [DVH]) VALUES (12, N'vicky', 1, CAST(N'2026-06-23' AS Date), CAST(N'18:57:02.9351413' AS Time), N'Logout', N'Usuario', 12345678, N'glU8PRYCGaYW9rW8XDb4Sn2rVHpi+YHGHKfrcvkRP5s=')
INSERT [dbo].[Evento] ([IdEvento], [Login], [Criticidad], [Fecha], [Hora], [NombreEvento], [Modulo], [DNI], [DVH]) VALUES (13, N'vicky', 1, CAST(N'2026-06-23' AS Date), CAST(N'18:57:11.1105401' AS Time), N'Login', N'Usuario', 12345678, N'DrY8LhSij+Rf2/00G8WR83p9wl9Sd6JCVu8A2vlIk2Y=')
INSERT [dbo].[Evento] ([IdEvento], [Login], [Criticidad], [Fecha], [Hora], [NombreEvento], [Modulo], [DNI], [DVH]) VALUES (14, N'sofigesualdo', 1, CAST(N'2026-06-23' AS Date), CAST(N'21:31:59.4106069' AS Time), N'Login', N'Usuario', 46956657, N'+nLAYleelTL6/nwXz3yequzLUiEb3okn0M8SY5lGgKo=')
INSERT [dbo].[Evento] ([IdEvento], [Login], [Criticidad], [Fecha], [Hora], [NombreEvento], [Modulo], [DNI], [DVH]) VALUES (15, N'sofigesualdo', 1, CAST(N'2026-06-23' AS Date), CAST(N'21:32:42.1196979' AS Time), N'Login', N'Usuario', 46956657, N'SIcpfchKtaGX5r0eWCbItpZb7aosbaWdIpFrYYTYsug=')
INSERT [dbo].[Evento] ([IdEvento], [Login], [Criticidad], [Fecha], [Hora], [NombreEvento], [Modulo], [DNI], [DVH]) VALUES (16, N'sofigesualdo', 1, CAST(N'2026-06-23' AS Date), CAST(N'21:33:05.6090493' AS Time), N'Login', N'Usuario', 46956657, N'pkLxzPguddIRm7f458ChgHsIuEbHv7ELtgnPQ1KLHc4=')
INSERT [dbo].[Evento] ([IdEvento], [Login], [Criticidad], [Fecha], [Hora], [NombreEvento], [Modulo], [DNI], [DVH]) VALUES (17, N'vicky', 1, CAST(N'2026-06-23' AS Date), CAST(N'21:34:20.8730577' AS Time), N'Login', N'Usuario', 12345678, N'+JmE088S8kOsUeV+Zi/ExwNCOK0tDS9WDEe4dv5euVY=')
INSERT [dbo].[Evento] ([IdEvento], [Login], [Criticidad], [Fecha], [Hora], [NombreEvento], [Modulo], [DNI], [DVH]) VALUES (18, N'sofigesualdo', 1, CAST(N'2026-06-23' AS Date), CAST(N'21:35:54.7764665' AS Time), N'Login', N'Usuario', 46956657, N'DmI/xzi7kAJ3YL67ToUqab4Xtmpzay60Vm03ujIoUd0=')
INSERT [dbo].[Evento] ([IdEvento], [Login], [Criticidad], [Fecha], [Hora], [NombreEvento], [Modulo], [DNI], [DVH]) VALUES (19, N'vicky', 1, CAST(N'2026-06-23' AS Date), CAST(N'21:36:07.9093687' AS Time), N'Login', N'Usuario', 12345678, N'yxPm/3MXeBSBtFtZYaorKYvRNcBg9f32fHIel1TVD4g=')
INSERT [dbo].[Evento] ([IdEvento], [Login], [Criticidad], [Fecha], [Hora], [NombreEvento], [Modulo], [DNI], [DVH]) VALUES (20, N'sofigesualdo', 1, CAST(N'2026-06-23' AS Date), CAST(N'21:37:20.3564092' AS Time), N'Login', N'Usuario', 46956657, N'oaP0y8vYmBuSThKeqP1pD7Cc2IkzzyK6qsRLlIiO0jM=')
INSERT [dbo].[Evento] ([IdEvento], [Login], [Criticidad], [Fecha], [Hora], [NombreEvento], [Modulo], [DNI], [DVH]) VALUES (21, N'sofigesualdo', 1, CAST(N'2026-06-23' AS Date), CAST(N'21:42:59.0514459' AS Time), N'Login', N'Usuario', 46956657, N'p8m3pFC7s86A+aFIfkwQ9V9aZgLUcLGGcwIbbdGDdrM=')
INSERT [dbo].[Evento] ([IdEvento], [Login], [Criticidad], [Fecha], [Hora], [NombreEvento], [Modulo], [DNI], [DVH]) VALUES (22, N'vicky', 1, CAST(N'2026-06-23' AS Date), CAST(N'21:43:12.0810594' AS Time), N'Login', N'Usuario', 12345678, N'0XpChqsXW7A9zyRdUYbMPUIQpXQwMbNRT1gx6w0J6Do=')
INSERT [dbo].[Evento] ([IdEvento], [Login], [Criticidad], [Fecha], [Hora], [NombreEvento], [Modulo], [DNI], [DVH]) VALUES (23, N'sofigesualdo', 1, CAST(N'2026-06-23' AS Date), CAST(N'21:44:25.1273918' AS Time), N'Login', N'Usuario', 46956657, N'sJ610TxpRhfOGcCnTIC4TP8W2erPRF4mhNSk2zLY5o4=')
INSERT [dbo].[Evento] ([IdEvento], [Login], [Criticidad], [Fecha], [Hora], [NombreEvento], [Modulo], [DNI], [DVH]) VALUES (24, N'sofigesualdo', 1, CAST(N'2026-06-23' AS Date), CAST(N'22:15:13.6057155' AS Time), N'Login', N'Usuario', 46956657, N'G9zCnrgThl0qA5n4T8a/uK9fvhrlN0fmoXU3sMoBq3g=')
INSERT [dbo].[Evento] ([IdEvento], [Login], [Criticidad], [Fecha], [Hora], [NombreEvento], [Modulo], [DNI], [DVH]) VALUES (25, N'sofigesualdo', 1, CAST(N'2026-06-23' AS Date), CAST(N'22:16:36.8016296' AS Time), N'Login', N'Usuario', 46956657, N'wSX3/K8oazrWt5xRHoL56sE+5c6m2tP8dzX7aowADKE=')
INSERT [dbo].[Evento] ([IdEvento], [Login], [Criticidad], [Fecha], [Hora], [NombreEvento], [Modulo], [DNI], [DVH]) VALUES (26, N'sofigesualdo', 1, CAST(N'2026-06-23' AS Date), CAST(N'22:18:43.6225729' AS Time), N'Login', N'Usuario', 46956657, N'P3M6PLlDUL5llaw9kFhzxtLqtPFwICbJYK1sGMl16pI=')
INSERT [dbo].[Evento] ([IdEvento], [Login], [Criticidad], [Fecha], [Hora], [NombreEvento], [Modulo], [DNI], [DVH]) VALUES (27, N'sofigesualdo', 1, CAST(N'2026-06-23' AS Date), CAST(N'22:32:53.3072705' AS Time), N'Login', N'Usuario', 46956657, N'0yloqqgXyX95DrLfsdMXYuAw7Rrwn3yxMmdTe2yyqDM=')
INSERT [dbo].[Evento] ([IdEvento], [Login], [Criticidad], [Fecha], [Hora], [NombreEvento], [Modulo], [DNI], [DVH]) VALUES (28, N'sofigesualdo', 1, CAST(N'2026-06-23' AS Date), CAST(N'22:33:16.9627866' AS Time), N'Logout', N'Usuario', 46956657, N'UqlkcknEcD5ROXOnawNNsFmDZ/5QFOMT/G/hfPpGwpo=')
INSERT [dbo].[Evento] ([IdEvento], [Login], [Criticidad], [Fecha], [Hora], [NombreEvento], [Modulo], [DNI], [DVH]) VALUES (29, N'sofigesualdo', 1, CAST(N'2026-06-23' AS Date), CAST(N'22:36:55.5116960' AS Time), N'Login', N'Usuario', 46956657, N'za0KcGJuc04YqtrNrvQkF40azY8lC2P3Tn6Ap0q0C28=')
INSERT [dbo].[Evento] ([IdEvento], [Login], [Criticidad], [Fecha], [Hora], [NombreEvento], [Modulo], [DNI], [DVH]) VALUES (30, N'vicky', 1, CAST(N'2026-06-23' AS Date), CAST(N'22:37:10.1691934' AS Time), N'Login', N'Usuario', 12345678, N'RoN6a6verQ/Smnl0QQZXVfLqP0cbjrcCQYVxiNZcmVU=')
INSERT [dbo].[Evento] ([IdEvento], [Login], [Criticidad], [Fecha], [Hora], [NombreEvento], [Modulo], [DNI], [DVH]) VALUES (31, N'vicky', 1, CAST(N'2026-06-23' AS Date), CAST(N'22:37:14.4516292' AS Time), N'Logout', N'Usuario', 12345678, N'tOZKmhaOoXi1Yt4rfclztuXFnx6t95Mm+dEL776Sk0k=')
INSERT [dbo].[Evento] ([IdEvento], [Login], [Criticidad], [Fecha], [Hora], [NombreEvento], [Modulo], [DNI], [DVH]) VALUES (32, N'sofigesualdo', 1, CAST(N'2026-06-23' AS Date), CAST(N'22:40:26.6644208' AS Time), N'Login', N'Usuario', 46956657, N'Kw2ckkHoM4kiZsRUc2Xsxd7/Pr2XDqQ6KaHT2F5mys4=')
INSERT [dbo].[Evento] ([IdEvento], [Login], [Criticidad], [Fecha], [Hora], [NombreEvento], [Modulo], [DNI], [DVH]) VALUES (33, N'sofigesualdo', 1, CAST(N'2026-06-23' AS Date), CAST(N'22:41:30.7119651' AS Time), N'Login', N'Usuario', 46956657, N'/pov5epe1PdM31EQ1duXxK+pI7XVIs3meg5mEILBHmE=')
INSERT [dbo].[Evento] ([IdEvento], [Login], [Criticidad], [Fecha], [Hora], [NombreEvento], [Modulo], [DNI], [DVH]) VALUES (34, N'sofigesualdo', 1, CAST(N'2026-06-23' AS Date), CAST(N'22:41:32.7309740' AS Time), N'Logout', N'Usuario', 46956657, N'ulvKHZ0xL4dsO5rrCnn6Cxl3tk1/FuXi137ISF8a03s=')
INSERT [dbo].[Evento] ([IdEvento], [Login], [Criticidad], [Fecha], [Hora], [NombreEvento], [Modulo], [DNI], [DVH]) VALUES (35, N'sofigesualdo', 1, CAST(N'2026-06-23' AS Date), CAST(N'22:48:17.1483321' AS Time), N'Login', N'Usuario', 46956657, N'LxsavG9+oP1JMihT3uV3cqJr9BSwBkNi4E2jPJ7DDqc=')
INSERT [dbo].[Evento] ([IdEvento], [Login], [Criticidad], [Fecha], [Hora], [NombreEvento], [Modulo], [DNI], [DVH]) VALUES (36, N'sofigesualdo', 1, CAST(N'2026-06-23' AS Date), CAST(N'22:49:08.2946662' AS Time), N'Login', N'Usuario', 46956657, N'wAJd9Gb5Ixjczcom3QQFqKALCwjXjjI2IZBRsLvoW6A=')
INSERT [dbo].[Evento] ([IdEvento], [Login], [Criticidad], [Fecha], [Hora], [NombreEvento], [Modulo], [DNI], [DVH]) VALUES (37, N'sofigesualdo', 1, CAST(N'2026-06-23' AS Date), CAST(N'22:49:14.4168432' AS Time), N'Logout', N'Usuario', 46956657, N'27a69ka1N3v9ZtF73vRyjOlx1kXt97VuhUO+hfqiB2A=')
INSERT [dbo].[Evento] ([IdEvento], [Login], [Criticidad], [Fecha], [Hora], [NombreEvento], [Modulo], [DNI], [DVH]) VALUES (38, N'vicky', 1, CAST(N'2026-06-23' AS Date), CAST(N'22:49:18.5595984' AS Time), N'Login', N'Usuario', 12345678, N'WcHpNFjWdMcoJvSXcWzN3ibRzVNn2ZiX3MECpDndNJI=')
INSERT [dbo].[Evento] ([IdEvento], [Login], [Criticidad], [Fecha], [Hora], [NombreEvento], [Modulo], [DNI], [DVH]) VALUES (39, N'vicky', 1, CAST(N'2026-06-23' AS Date), CAST(N'22:49:28.3927325' AS Time), N'Logout', N'Usuario', 12345678, N'yd0ChvBnX70EqS/AW1Z+AG5wlgDhJjA/PluC8mQxe3A=')
INSERT [dbo].[Evento] ([IdEvento], [Login], [Criticidad], [Fecha], [Hora], [NombreEvento], [Modulo], [DNI], [DVH]) VALUES (40, N'sofigesualdo', 1, CAST(N'2026-06-23' AS Date), CAST(N'22:56:28.4496246' AS Time), N'Login', N'Usuario', 46956657, N'3H6iPcWGoOjdRgmGhobmUmYabmYds64P18fw4ubmSvI=')
INSERT [dbo].[Evento] ([IdEvento], [Login], [Criticidad], [Fecha], [Hora], [NombreEvento], [Modulo], [DNI], [DVH]) VALUES (41, N'sofigesualdo', 1, CAST(N'2026-06-23' AS Date), CAST(N'22:56:44.7778125' AS Time), N'Logout', N'Usuario', 46956657, N'bK2bUZwI24pU12z3URiBZcrEoCeGetYGxY4ICTMFILA=')
INSERT [dbo].[Evento] ([IdEvento], [Login], [Criticidad], [Fecha], [Hora], [NombreEvento], [Modulo], [DNI], [DVH]) VALUES (42, N'vicky', 1, CAST(N'2026-06-23' AS Date), CAST(N'22:56:51.5981864' AS Time), N'Login', N'Usuario', 12345678, N'nBguxBVoXAeRYz/zmVgqpRoddStE3zlXtIKemO2VrpA=')
INSERT [dbo].[Evento] ([IdEvento], [Login], [Criticidad], [Fecha], [Hora], [NombreEvento], [Modulo], [DNI], [DVH]) VALUES (43, N'vicky', 1, CAST(N'2026-06-23' AS Date), CAST(N'22:57:40.8721358' AS Time), N'Logout', N'Usuario', 12345678, N'7AnN8cabmhXQ33YgRZhV2XL75a2hVFB8ki9+KfwReOI=')
INSERT [dbo].[Evento] ([IdEvento], [Login], [Criticidad], [Fecha], [Hora], [NombreEvento], [Modulo], [DNI], [DVH]) VALUES (44, N'sofigesualdo', 1, CAST(N'2026-06-24' AS Date), CAST(N'15:15:33.4202349' AS Time), N'Login', N'Usuario', 46956657, N'dDxpNQl3V/A6AiW1WPzhvxvAC++XCunsyVmLuzFCocQ=')
INSERT [dbo].[Evento] ([IdEvento], [Login], [Criticidad], [Fecha], [Hora], [NombreEvento], [Modulo], [DNI], [DVH]) VALUES (45, N'sofigesualdo', 1, CAST(N'2026-06-24' AS Date), CAST(N'15:15:45.6436160' AS Time), N'Logout', N'Usuario', 46956657, N'5y774OZ6yCbNWbpW2qeNubnQW/HRxz8oNUuYqONQJSg=')
INSERT [dbo].[Evento] ([IdEvento], [Login], [Criticidad], [Fecha], [Hora], [NombreEvento], [Modulo], [DNI], [DVH]) VALUES (46, N'vicky', 1, CAST(N'2026-06-24' AS Date), CAST(N'15:15:50.4960986' AS Time), N'Login', N'Usuario', 12345678, N'vA3Z9OQN5t7n9WTBgjr6kYpnO660LW3A67TfurEw2WQ=')
INSERT [dbo].[Evento] ([IdEvento], [Login], [Criticidad], [Fecha], [Hora], [NombreEvento], [Modulo], [DNI], [DVH]) VALUES (47, N'vicky', 1, CAST(N'2026-06-24' AS Date), CAST(N'15:15:59.9703062' AS Time), N'Logout', N'Usuario', 12345678, N'/CGXiz4MEIK+oBumIjd6A1slDKHZCQyK6ng/eewXBfw=')
INSERT [dbo].[Evento] ([IdEvento], [Login], [Criticidad], [Fecha], [Hora], [NombreEvento], [Modulo], [DNI], [DVH]) VALUES (48, N'sofigesualdo', 1, CAST(N'2026-06-24' AS Date), CAST(N'15:32:12.5991445' AS Time), N'Login', N'Usuario', 46956657, N'0UktLwV2iPoMRgzh74gwTewUk/W1WW8+K3fE9oc6LOw=')
INSERT [dbo].[Evento] ([IdEvento], [Login], [Criticidad], [Fecha], [Hora], [NombreEvento], [Modulo], [DNI], [DVH]) VALUES (49, N'vicky', 1, CAST(N'2026-06-24' AS Date), CAST(N'15:32:31.3734088' AS Time), N'Login', N'Usuario', 12345678, N'VVbczS8d5aE4zIg4VAU0U+WlsRoIc6g311UyoXkV3f4=')
INSERT [dbo].[Evento] ([IdEvento], [Login], [Criticidad], [Fecha], [Hora], [NombreEvento], [Modulo], [DNI], [DVH]) VALUES (50, N'vicky', 1, CAST(N'2026-06-24' AS Date), CAST(N'15:47:42.1440588' AS Time), N'Login', N'Usuario', 12345678, N'CcVbNi7A5mpSKme79cCoDOU/DpVFMrVMvp4pJMqNj5c=')
INSERT [dbo].[Evento] ([IdEvento], [Login], [Criticidad], [Fecha], [Hora], [NombreEvento], [Modulo], [DNI], [DVH]) VALUES (51, N'vicky', 1, CAST(N'2026-06-24' AS Date), CAST(N'15:48:38.6068028' AS Time), N'Logout', N'Usuario', 12345678, N'HDNSeOeBxacLx103ZpTyuxG0heotxQxbDZSZU3uW0BY=')
INSERT [dbo].[Evento] ([IdEvento], [Login], [Criticidad], [Fecha], [Hora], [NombreEvento], [Modulo], [DNI], [DVH]) VALUES (52, N'vicky', 1, CAST(N'2026-06-24' AS Date), CAST(N'15:54:10.2252488' AS Time), N'Login', N'Usuario', 12345678, N'0minWMtmCmylnPWo42ahVlrpt7ykF0HQ4SWGArjLqnU=')
INSERT [dbo].[Evento] ([IdEvento], [Login], [Criticidad], [Fecha], [Hora], [NombreEvento], [Modulo], [DNI], [DVH]) VALUES (53, N'vicky', 1, CAST(N'2026-06-24' AS Date), CAST(N'16:01:13.0704958' AS Time), N'Login', N'Usuario', 12345678, N'qrlUdeOPpWJzfequbB0jqjbx0RVM0AZqg9xol2bSYzY=')
INSERT [dbo].[Evento] ([IdEvento], [Login], [Criticidad], [Fecha], [Hora], [NombreEvento], [Modulo], [DNI], [DVH]) VALUES (54, N'vicky', 1, CAST(N'2026-06-24' AS Date), CAST(N'16:21:03.8119974' AS Time), N'Login', N'Usuario', 12345678, N'sGHRYVLoCtIGvyy6zT0GkfH2KyzZzAFhmbxNIcaJEto=')
INSERT [dbo].[Evento] ([IdEvento], [Login], [Criticidad], [Fecha], [Hora], [NombreEvento], [Modulo], [DNI], [DVH]) VALUES (55, N'vicky', 1, CAST(N'2026-06-24' AS Date), CAST(N'16:21:37.3959759' AS Time), N'Logout', N'Usuario', 12345678, N'zf8Uswc4hOKq/c5l1MxZ3vatFKj2Qla9edqCk3wdSkQ=')
INSERT [dbo].[Evento] ([IdEvento], [Login], [Criticidad], [Fecha], [Hora], [NombreEvento], [Modulo], [DNI], [DVH]) VALUES (56, N'vicky', 1, CAST(N'2026-06-24' AS Date), CAST(N'16:42:54.6716087' AS Time), N'Login', N'Usuario', 12345678, N'nsp+Iaeyif2AW2rLGn4vAofsF4GgXEeLgq+62Fz9kZc=')
INSERT [dbo].[Evento] ([IdEvento], [Login], [Criticidad], [Fecha], [Hora], [NombreEvento], [Modulo], [DNI], [DVH]) VALUES (57, N'vicky', 1, CAST(N'2026-06-24' AS Date), CAST(N'16:43:41.6712666' AS Time), N'Creación de nueva Familia', N'Perfiles', 12345678, N'B0TIJ8p9pOsYwRiKjoNj3ussuAaEPYgnK3vQvw832UY=')
INSERT [dbo].[Evento] ([IdEvento], [Login], [Criticidad], [Fecha], [Hora], [NombreEvento], [Modulo], [DNI], [DVH]) VALUES (58, N'vicky', 1, CAST(N'2026-06-24' AS Date), CAST(N'16:44:46.1192436' AS Time), N'Creación de nuevo Perfil', N'Perfiles', 12345678, N'oT28/A9ypciNFO0AoBdyEsn7ZVBrNPEhQFCX3TvfHPk=')
INSERT [dbo].[Evento] ([IdEvento], [Login], [Criticidad], [Fecha], [Hora], [NombreEvento], [Modulo], [DNI], [DVH]) VALUES (59, N'vicky', 1, CAST(N'2026-06-24' AS Date), CAST(N'16:45:00.8269726' AS Time), N'Logout', N'Usuario', 12345678, N'qfGVYJ5htUkWMbKzV4KEp16x8ta2azMbc96y0pushl4=')
INSERT [dbo].[Evento] ([IdEvento], [Login], [Criticidad], [Fecha], [Hora], [NombreEvento], [Modulo], [DNI], [DVH]) VALUES (60, N'vicky', 1, CAST(N'2026-06-24' AS Date), CAST(N'16:45:16.4955467' AS Time), N'Login', N'Usuario', 12345678, N'lZUxhTf2G3A22kieiJ9pBSGDNdT6ICeOI/SYCA3Iasc=')
INSERT [dbo].[Evento] ([IdEvento], [Login], [Criticidad], [Fecha], [Hora], [NombreEvento], [Modulo], [DNI], [DVH]) VALUES (61, N'vicky', 1, CAST(N'2026-06-24' AS Date), CAST(N'16:57:27.2756367' AS Time), N'Login', N'Usuario', 12345678, N'7JHoIflV533lJ6DVnWlVlEUpH8kLOI2GPBiIU93SW3s=')
INSERT [dbo].[Evento] ([IdEvento], [Login], [Criticidad], [Fecha], [Hora], [NombreEvento], [Modulo], [DNI], [DVH]) VALUES (62, N'vicky', 1, CAST(N'2026-06-24' AS Date), CAST(N'16:57:59.2815523' AS Time), N'Creación de nueva Familia', N'Perfiles', 12345678, N'tZl/e3cm5jhgVtBvA911ITTjtaDg5LW3ukThvUXWqN0=')
INSERT [dbo].[Evento] ([IdEvento], [Login], [Criticidad], [Fecha], [Hora], [NombreEvento], [Modulo], [DNI], [DVH]) VALUES (63, N'vicky', 1, CAST(N'2026-06-24' AS Date), CAST(N'16:58:26.7251236' AS Time), N'Creación de nueva Familia', N'Perfiles', 12345678, N'aRjxOSLNYAh7kdp9bFb5//0Hql9Okr64qInixepKZi8=')
INSERT [dbo].[Evento] ([IdEvento], [Login], [Criticidad], [Fecha], [Hora], [NombreEvento], [Modulo], [DNI], [DVH]) VALUES (64, N'vicky', 1, CAST(N'2026-06-24' AS Date), CAST(N'16:59:56.6676756' AS Time), N'Creación de nueva Familia', N'Perfiles', 12345678, N'dgqtgA1KycP3f8plB4wKFwQ9ohJh6eUa09jCO1QiPyA=')
INSERT [dbo].[Evento] ([IdEvento], [Login], [Criticidad], [Fecha], [Hora], [NombreEvento], [Modulo], [DNI], [DVH]) VALUES (65, N'vicky', 1, CAST(N'2026-06-24' AS Date), CAST(N'17:01:31.8564930' AS Time), N'Login', N'Usuario', 12345678, N'7Ahhq5xkDdgFcbB57yNlfzEA9DHxAdT2LqIbg1YX1Hc=')
INSERT [dbo].[Evento] ([IdEvento], [Login], [Criticidad], [Fecha], [Hora], [NombreEvento], [Modulo], [DNI], [DVH]) VALUES (66, N'vicky', 1, CAST(N'2026-06-24' AS Date), CAST(N'17:01:55.1779001' AS Time), N'Creación de nuevo Perfil', N'Perfiles', 12345678, N'Yg41T736gduUgwkI/VtoVKVb8YsyfDpMp1EkxmzkcrU=')
INSERT [dbo].[Evento] ([IdEvento], [Login], [Criticidad], [Fecha], [Hora], [NombreEvento], [Modulo], [DNI], [DVH]) VALUES (67, N'vicky', 1, CAST(N'2026-06-24' AS Date), CAST(N'17:03:32.6346729' AS Time), N'Login', N'Usuario', 12345678, N'w3TM/+WjisksFFbQoshm2bTAac5F/0b4cqeQ+feXcO0=')
INSERT [dbo].[Evento] ([IdEvento], [Login], [Criticidad], [Fecha], [Hora], [NombreEvento], [Modulo], [DNI], [DVH]) VALUES (68, N'vicky', 1, CAST(N'2026-06-24' AS Date), CAST(N'17:03:47.6485948' AS Time), N'Creación de nuevo Perfil', N'Perfiles', 12345678, N'j2k2WwgSewabvjxQ2vWBdNE0QddaDlkzPTYwec4BY18=')
INSERT [dbo].[Evento] ([IdEvento], [Login], [Criticidad], [Fecha], [Hora], [NombreEvento], [Modulo], [DNI], [DVH]) VALUES (69, N'vicky', 1, CAST(N'2026-06-24' AS Date), CAST(N'17:04:38.6056526' AS Time), N'Logout', N'Usuario', 12345678, N'YLTvj+sZEksdaYDnX4RKEXNG+P9KKGY/6+V0twhWEpQ=')
INSERT [dbo].[Evento] ([IdEvento], [Login], [Criticidad], [Fecha], [Hora], [NombreEvento], [Modulo], [DNI], [DVH]) VALUES (70, N'vicky', 1, CAST(N'2026-06-24' AS Date), CAST(N'17:16:00.7206846' AS Time), N'Login', N'Usuario', 12345678, N'jK1Z6KnGa8S7rKqKZHv0WIpW4W5l81cJflrd5n7titw=')
INSERT [dbo].[Evento] ([IdEvento], [Login], [Criticidad], [Fecha], [Hora], [NombreEvento], [Modulo], [DNI], [DVH]) VALUES (71, N'vicky', 1, CAST(N'2026-06-24' AS Date), CAST(N'17:16:17.0199482' AS Time), N'Eliminación de Perfil', N'Perfiles', 12345678, N'iDekDwSLWADNmAoUNj2TXLN9PHrgd5X3sV1BT7V/YxQ=')
INSERT [dbo].[Evento] ([IdEvento], [Login], [Criticidad], [Fecha], [Hora], [NombreEvento], [Modulo], [DNI], [DVH]) VALUES (72, N'vicky', 1, CAST(N'2026-06-24' AS Date), CAST(N'17:16:38.0199949' AS Time), N'Eliminación de Familia', N'Perfiles', 12345678, N'8qmYKI/CUuV5S214rMftXwr0bKG30yqSZdq4lmGvtFY=')
INSERT [dbo].[Evento] ([IdEvento], [Login], [Criticidad], [Fecha], [Hora], [NombreEvento], [Modulo], [DNI], [DVH]) VALUES (73, N'vicky', 1, CAST(N'2026-06-24' AS Date), CAST(N'17:16:49.4370590' AS Time), N'Eliminación de Familia', N'Perfiles', 12345678, N'TFEskamjy7YmqDwKFNHrEP+FxZ0Rjyed3P9ObVRqTx0=')
INSERT [dbo].[Evento] ([IdEvento], [Login], [Criticidad], [Fecha], [Hora], [NombreEvento], [Modulo], [DNI], [DVH]) VALUES (74, N'vicky', 1, CAST(N'2026-06-24' AS Date), CAST(N'17:17:18.9390027' AS Time), N'Logout', N'Usuario', 12345678, N'PguRouqrw8buBOjB73TJqbclhoJfpvU8HwKI4mguDJA=')
INSERT [dbo].[Evento] ([IdEvento], [Login], [Criticidad], [Fecha], [Hora], [NombreEvento], [Modulo], [DNI], [DVH]) VALUES (75, N'vicky', 1, CAST(N'2026-06-24' AS Date), CAST(N'17:33:19.9213459' AS Time), N'Login', N'Usuario', 12345678, N'gqVNj3TuCasuCqAIcMCwDLCKJt5aq+JA6NX/hTFd/Ic=')
INSERT [dbo].[Evento] ([IdEvento], [Login], [Criticidad], [Fecha], [Hora], [NombreEvento], [Modulo], [DNI], [DVH]) VALUES (76, N'vicky', 1, CAST(N'2026-06-24' AS Date), CAST(N'17:34:08.4947770' AS Time), N'Creación de nuevo Perfil', N'Perfiles', 12345678, N'aZkthWqPwCJmWuz8pVcebvyDhxk7cwdFRzq9RrRTzsk=')
INSERT [dbo].[Evento] ([IdEvento], [Login], [Criticidad], [Fecha], [Hora], [NombreEvento], [Modulo], [DNI], [DVH]) VALUES (77, N'vicky', 1, CAST(N'2026-06-24' AS Date), CAST(N'17:34:22.4808413' AS Time), N'Eliminación de Familia', N'Perfiles', 12345678, N'0+p3FL+4dJnLETperwsSmb1mnLNwhLX0Kv43cDcrYEc=')
INSERT [dbo].[Evento] ([IdEvento], [Login], [Criticidad], [Fecha], [Hora], [NombreEvento], [Modulo], [DNI], [DVH]) VALUES (78, N'vicky', 1, CAST(N'2026-06-24' AS Date), CAST(N'17:34:31.4135940' AS Time), N'Eliminación de Perfil', N'Perfiles', 12345678, N'HlqiKf4N+hfCGYHeSm0bEEdREcuY1VzqGqtH7jAFSMA=')
INSERT [dbo].[Evento] ([IdEvento], [Login], [Criticidad], [Fecha], [Hora], [NombreEvento], [Modulo], [DNI], [DVH]) VALUES (79, N'vicky', 1, CAST(N'2026-06-24' AS Date), CAST(N'17:51:52.1131470' AS Time), N'Login', N'Usuario', 12345678, N'YCn5To2ht+xQif+QYQjC4VMotFyoL2LAtmN1h/AycuU=')
INSERT [dbo].[Evento] ([IdEvento], [Login], [Criticidad], [Fecha], [Hora], [NombreEvento], [Modulo], [DNI], [DVH]) VALUES (80, N'vicky', 1, CAST(N'2026-06-24' AS Date), CAST(N'17:52:12.8532009' AS Time), N'Modificación Perfil', N'Perfiles', 12345678, N'8tMclTleCUJkr5HjE6JUsOwFKO5ffVsupGFZv3mYL20=')
INSERT [dbo].[Evento] ([IdEvento], [Login], [Criticidad], [Fecha], [Hora], [NombreEvento], [Modulo], [DNI], [DVH]) VALUES (81, N'vicky', 1, CAST(N'2026-06-24' AS Date), CAST(N'17:53:08.3216068' AS Time), N'Modificación Perfil', N'Perfiles', 12345678, N'MTCnwx0RCtPOHUkJ+rtJEbMmqZm5mR/+zcq5s+ZYEGw=')
INSERT [dbo].[Evento] ([IdEvento], [Login], [Criticidad], [Fecha], [Hora], [NombreEvento], [Modulo], [DNI], [DVH]) VALUES (82, N'vicky', 1, CAST(N'2026-06-24' AS Date), CAST(N'17:53:15.5662570' AS Time), N'Modificación Perfil', N'Perfiles', 12345678, N'dcK/1BC9ugIV2DKhQAG8sgc9RvpBg+Exst2OOcYQ08s=')
INSERT [dbo].[Evento] ([IdEvento], [Login], [Criticidad], [Fecha], [Hora], [NombreEvento], [Modulo], [DNI], [DVH]) VALUES (83, N'vicky', 1, CAST(N'2026-06-24' AS Date), CAST(N'17:53:22.3162845' AS Time), N'Modificación Perfil', N'Perfiles', 12345678, N'VjqL1bq1KFQTU1C5uoza/SXPEZcwDEirtRYh4kRzr68=')
INSERT [dbo].[Evento] ([IdEvento], [Login], [Criticidad], [Fecha], [Hora], [NombreEvento], [Modulo], [DNI], [DVH]) VALUES (84, N'vicky', 1, CAST(N'2026-06-24' AS Date), CAST(N'17:55:29.0787413' AS Time), N'Modificación Perfil', N'Perfiles', 12345678, N'4xR9I/u9bGrfan+C/Qbs5kBuqGeLnqt+cBwMgIEBW4Q=')
INSERT [dbo].[Evento] ([IdEvento], [Login], [Criticidad], [Fecha], [Hora], [NombreEvento], [Modulo], [DNI], [DVH]) VALUES (85, N'vicky', 1, CAST(N'2026-06-24' AS Date), CAST(N'17:55:29.0853080' AS Time), N'Modificación Perfil', N'Perfiles', 12345678, N'VKkXFO77y0kJHw4OSSEwXVfkGZOaZO9u7l1v5WDXmHM=')
INSERT [dbo].[Evento] ([IdEvento], [Login], [Criticidad], [Fecha], [Hora], [NombreEvento], [Modulo], [DNI], [DVH]) VALUES (86, N'vicky', 1, CAST(N'2026-06-24' AS Date), CAST(N'17:55:37.1258725' AS Time), N'Modificación Perfil', N'Perfiles', 12345678, N'r532noYnZJ0JkR+LldiaEUQZxK6m3f+Gw6KPNZstN4A=')
INSERT [dbo].[Evento] ([IdEvento], [Login], [Criticidad], [Fecha], [Hora], [NombreEvento], [Modulo], [DNI], [DVH]) VALUES (87, N'vicky', 1, CAST(N'2026-06-24' AS Date), CAST(N'18:30:42.0558584' AS Time), N'Login', N'Usuario', 12345678, N'fDJVpjy6zWnLII3f5gvVuNFXJiIrmtLbHpDtYyssldY=')
INSERT [dbo].[Evento] ([IdEvento], [Login], [Criticidad], [Fecha], [Hora], [NombreEvento], [Modulo], [DNI], [DVH]) VALUES (88, N'vicky', 1, CAST(N'2026-06-24' AS Date), CAST(N'18:30:55.7469659' AS Time), N'Modificación Perfil', N'Perfiles', 12345678, N'mh0ZRkeZP5KBWpQCkj3ZOxma5Ht0ba2feSUEXMdOPHg=')
INSERT [dbo].[Evento] ([IdEvento], [Login], [Criticidad], [Fecha], [Hora], [NombreEvento], [Modulo], [DNI], [DVH]) VALUES (89, N'vicky', 1, CAST(N'2026-06-24' AS Date), CAST(N'18:31:10.9668660' AS Time), N'Modificación Perfil', N'Perfiles', 12345678, N'ZboQldYrO20MnlgFwprKgMSVfAmTN9nWknl4oVxumDQ=')
INSERT [dbo].[Evento] ([IdEvento], [Login], [Criticidad], [Fecha], [Hora], [NombreEvento], [Modulo], [DNI], [DVH]) VALUES (90, N'vicky', 1, CAST(N'2026-06-24' AS Date), CAST(N'18:31:34.8335487' AS Time), N'Logout', N'Usuario', 12345678, N'qJE+0zb81+Al0cvjIy2tObT9xT4PHC/Veb7HUBv/jkg=')
INSERT [dbo].[Evento] ([IdEvento], [Login], [Criticidad], [Fecha], [Hora], [NombreEvento], [Modulo], [DNI], [DVH]) VALUES (91, N'vicky', 1, CAST(N'2026-06-24' AS Date), CAST(N'18:35:17.6570901' AS Time), N'Login', N'Usuario', 12345678, N'NGGzefybMm/+xa+PhPQKLahXCu5Ff+qbKOyo+n6qN5M=')
INSERT [dbo].[Evento] ([IdEvento], [Login], [Criticidad], [Fecha], [Hora], [NombreEvento], [Modulo], [DNI], [DVH]) VALUES (92, N'vicky', 1, CAST(N'2026-06-24' AS Date), CAST(N'18:55:30.6232798' AS Time), N'Login', N'Usuario', 12345678, N'LuFpDe4foLL1bU0AB9L6t0SjKbS0wWU/i8ZzzwdTr8g=')
INSERT [dbo].[Evento] ([IdEvento], [Login], [Criticidad], [Fecha], [Hora], [NombreEvento], [Modulo], [DNI], [DVH]) VALUES (93, N'vicky', 1, CAST(N'2026-06-24' AS Date), CAST(N'18:59:15.3858307' AS Time), N'Login', N'Usuario', 12345678, N'Eyh12rGcuEc0E7BIRWCl+4esWyZeem9MbqHMYDak2O4=')
INSERT [dbo].[Evento] ([IdEvento], [Login], [Criticidad], [Fecha], [Hora], [NombreEvento], [Modulo], [DNI], [DVH]) VALUES (94, N'vicky', 1, CAST(N'2026-06-24' AS Date), CAST(N'18:59:35.8999732' AS Time), N'Modificación Familia', N'Perfiles', 12345678, N'pp71esRL3T0q6fKoBvXYmjMY+ig8l8bUFAOscUPf6Cg=')
INSERT [dbo].[Evento] ([IdEvento], [Login], [Criticidad], [Fecha], [Hora], [NombreEvento], [Modulo], [DNI], [DVH]) VALUES (95, N'vicky', 1, CAST(N'2026-06-24' AS Date), CAST(N'19:00:14.9686662' AS Time), N'Logout', N'Usuario', 12345678, N'mQeMDfFld8s8oKfzp5CN87e/dY+S02HLFQYWQTBpbA4=')
INSERT [dbo].[Evento] ([IdEvento], [Login], [Criticidad], [Fecha], [Hora], [NombreEvento], [Modulo], [DNI], [DVH]) VALUES (96, N'vicky', 1, CAST(N'2026-06-24' AS Date), CAST(N'19:09:26.0761901' AS Time), N'Login', N'Usuario', 12345678, N'Ehv/8odLSQWw8fVp5AhwlHtTDnTsVRQqApypV2HLkBA=')
INSERT [dbo].[Evento] ([IdEvento], [Login], [Criticidad], [Fecha], [Hora], [NombreEvento], [Modulo], [DNI], [DVH]) VALUES (97, N'vicky', 1, CAST(N'2026-06-24' AS Date), CAST(N'19:10:23.7666356' AS Time), N'Login', N'Usuario', 12345678, N'+GUMls9cpaRQjJGe05e7g9mVvCFdDZVCy76K+lumspI=')
INSERT [dbo].[Evento] ([IdEvento], [Login], [Criticidad], [Fecha], [Hora], [NombreEvento], [Modulo], [DNI], [DVH]) VALUES (98, N'vicky', 1, CAST(N'2026-06-24' AS Date), CAST(N'19:12:45.6854654' AS Time), N'Login', N'Usuario', 12345678, N'c/a4rUgcYxpM6OeZDuP/d0uwnLx+kQa0FHeIHB0Cg70=')
INSERT [dbo].[Evento] ([IdEvento], [Login], [Criticidad], [Fecha], [Hora], [NombreEvento], [Modulo], [DNI], [DVH]) VALUES (99, N'vicky', 1, CAST(N'2026-06-24' AS Date), CAST(N'19:13:13.6885778' AS Time), N'Creación de nueva Familia', N'Perfiles', 12345678, N'UmzyK12938As4XhOBdnJ6H3huVhkXYJbeUmGDxF7fbs=')
INSERT [dbo].[Evento] ([IdEvento], [Login], [Criticidad], [Fecha], [Hora], [NombreEvento], [Modulo], [DNI], [DVH]) VALUES (100, N'vicky', 1, CAST(N'2026-06-24' AS Date), CAST(N'19:17:10.2197349' AS Time), N'Login', N'Usuario', 12345678, N'rsnmn2WR+G7KTXzl1+11NXbO8+mCkNvwosrnDSdxkTQ=')
GO
INSERT [dbo].[Evento] ([IdEvento], [Login], [Criticidad], [Fecha], [Hora], [NombreEvento], [Modulo], [DNI], [DVH]) VALUES (101, N'vicky', 1, CAST(N'2026-06-24' AS Date), CAST(N'19:18:54.0338544' AS Time), N'Login', N'Usuario', 12345678, N'tZxgxni612ZfNXSFZCtYlyPnM5Z4yr3kWp+6foivq/0=')
INSERT [dbo].[Evento] ([IdEvento], [Login], [Criticidad], [Fecha], [Hora], [NombreEvento], [Modulo], [DNI], [DVH]) VALUES (102, N'vicky', 1, CAST(N'2026-06-24' AS Date), CAST(N'19:22:16.2967125' AS Time), N'Login', N'Usuario', 12345678, N'IVkgMWQZA6YDXGR60dvzKaNc4Q745uKVXUMl5FgRPOo=')
INSERT [dbo].[Evento] ([IdEvento], [Login], [Criticidad], [Fecha], [Hora], [NombreEvento], [Modulo], [DNI], [DVH]) VALUES (103, N'vicky', 1, CAST(N'2026-06-24' AS Date), CAST(N'19:23:37.0275643' AS Time), N'Creación de nueva Familia', N'Perfiles', 12345678, N'COhzg5Y+TGdDiD6Mt01mOTFjlMPdt96+3IZjVDziqD4=')
INSERT [dbo].[Evento] ([IdEvento], [Login], [Criticidad], [Fecha], [Hora], [NombreEvento], [Modulo], [DNI], [DVH]) VALUES (104, N'vicky', 1, CAST(N'2026-06-24' AS Date), CAST(N'19:34:46.1421988' AS Time), N'Login', N'Usuario', 12345678, N'huHOFLxrSHS7snAffNcKi+n4K34uNDcFwu9Szw6Jpp8=')
INSERT [dbo].[Evento] ([IdEvento], [Login], [Criticidad], [Fecha], [Hora], [NombreEvento], [Modulo], [DNI], [DVH]) VALUES (105, N'vicky', 1, CAST(N'2026-06-24' AS Date), CAST(N'19:34:58.4114842' AS Time), N'Modificación Perfil', N'Perfiles', 12345678, N'c7topyh9yduPGWKyjwWAwS3COipzIWLhDLctCbC63as=')
INSERT [dbo].[Evento] ([IdEvento], [Login], [Criticidad], [Fecha], [Hora], [NombreEvento], [Modulo], [DNI], [DVH]) VALUES (106, N'vicky', 1, CAST(N'2026-06-24' AS Date), CAST(N'19:35:19.5138121' AS Time), N'Eliminación de Familia', N'Perfiles', 12345678, N'EyE05eQpy5EpFUGq/I436AD6xZ5s8OrJgWBkvqccPFA=')
INSERT [dbo].[Evento] ([IdEvento], [Login], [Criticidad], [Fecha], [Hora], [NombreEvento], [Modulo], [DNI], [DVH]) VALUES (107, N'vicky', 1, CAST(N'2026-06-24' AS Date), CAST(N'19:35:45.9398666' AS Time), N'Creación de nueva Familia', N'Perfiles', 12345678, N'agJw2F1wwfzFbnU+YAIMPF0hUmbv38d32M2ELDW99Sg=')
INSERT [dbo].[Evento] ([IdEvento], [Login], [Criticidad], [Fecha], [Hora], [NombreEvento], [Modulo], [DNI], [DVH]) VALUES (108, N'vicky', 1, CAST(N'2026-06-24' AS Date), CAST(N'19:35:54.2339636' AS Time), N'Modificación Perfil', N'Perfiles', 12345678, N'I0z/1hemFpLwlUgw7nt+WDgvDw8LUktWpFQreAw3xMg=')
INSERT [dbo].[Evento] ([IdEvento], [Login], [Criticidad], [Fecha], [Hora], [NombreEvento], [Modulo], [DNI], [DVH]) VALUES (109, N'vicky', 1, CAST(N'2026-06-24' AS Date), CAST(N'19:36:13.5146864' AS Time), N'Modificación Perfil', N'Perfiles', 12345678, N'w+Bf2kwgOOK1Wrz0jLfvD1bqz3gRSlDVGbQrA+QNiC0=')
INSERT [dbo].[Evento] ([IdEvento], [Login], [Criticidad], [Fecha], [Hora], [NombreEvento], [Modulo], [DNI], [DVH]) VALUES (110, N'vicky', 1, CAST(N'2026-06-24' AS Date), CAST(N'19:36:20.5166123' AS Time), N'Logout', N'Usuario', 12345678, N'6E/NCx8Ip2zOx8iRhAIvINOebc9rznpDdD8WrhlPJ0I=')
INSERT [dbo].[Evento] ([IdEvento], [Login], [Criticidad], [Fecha], [Hora], [NombreEvento], [Modulo], [DNI], [DVH]) VALUES (111, N'vicky', 1, CAST(N'2026-06-25' AS Date), CAST(N'11:31:00.0955583' AS Time), N'Login', N'Usuario', 12345678, N'T7qemQ5dJ5G7Y2UQCXXvEeotHRl/vWQlDzLGPizzEW8=')
INSERT [dbo].[Evento] ([IdEvento], [Login], [Criticidad], [Fecha], [Hora], [NombreEvento], [Modulo], [DNI], [DVH]) VALUES (112, N'vicky', 1, CAST(N'2026-06-25' AS Date), CAST(N'11:31:03.8228621' AS Time), N'Cambio de Idioma', N'Idioma cambiado con éxito', 12345678, N'eFbwBGGmApd8lrJdUkDcp0kSXqsPs3d6x0tBt4WJjGM=')
INSERT [dbo].[Evento] ([IdEvento], [Login], [Criticidad], [Fecha], [Hora], [NombreEvento], [Modulo], [DNI], [DVH]) VALUES (113, N'vicky', 1, CAST(N'2026-06-25' AS Date), CAST(N'11:31:43.5362086' AS Time), N'Cambio de Idioma', N'Idioma cambiado con éxito', 12345678, N'wSHW2HlXQoObnlfDkYRd75rIZr1GLW0ZzYWiFk4vBAA=')
INSERT [dbo].[Evento] ([IdEvento], [Login], [Criticidad], [Fecha], [Hora], [NombreEvento], [Modulo], [DNI], [DVH]) VALUES (114, N'vicky', 1, CAST(N'2026-06-25' AS Date), CAST(N'11:44:25.7599767' AS Time), N'Login', N'Usuario', 12345678, N'hHGjoXgFnFfA8pXlE+iXAzFyH4IssOi2VMNuG8mc08Q=')
INSERT [dbo].[Evento] ([IdEvento], [Login], [Criticidad], [Fecha], [Hora], [NombreEvento], [Modulo], [DNI], [DVH]) VALUES (115, N'vicky', 1, CAST(N'2026-06-25' AS Date), CAST(N'11:50:22.1012961' AS Time), N'Login', N'Usuario', 12345678, N'xPYzM1BiTZ78uUp717HvxpnWS+Rx+qTYi7guQnyjF5E=')
INSERT [dbo].[Evento] ([IdEvento], [Login], [Criticidad], [Fecha], [Hora], [NombreEvento], [Modulo], [DNI], [DVH]) VALUES (116, N'vicky', 1, CAST(N'2026-06-25' AS Date), CAST(N'11:50:26.2189007' AS Time), N'Cambio de Idioma', N'Idioma cambiado con éxito', 12345678, N'D+RYFOPaO2UGKjNyqBw/nlmBVqUUImQyUx5kuLmUeyI=')
INSERT [dbo].[Evento] ([IdEvento], [Login], [Criticidad], [Fecha], [Hora], [NombreEvento], [Modulo], [DNI], [DVH]) VALUES (117, N'vicky', 1, CAST(N'2026-06-25' AS Date), CAST(N'12:09:23.9173881' AS Time), N'Login', N'Usuario', 12345678, N'O8xJlioj9Pv/GiUKzQdt7JbgpLQToFB9dV2g6VcQOZ8=')
INSERT [dbo].[Evento] ([IdEvento], [Login], [Criticidad], [Fecha], [Hora], [NombreEvento], [Modulo], [DNI], [DVH]) VALUES (118, N'vicky', 1, CAST(N'2026-06-25' AS Date), CAST(N'12:09:27.3561512' AS Time), N'Cambio de Idioma', N'Idioma cambiado con éxito', 12345678, N'09/YKVnAAES+sG1mzuJ3rw9KPcvsHrr0/Fwlh/MnqAU=')
INSERT [dbo].[Evento] ([IdEvento], [Login], [Criticidad], [Fecha], [Hora], [NombreEvento], [Modulo], [DNI], [DVH]) VALUES (119, N'vicky', 1, CAST(N'2026-06-25' AS Date), CAST(N'12:11:10.2154721' AS Time), N'Login', N'Usuario', 12345678, N'VYib9D0+0hOwT3BYQNnJQxOEskUXZLtca5pvCzFV/k4=')
INSERT [dbo].[Evento] ([IdEvento], [Login], [Criticidad], [Fecha], [Hora], [NombreEvento], [Modulo], [DNI], [DVH]) VALUES (120, N'vicky', 1, CAST(N'2026-06-25' AS Date), CAST(N'12:11:14.1522426' AS Time), N'Cambio de Idioma', N'Idioma cambiado con éxito', 12345678, N'c8aKcX0oMiBh1A0XCMyIvGLWyU1P8/lLMe55iMOdeIc=')
INSERT [dbo].[Evento] ([IdEvento], [Login], [Criticidad], [Fecha], [Hora], [NombreEvento], [Modulo], [DNI], [DVH]) VALUES (121, N'vicky', 1, CAST(N'2026-06-25' AS Date), CAST(N'12:12:11.8301166' AS Time), N'Login', N'Usuario', 12345678, N'IWSTUKNXM12e7yfjRle0HBSuR8b2dvIrPi5dioMPUfk=')
INSERT [dbo].[Evento] ([IdEvento], [Login], [Criticidad], [Fecha], [Hora], [NombreEvento], [Modulo], [DNI], [DVH]) VALUES (122, N'vicky', 1, CAST(N'2026-06-25' AS Date), CAST(N'12:12:14.4631819' AS Time), N'Cambio de Idioma', N'Idioma cambiado con éxito', 12345678, N'OykkztCLw6qzU68bdysnazaDfqgK9cprtre6dy7lRWs=')
INSERT [dbo].[Evento] ([IdEvento], [Login], [Criticidad], [Fecha], [Hora], [NombreEvento], [Modulo], [DNI], [DVH]) VALUES (123, N'vicky', 1, CAST(N'2026-06-25' AS Date), CAST(N'12:16:04.2990890' AS Time), N'Login', N'Usuario', 12345678, N'jE1zcm15D95aE4S1ofVe5bBcWJxP9WE53lkq3sdm9qU=')
INSERT [dbo].[Evento] ([IdEvento], [Login], [Criticidad], [Fecha], [Hora], [NombreEvento], [Modulo], [DNI], [DVH]) VALUES (124, N'vicky', 1, CAST(N'2026-06-25' AS Date), CAST(N'12:16:08.0857147' AS Time), N'Cambio de Idioma', N'Idioma cambiado con éxito', 12345678, N'0XZ9Z0AsHUlJGmX2rTPJcinXUvNMQGJRN2YnLMbv1Xw=')
INSERT [dbo].[Evento] ([IdEvento], [Login], [Criticidad], [Fecha], [Hora], [NombreEvento], [Modulo], [DNI], [DVH]) VALUES (125, N'vicky', 1, CAST(N'2026-06-25' AS Date), CAST(N'12:16:46.2660741' AS Time), N'Login', N'Usuario', 12345678, N'ciNbCdJ25v6AkcJ5R/nbh5lFnKO/aO9VyWFEf15IJac=')
INSERT [dbo].[Evento] ([IdEvento], [Login], [Criticidad], [Fecha], [Hora], [NombreEvento], [Modulo], [DNI], [DVH]) VALUES (126, N'vicky', 1, CAST(N'2026-06-25' AS Date), CAST(N'12:16:49.9493385' AS Time), N'Cambio de Idioma', N'Idioma cambiado con éxito', 12345678, N'qZffg2/C4fQAPU/rUNZ+XYj7jzhNEn4HFgguLyllJOk=')
INSERT [dbo].[Evento] ([IdEvento], [Login], [Criticidad], [Fecha], [Hora], [NombreEvento], [Modulo], [DNI], [DVH]) VALUES (127, N'vicky', 1, CAST(N'2026-06-25' AS Date), CAST(N'12:18:34.0188569' AS Time), N'Login', N'Usuario', 12345678, N'JJ2EIypkBvtDxdOVH28Sm/UzkangAvX0proGoQNMx6U=')
INSERT [dbo].[Evento] ([IdEvento], [Login], [Criticidad], [Fecha], [Hora], [NombreEvento], [Modulo], [DNI], [DVH]) VALUES (128, N'vicky', 1, CAST(N'2026-06-25' AS Date), CAST(N'12:18:36.2542486' AS Time), N'Cambio de Idioma', N'Idioma cambiado con éxito', 12345678, N'JsecxSdP1Wlil1fyhX4yZwD1djD9P+oSethhNBcR+5E=')
INSERT [dbo].[Evento] ([IdEvento], [Login], [Criticidad], [Fecha], [Hora], [NombreEvento], [Modulo], [DNI], [DVH]) VALUES (129, N'vicky', 1, CAST(N'2026-06-25' AS Date), CAST(N'12:30:52.3005105' AS Time), N'Login', N'Usuario', 12345678, N'qXAH7XYb6oPCBHpZle4DjqHOGE1nasaFZU18+PFiwvo=')
INSERT [dbo].[Evento] ([IdEvento], [Login], [Criticidad], [Fecha], [Hora], [NombreEvento], [Modulo], [DNI], [DVH]) VALUES (130, N'vicky', 1, CAST(N'2026-06-25' AS Date), CAST(N'12:30:55.5037221' AS Time), N'Cambio de Idioma', N'Idioma cambiado con éxito', 12345678, N'a4F4UKP9tva+gPx0r1WAIHVEk2j1iJAVDim1aluW3c0=')
INSERT [dbo].[Evento] ([IdEvento], [Login], [Criticidad], [Fecha], [Hora], [NombreEvento], [Modulo], [DNI], [DVH]) VALUES (131, N'vicky', 1, CAST(N'2026-06-25' AS Date), CAST(N'12:31:48.4657222' AS Time), N'Login', N'Usuario', 12345678, N'K2zAOuWx+48HzCPk4w6zsiaYZan2uVkIQxFem6JY+KI=')
INSERT [dbo].[Evento] ([IdEvento], [Login], [Criticidad], [Fecha], [Hora], [NombreEvento], [Modulo], [DNI], [DVH]) VALUES (132, N'vicky', 1, CAST(N'2026-06-25' AS Date), CAST(N'12:31:51.6226712' AS Time), N'Cambio de Idioma', N'Idioma cambiado con éxito', 12345678, N'aZRXpCgKZw8uWvwvlNgYDmAkeBKLQ6HPVOLgHFKrAzE=')
INSERT [dbo].[Evento] ([IdEvento], [Login], [Criticidad], [Fecha], [Hora], [NombreEvento], [Modulo], [DNI], [DVH]) VALUES (133, N'vicky', 1, CAST(N'2026-06-25' AS Date), CAST(N'12:32:36.4115902' AS Time), N'Login', N'Usuario', 12345678, N'MNFbEhij7+xXsWP2u4K6OLrL9kAPEj5E+y0njFjbs94=')
INSERT [dbo].[Evento] ([IdEvento], [Login], [Criticidad], [Fecha], [Hora], [NombreEvento], [Modulo], [DNI], [DVH]) VALUES (134, N'vicky', 1, CAST(N'2026-06-25' AS Date), CAST(N'12:32:39.6853702' AS Time), N'Cambio de Idioma', N'Idioma cambiado con éxito', 12345678, N'fZCKUQphjyYo2UbbPs8wuwtEQmfuxakXXp+fbA0NNys=')
INSERT [dbo].[Evento] ([IdEvento], [Login], [Criticidad], [Fecha], [Hora], [NombreEvento], [Modulo], [DNI], [DVH]) VALUES (135, N'vicky', 1, CAST(N'2026-06-25' AS Date), CAST(N'12:40:34.9055807' AS Time), N'Login', N'Usuario', 12345678, N'1rRZDgcCd2SmxR+C6oD0ecf8AJ8cPG5/1PX8ek1tG0w=')
INSERT [dbo].[Evento] ([IdEvento], [Login], [Criticidad], [Fecha], [Hora], [NombreEvento], [Modulo], [DNI], [DVH]) VALUES (136, N'vicky', 1, CAST(N'2026-06-25' AS Date), CAST(N'12:40:56.1182525' AS Time), N'Cambio de Idioma', N'Idioma cambiado con éxito', 12345678, N'lZIS9mVdL359qffMDef6daHccg5tiwEwZfkH+Yq/pAU=')
INSERT [dbo].[Evento] ([IdEvento], [Login], [Criticidad], [Fecha], [Hora], [NombreEvento], [Modulo], [DNI], [DVH]) VALUES (137, N'vicky', 1, CAST(N'2026-06-25' AS Date), CAST(N'13:03:35.7967721' AS Time), N'Login', N'Usuario', 12345678, N'gQi74br1v2ENteSCoeWO2/d8tYtUJVTM0RdLXconoWQ=')
INSERT [dbo].[Evento] ([IdEvento], [Login], [Criticidad], [Fecha], [Hora], [NombreEvento], [Modulo], [DNI], [DVH]) VALUES (138, N'vicky', 1, CAST(N'2026-06-25' AS Date), CAST(N'13:03:39.5976010' AS Time), N'Cambio de Idioma', N'Idioma cambiado con éxito', 12345678, N'+WYQqJAKzAy1svkdzrPS6IZRyUE3z5TSk7vIVeY2F7o=')
INSERT [dbo].[Evento] ([IdEvento], [Login], [Criticidad], [Fecha], [Hora], [NombreEvento], [Modulo], [DNI], [DVH]) VALUES (139, N'vicky', 1, CAST(N'2026-06-25' AS Date), CAST(N'13:04:46.4986539' AS Time), N'Login', N'Usuario', 12345678, N'jn5HUhyZ4PJT17G/89frRNZCR7n71P7yH7nT64TfW20=')
INSERT [dbo].[Evento] ([IdEvento], [Login], [Criticidad], [Fecha], [Hora], [NombreEvento], [Modulo], [DNI], [DVH]) VALUES (140, N'vicky', 1, CAST(N'2026-06-25' AS Date), CAST(N'13:04:49.2322205' AS Time), N'Cambio de Idioma', N'Idioma cambiado con éxito', 12345678, N'461esO9YuymdEvNH1YlTXmD4jz3XzfzWrGI46am+HFk=')
INSERT [dbo].[Evento] ([IdEvento], [Login], [Criticidad], [Fecha], [Hora], [NombreEvento], [Modulo], [DNI], [DVH]) VALUES (141, N'vicky', 1, CAST(N'2026-06-25' AS Date), CAST(N'13:06:19.6007951' AS Time), N'Login', N'Usuario', 12345678, N'HrjvsdzkTDotqZHsUWdEWbYxm6Ix/HKBvPeOn0CZuXI=')
INSERT [dbo].[Evento] ([IdEvento], [Login], [Criticidad], [Fecha], [Hora], [NombreEvento], [Modulo], [DNI], [DVH]) VALUES (142, N'vicky', 1, CAST(N'2026-06-25' AS Date), CAST(N'13:06:21.9980814' AS Time), N'Cambio de Idioma', N'Idioma cambiado con éxito', 12345678, N'5uYtY9UK5Rolw2K/acZmr8csfUM8WeqdLlovdWRpgt4=')
INSERT [dbo].[Evento] ([IdEvento], [Login], [Criticidad], [Fecha], [Hora], [NombreEvento], [Modulo], [DNI], [DVH]) VALUES (143, N'vicky', 1, CAST(N'2026-06-25' AS Date), CAST(N'13:09:36.9982632' AS Time), N'Login', N'Usuario', 12345678, N'tOGg9o9LN9LDUDXbv2/ZJLXVnyh2jqx/dPkghLeZSuA=')
INSERT [dbo].[Evento] ([IdEvento], [Login], [Criticidad], [Fecha], [Hora], [NombreEvento], [Modulo], [DNI], [DVH]) VALUES (144, N'vicky', 1, CAST(N'2026-06-25' AS Date), CAST(N'13:09:39.6233920' AS Time), N'Cambio de Idioma', N'Idioma cambiado con éxito', 12345678, N'7JNHYp9oVxugTv5jkoohmjICWDJVrWE7EV/p5oVSwqQ=')
INSERT [dbo].[Evento] ([IdEvento], [Login], [Criticidad], [Fecha], [Hora], [NombreEvento], [Modulo], [DNI], [DVH]) VALUES (145, N'vicky', 1, CAST(N'2026-06-25' AS Date), CAST(N'13:32:55.0762849' AS Time), N'Login', N'Usuario', 12345678, N'0eV04nSNZmvloJ8+/+v1Mp8u2C0RiltPdMKXN8Xed/4=')
INSERT [dbo].[Evento] ([IdEvento], [Login], [Criticidad], [Fecha], [Hora], [NombreEvento], [Modulo], [DNI], [DVH]) VALUES (146, N'vicky', 1, CAST(N'2026-06-25' AS Date), CAST(N'13:32:58.6316481' AS Time), N'Cambio de Idioma', N'Idioma cambiado con éxito', 12345678, N'ROa6sc02oM1X0BaMPPA36M76MFlrxDgBcRZZndtXE34=')
INSERT [dbo].[Evento] ([IdEvento], [Login], [Criticidad], [Fecha], [Hora], [NombreEvento], [Modulo], [DNI], [DVH]) VALUES (147, N'vicky', 1, CAST(N'2026-06-25' AS Date), CAST(N'14:21:19.7354403' AS Time), N'Login', N'Usuario', 12345678, N'gHCmaty9hGvi+lMtjnKhMTp0ioFrDENPvVG/Pln229U=')
INSERT [dbo].[Evento] ([IdEvento], [Login], [Criticidad], [Fecha], [Hora], [NombreEvento], [Modulo], [DNI], [DVH]) VALUES (148, N'vicky', 1, CAST(N'2026-06-25' AS Date), CAST(N'14:21:23.2956623' AS Time), N'Cambio de Idioma', N'Idioma cambiado con éxito', 12345678, N'RIXyxd/vXHAYBcqFtee551FZWMccBaUM//Fg7o38qBE=')
INSERT [dbo].[Evento] ([IdEvento], [Login], [Criticidad], [Fecha], [Hora], [NombreEvento], [Modulo], [DNI], [DVH]) VALUES (149, N'vicky', 1, CAST(N'2026-06-25' AS Date), CAST(N'14:24:36.1573020' AS Time), N'Login', N'Usuario', 12345678, N'VVBc6kbYmyOQWNKUe7WOMC1xprqpWoWEFSU7ltE6QlI=')
INSERT [dbo].[Evento] ([IdEvento], [Login], [Criticidad], [Fecha], [Hora], [NombreEvento], [Modulo], [DNI], [DVH]) VALUES (150, N'vicky', 1, CAST(N'2026-06-25' AS Date), CAST(N'14:25:39.4318461' AS Time), N'Login', N'Usuario', 12345678, N'nHi2qUYcDp763FY9BmHVltyj0oqC8cKQ5aBisvtpqw4=')
INSERT [dbo].[Evento] ([IdEvento], [Login], [Criticidad], [Fecha], [Hora], [NombreEvento], [Modulo], [DNI], [DVH]) VALUES (151, N'vicky', 1, CAST(N'2026-06-25' AS Date), CAST(N'14:25:41.9147979' AS Time), N'Cambio de Idioma', N'Idioma cambiado con éxito', 12345678, N'yal6jzbMzPe1Y6s3AL/TTqrmQEMhWiO9IkVNbpW84qc=')
INSERT [dbo].[Evento] ([IdEvento], [Login], [Criticidad], [Fecha], [Hora], [NombreEvento], [Modulo], [DNI], [DVH]) VALUES (152, N'vicky', 1, CAST(N'2026-06-25' AS Date), CAST(N'14:26:10.1273026' AS Time), N'Logout', N'Usuario', 12345678, N'BGz+t6UW3xNmxIYUV2/foclSLf64ffSrNagDHaIWcCE=')
INSERT [dbo].[Evento] ([IdEvento], [Login], [Criticidad], [Fecha], [Hora], [NombreEvento], [Modulo], [DNI], [DVH]) VALUES (153, N'vicky', 1, CAST(N'2026-06-25' AS Date), CAST(N'14:26:47.7574451' AS Time), N'Login', N'Usuario', 12345678, N'vq3aTX6spIjNqZiBS1LAeZGEx08wbRjrjYKyDc2KPv4=')
INSERT [dbo].[Evento] ([IdEvento], [Login], [Criticidad], [Fecha], [Hora], [NombreEvento], [Modulo], [DNI], [DVH]) VALUES (154, N'vicky', 1, CAST(N'2026-06-25' AS Date), CAST(N'14:28:00.0652396' AS Time), N'Login', N'Usuario', 12345678, N'WTJTkc3+wcL8oBUeW8v5rO9bd3z51V4nHIhwTuCUu20=')
INSERT [dbo].[Evento] ([IdEvento], [Login], [Criticidad], [Fecha], [Hora], [NombreEvento], [Modulo], [DNI], [DVH]) VALUES (155, N'vicky', 1, CAST(N'2026-06-25' AS Date), CAST(N'14:28:04.2226701' AS Time), N'Cambio de Idioma', N'Idioma cambiado con éxito', 12345678, N'XG+mxl35G33oTiCVPrHhbSWOAvpLC8ppdv8LAmV56KI=')
INSERT [dbo].[Evento] ([IdEvento], [Login], [Criticidad], [Fecha], [Hora], [NombreEvento], [Modulo], [DNI], [DVH]) VALUES (156, N'vicky', 1, CAST(N'2026-06-25' AS Date), CAST(N'14:29:02.9416754' AS Time), N'Logout', N'Usuario', 12345678, N'kkCjhScuOoXpmixzT7MdJP6fiW2nMwFni5DzITwuM0k=')
INSERT [dbo].[Evento] ([IdEvento], [Login], [Criticidad], [Fecha], [Hora], [NombreEvento], [Modulo], [DNI], [DVH]) VALUES (157, N'vicky', 1, CAST(N'2026-06-25' AS Date), CAST(N'15:31:38.6823946' AS Time), N'Login', N'Usuario', 12345678, N'nfuyZeNlW/898BiwlfaFGfvTfgWoZHxh3NsVmzwpeCY=')
INSERT [dbo].[Evento] ([IdEvento], [Login], [Criticidad], [Fecha], [Hora], [NombreEvento], [Modulo], [DNI], [DVH]) VALUES (158, N'vicky', 1, CAST(N'2026-06-25' AS Date), CAST(N'15:31:45.2451756' AS Time), N'Cambio de Idioma', N'Idioma cambiado con éxito', 12345678, N'SSLEfuXDkWAsfSmCGdR84tIN579va1Ss02mPMm9m4wA=')
INSERT [dbo].[Evento] ([IdEvento], [Login], [Criticidad], [Fecha], [Hora], [NombreEvento], [Modulo], [DNI], [DVH]) VALUES (159, N'vicky', 1, CAST(N'2026-06-25' AS Date), CAST(N'15:52:58.1382913' AS Time), N'Login', N'Usuario', 12345678, N'2xE3fMGkd3uKO0B77lpOX7HBl143Uy5zDl6yq7DK4S4=')
INSERT [dbo].[Evento] ([IdEvento], [Login], [Criticidad], [Fecha], [Hora], [NombreEvento], [Modulo], [DNI], [DVH]) VALUES (160, N'vicky', 1, CAST(N'2026-06-25' AS Date), CAST(N'15:53:05.1101721' AS Time), N'Cambio de Idioma', N'Idioma cambiado con éxito', 12345678, N'd6l9I5UeWjkl/fW3cZ7n+/h/l8KyzRhuP1OrtkTyKmE=')
INSERT [dbo].[Evento] ([IdEvento], [Login], [Criticidad], [Fecha], [Hora], [NombreEvento], [Modulo], [DNI], [DVH]) VALUES (161, N'vicky', 1, CAST(N'2026-06-25' AS Date), CAST(N'15:53:36.3897080' AS Time), N'Login', N'Usuario', 12345678, N'x0fdn8oHykIPl9yGVmTopdsBEsTZalCsM6K35i6RDbw=')
INSERT [dbo].[Evento] ([IdEvento], [Login], [Criticidad], [Fecha], [Hora], [NombreEvento], [Modulo], [DNI], [DVH]) VALUES (162, N'vicky', 1, CAST(N'2026-06-25' AS Date), CAST(N'15:53:39.0967486' AS Time), N'Cambio de Idioma', N'Idioma cambiado con éxito', 12345678, N'rQdA8uVWZlFxI31SQ6sYBqpQBpzkNyZLFKXW011h5CU=')
INSERT [dbo].[Evento] ([IdEvento], [Login], [Criticidad], [Fecha], [Hora], [NombreEvento], [Modulo], [DNI], [DVH]) VALUES (163, N'vicky', 1, CAST(N'2026-06-25' AS Date), CAST(N'15:57:32.6500004' AS Time), N'Cambio de Idioma', N'Idioma cambiado con éxito', 12345678, N'6ICl6JhO6OyNf1IcHRggrmlHJcDW5+NGrgkAFwQ/epw=')
INSERT [dbo].[Evento] ([IdEvento], [Login], [Criticidad], [Fecha], [Hora], [NombreEvento], [Modulo], [DNI], [DVH]) VALUES (164, N'vicky', 1, CAST(N'2026-06-25' AS Date), CAST(N'15:58:14.7024800' AS Time), N'Cambio de Idioma', N'Idioma cambiado con éxito', 12345678, N'bXA+G7UZBvOHJJh0JSt+nds8Ped1G8KecA4RbjujHRw=')
INSERT [dbo].[Evento] ([IdEvento], [Login], [Criticidad], [Fecha], [Hora], [NombreEvento], [Modulo], [DNI], [DVH]) VALUES (165, N'vicky', 1, CAST(N'2026-06-25' AS Date), CAST(N'15:58:17.3113745' AS Time), N'Cambio de Idioma', N'Idioma cambiado con éxito', 12345678, N'6OULE+/LtoNkjhNJlIBu5XOTi1oUnSZoljoIo76eI08=')
INSERT [dbo].[Evento] ([IdEvento], [Login], [Criticidad], [Fecha], [Hora], [NombreEvento], [Modulo], [DNI], [DVH]) VALUES (166, N'vicky', 1, CAST(N'2026-06-25' AS Date), CAST(N'16:18:34.6091442' AS Time), N'Login', N'Usuario', 12345678, N'OL2ZztbFqVmHNvaHOTV16QVreQf7gq6SHH9TEEHmcz0=')
INSERT [dbo].[Evento] ([IdEvento], [Login], [Criticidad], [Fecha], [Hora], [NombreEvento], [Modulo], [DNI], [DVH]) VALUES (167, N'vicky', 1, CAST(N'2026-06-25' AS Date), CAST(N'16:18:37.7391485' AS Time), N'Cambio de Idioma', N'Idioma cambiado con éxito', 12345678, N'RY/RCUIKPmAmMv+eoY2I4nUIrW7IrIELi92/9Liqlfk=')
INSERT [dbo].[Evento] ([IdEvento], [Login], [Criticidad], [Fecha], [Hora], [NombreEvento], [Modulo], [DNI], [DVH]) VALUES (168, N'vicky', 1, CAST(N'2026-06-25' AS Date), CAST(N'16:18:39.9834936' AS Time), N'Cambio de Idioma', N'Idioma cambiado con éxito', 12345678, N'HSBPort2qkUDSSiR6iVVSA5MTBoY/ZopfjJ5KgZvncw=')
INSERT [dbo].[Evento] ([IdEvento], [Login], [Criticidad], [Fecha], [Hora], [NombreEvento], [Modulo], [DNI], [DVH]) VALUES (169, N'vicky', 1, CAST(N'2026-06-25' AS Date), CAST(N'16:18:43.6950738' AS Time), N'Cambio de Idioma', N'Idioma cambiado con éxito', 12345678, N'Oi4bFXGlh861a4PJaJhD1LcndJFtIUxeJFcsdHrAo+A=')
INSERT [dbo].[Evento] ([IdEvento], [Login], [Criticidad], [Fecha], [Hora], [NombreEvento], [Modulo], [DNI], [DVH]) VALUES (170, N'vicky', 1, CAST(N'2026-06-25' AS Date), CAST(N'16:18:45.9311865' AS Time), N'Cambio de Idioma', N'Idioma cambiado con éxito', 12345678, N'kYUGOa5x/WeY9qLRV6p1xTI5pKDgUp7HJeF3XdlcOc0=')
INSERT [dbo].[Evento] ([IdEvento], [Login], [Criticidad], [Fecha], [Hora], [NombreEvento], [Modulo], [DNI], [DVH]) VALUES (171, N'vicky', 1, CAST(N'2026-06-25' AS Date), CAST(N'16:42:26.1465189' AS Time), N'Login', N'Usuario', 12345678, N'3Gg1jM6zFTOS++DIZFcfTWjJ96W7XsthCamvjsrXi0o=')
INSERT [dbo].[Evento] ([IdEvento], [Login], [Criticidad], [Fecha], [Hora], [NombreEvento], [Modulo], [DNI], [DVH]) VALUES (172, N'vicky', 1, CAST(N'2026-06-25' AS Date), CAST(N'16:42:30.1220577' AS Time), N'Cambio de Idioma', N'Idioma cambiado con éxito', 12345678, N'vKK6BXc9ZjCtTBTAVl7tBU+q3JNcNnJ2oZZ+97HlPDg=')
INSERT [dbo].[Evento] ([IdEvento], [Login], [Criticidad], [Fecha], [Hora], [NombreEvento], [Modulo], [DNI], [DVH]) VALUES (173, N'vicky', 1, CAST(N'2026-06-25' AS Date), CAST(N'16:44:02.3820502' AS Time), N'Cambio de Idioma', N'Idioma cambiado con éxito', 12345678, N'bwaXqtoDx8wgVEwMyIYlyK3/U5uJInVkSr6jVg+IUR0=')
INSERT [dbo].[Evento] ([IdEvento], [Login], [Criticidad], [Fecha], [Hora], [NombreEvento], [Modulo], [DNI], [DVH]) VALUES (174, N'vicky', 1, CAST(N'2026-06-25' AS Date), CAST(N'16:44:34.2704643' AS Time), N'Cambio de Idioma', N'Idioma cambiado con éxito', 12345678, N'Y3AH49XIGAsy5413Y39QmB2tTCYrlu6kP/4Euyn9QGw=')
INSERT [dbo].[Evento] ([IdEvento], [Login], [Criticidad], [Fecha], [Hora], [NombreEvento], [Modulo], [DNI], [DVH]) VALUES (175, N'vicky', 1, CAST(N'2026-06-25' AS Date), CAST(N'16:45:24.0202390' AS Time), N'Cambiar Clave', N'Usuario', 12345678, N'PvEv2aV9BfIJBbgXbYJINbcJKh9SkDa84rX3n5iqvmc=')
INSERT [dbo].[Evento] ([IdEvento], [Login], [Criticidad], [Fecha], [Hora], [NombreEvento], [Modulo], [DNI], [DVH]) VALUES (176, N'vicky', 1, CAST(N'2026-06-25' AS Date), CAST(N'16:45:25.5519883' AS Time), N'Logout', N'Usuario', 12345678, N'pZFJ+h51p6mQD2oqJZmSoTmlnLR4U1arT2yT93DlgeA=')
INSERT [dbo].[Evento] ([IdEvento], [Login], [Criticidad], [Fecha], [Hora], [NombreEvento], [Modulo], [DNI], [DVH]) VALUES (177, N'vicky', 1, CAST(N'2026-06-25' AS Date), CAST(N'16:45:31.9887445' AS Time), N'Login', N'Usuario', 12345678, N'58FlIW8lBj67Wd4LmM6SmPsoL17cmAm+J5JnL1DO52Y=')
INSERT [dbo].[Evento] ([IdEvento], [Login], [Criticidad], [Fecha], [Hora], [NombreEvento], [Modulo], [DNI], [DVH]) VALUES (178, N'vicky', 1, CAST(N'2026-06-25' AS Date), CAST(N'16:46:20.6545559' AS Time), N'Cambio de Idioma', N'Idioma cambiado con éxito', 12345678, N'gH1RznjNLqvINrWRlfjNerS6iwvo0CRfaB66cQAl078=')
INSERT [dbo].[Evento] ([IdEvento], [Login], [Criticidad], [Fecha], [Hora], [NombreEvento], [Modulo], [DNI], [DVH]) VALUES (179, N'vicky', 1, CAST(N'2026-06-25' AS Date), CAST(N'16:46:22.6231436' AS Time), N'Logout', N'Usuario', 12345678, N'Ww4tX7SdmN/XsPFrDp3WTlHRQjl8uZ9fA0hg/KA5elY=')
INSERT [dbo].[Evento] ([IdEvento], [Login], [Criticidad], [Fecha], [Hora], [NombreEvento], [Modulo], [DNI], [DVH]) VALUES (180, N'vicky', 1, CAST(N'2026-06-25' AS Date), CAST(N'16:46:38.7318081' AS Time), N'Login', N'Usuario', 12345678, N'Fjg6vuWbuThZdYgUSDdvKOJs1RQTKgad5wMGReex4mg=')
INSERT [dbo].[Evento] ([IdEvento], [Login], [Criticidad], [Fecha], [Hora], [NombreEvento], [Modulo], [DNI], [DVH]) VALUES (181, N'vicky', 1, CAST(N'2026-06-25' AS Date), CAST(N'17:13:24.2143107' AS Time), N'Login', N'Usuario', 12345678, N'5Ethqxq4bLmiR//AtsEtDinPWFnwwL/3pwYf/pk1BNI=')
INSERT [dbo].[Evento] ([IdEvento], [Login], [Criticidad], [Fecha], [Hora], [NombreEvento], [Modulo], [DNI], [DVH]) VALUES (182, N'vicky', 1, CAST(N'2026-06-25' AS Date), CAST(N'17:13:30.9065666' AS Time), N'Cambio de Idioma', N'Idioma cambiado con éxito', 12345678, N'crCzjAuM6TX5a7jAd0sv2R866yaiVNK6A85Z29RveD4=')
INSERT [dbo].[Evento] ([IdEvento], [Login], [Criticidad], [Fecha], [Hora], [NombreEvento], [Modulo], [DNI], [DVH]) VALUES (183, N'vicky', 1, CAST(N'2026-06-25' AS Date), CAST(N'17:13:41.4884402' AS Time), N'Logout', N'Usuario', 12345678, N'0XC+jEIpSYhoX7mYcFqaoWPfq+5Xnqj7/Jixeg4q8G0=')
INSERT [dbo].[Evento] ([IdEvento], [Login], [Criticidad], [Fecha], [Hora], [NombreEvento], [Modulo], [DNI], [DVH]) VALUES (184, N'vicky', 1, CAST(N'2026-06-25' AS Date), CAST(N'17:13:45.5993800' AS Time), N'Login', N'Usuario', 12345678, N'EQ5F/gbzNd7dJI5XE9gCeJSQZQzGXmC8QPjDvzzYsH0=')
INSERT [dbo].[Evento] ([IdEvento], [Login], [Criticidad], [Fecha], [Hora], [NombreEvento], [Modulo], [DNI], [DVH]) VALUES (185, N'vicky', 1, CAST(N'2026-06-25' AS Date), CAST(N'17:13:49.0393496' AS Time), N'Cambio de Idioma', N'Idioma cambiado con éxito', 12345678, N'f40v3zMCoGqFDMO0zsCmAN2vm/XpHaMLgxMXjfxNJBE=')
INSERT [dbo].[Evento] ([IdEvento], [Login], [Criticidad], [Fecha], [Hora], [NombreEvento], [Modulo], [DNI], [DVH]) VALUES (186, N'vicky', 1, CAST(N'2026-06-25' AS Date), CAST(N'17:13:58.4092451' AS Time), N'Cambiar Clave', N'Usuario', 12345678, N'lEJdoSyQCG63q0tFO3/GyQAXAtHaFjxx44JFDjoXe14=')
INSERT [dbo].[Evento] ([IdEvento], [Login], [Criticidad], [Fecha], [Hora], [NombreEvento], [Modulo], [DNI], [DVH]) VALUES (187, N'vicky', 1, CAST(N'2026-06-25' AS Date), CAST(N'17:14:00.0321872' AS Time), N'Logout', N'Usuario', 12345678, N't0aZkBmJCDZSVNNbD1KdvCrfpCClBQfRXNXOYbQPpJI=')
INSERT [dbo].[Evento] ([IdEvento], [Login], [Criticidad], [Fecha], [Hora], [NombreEvento], [Modulo], [DNI], [DVH]) VALUES (188, N'vicky', 1, CAST(N'2026-06-25' AS Date), CAST(N'17:14:12.1458732' AS Time), N'Login', N'Usuario', 12345678, N'0m8QE3LzfEjEAMrqye7hMd1W55hpXKcf7HDOVn5BQsw=')
INSERT [dbo].[Evento] ([IdEvento], [Login], [Criticidad], [Fecha], [Hora], [NombreEvento], [Modulo], [DNI], [DVH]) VALUES (189, N'vicky', 1, CAST(N'2026-06-25' AS Date), CAST(N'17:30:16.1312850' AS Time), N'Login', N'Usuario', 12345678, N'3jyReRk+xvfR7nlf4y3dwVMnLeuJKX4+dvKyzIaQ7OE=')
INSERT [dbo].[Evento] ([IdEvento], [Login], [Criticidad], [Fecha], [Hora], [NombreEvento], [Modulo], [DNI], [DVH]) VALUES (190, N'vicky', 1, CAST(N'2026-06-25' AS Date), CAST(N'17:30:16.1514670' AS Time), N'Cambio de Idioma', N'Idioma cambiado con éxito', 12345678, N'PD5qwHWrH4nzijL8J0+yUgDVUZKw7Yke3bBuw3LxcuY=')
INSERT [dbo].[Evento] ([IdEvento], [Login], [Criticidad], [Fecha], [Hora], [NombreEvento], [Modulo], [DNI], [DVH]) VALUES (191, N'vicky', 1, CAST(N'2026-06-25' AS Date), CAST(N'17:30:22.3133301' AS Time), N'Logout', N'Usuario', 12345678, N'UZPfo67jXf3uYbKHHRPVsrWFaaupUORlRlOmmjqYGdM=')
INSERT [dbo].[Evento] ([IdEvento], [Login], [Criticidad], [Fecha], [Hora], [NombreEvento], [Modulo], [DNI], [DVH]) VALUES (192, N'vicky', 1, CAST(N'2026-06-25' AS Date), CAST(N'17:30:27.9338252' AS Time), N'Login', N'Usuario', 12345678, N'if1j20shnxgtTLKGYMz47JkGrOSzzvPdlIq2XuLkqSY=')
INSERT [dbo].[Evento] ([IdEvento], [Login], [Criticidad], [Fecha], [Hora], [NombreEvento], [Modulo], [DNI], [DVH]) VALUES (193, N'vicky', 1, CAST(N'2026-06-25' AS Date), CAST(N'17:30:27.9371950' AS Time), N'Cambio de Idioma', N'Idioma cambiado con éxito', 12345678, N'EXM2JxgpbssCFT/KXjCTHlW1lgpKG/EuwQMlIo5mGLY=')
INSERT [dbo].[Evento] ([IdEvento], [Login], [Criticidad], [Fecha], [Hora], [NombreEvento], [Modulo], [DNI], [DVH]) VALUES (194, N'vicky', 1, CAST(N'2026-06-25' AS Date), CAST(N'17:30:37.0206094' AS Time), N'Logout', N'Usuario', 12345678, N'hS7EyMuodFl2QVDnfWv7BVEbAjYKwviq8i2RUCGY7J0=')
INSERT [dbo].[Evento] ([IdEvento], [Login], [Criticidad], [Fecha], [Hora], [NombreEvento], [Modulo], [DNI], [DVH]) VALUES (195, N'vicky', 1, CAST(N'2026-06-25' AS Date), CAST(N'17:30:55.9163383' AS Time), N'Login', N'Usuario', 12345678, N'fsOPs436Vkfar+E5nO76c92HSoHUyiojpJ4c3Utla9s=')
INSERT [dbo].[Evento] ([IdEvento], [Login], [Criticidad], [Fecha], [Hora], [NombreEvento], [Modulo], [DNI], [DVH]) VALUES (196, N'vicky', 1, CAST(N'2026-06-25' AS Date), CAST(N'17:30:58.4662240' AS Time), N'Logout', N'Usuario', 12345678, N'kwO+Q2KrkTTAjekS4Dk7GTV/WcYOmS056OmUEqDyBKA=')
INSERT [dbo].[Evento] ([IdEvento], [Login], [Criticidad], [Fecha], [Hora], [NombreEvento], [Modulo], [DNI], [DVH]) VALUES (197, N'vicky', 1, CAST(N'2026-06-25' AS Date), CAST(N'17:33:45.8908587' AS Time), N'Login', N'Usuario', 12345678, N'wcu60UVE0jC9zu75ySsDt/3DKODTOTtRgzw6VxCaKvc=')
INSERT [dbo].[Evento] ([IdEvento], [Login], [Criticidad], [Fecha], [Hora], [NombreEvento], [Modulo], [DNI], [DVH]) VALUES (198, N'vicky', 1, CAST(N'2026-06-25' AS Date), CAST(N'17:33:45.9027488' AS Time), N'Cambio de Idioma', N'Idioma cambiado con éxito', 12345678, N'RIDYBChe0R8F7dpZhGO6ZR+OV7SJYpqzVgcialhjaAU=')
INSERT [dbo].[Evento] ([IdEvento], [Login], [Criticidad], [Fecha], [Hora], [NombreEvento], [Modulo], [DNI], [DVH]) VALUES (199, N'vicky', 1, CAST(N'2026-06-25' AS Date), CAST(N'17:33:50.3567612' AS Time), N'Cambio de Idioma', N'Idioma cambiado con éxito', 12345678, N'EJSoCF4P/KfCEMk1wmdeXlypIIj9ymRX6lKkncAc8Oo=')
INSERT [dbo].[Evento] ([IdEvento], [Login], [Criticidad], [Fecha], [Hora], [NombreEvento], [Modulo], [DNI], [DVH]) VALUES (200, N'vicky', 1, CAST(N'2026-06-25' AS Date), CAST(N'17:33:52.3199455' AS Time), N'Logout', N'Usuario', 12345678, N'wK4KH1On2cFutrlF5G53LixE+gNhHqGMsNiXjb7Escw=')
GO
INSERT [dbo].[Evento] ([IdEvento], [Login], [Criticidad], [Fecha], [Hora], [NombreEvento], [Modulo], [DNI], [DVH]) VALUES (201, N'vicky', 1, CAST(N'2026-06-25' AS Date), CAST(N'17:34:01.2808906' AS Time), N'Login', N'Usuario', 12345678, N'cdU8AExhV8K/eHwexU98ddC/2idYwqA/2X7IPzigxww=')
INSERT [dbo].[Evento] ([IdEvento], [Login], [Criticidad], [Fecha], [Hora], [NombreEvento], [Modulo], [DNI], [DVH]) VALUES (202, N'vicky', 1, CAST(N'2026-06-25' AS Date), CAST(N'17:34:01.2856337' AS Time), N'Cambio de Idioma', N'Idioma cambiado con éxito', 12345678, N'zxK4ZTWrVl+6tuG2Y60cvVy3qwnBlXRM0pTZ4jvvLcA=')
INSERT [dbo].[Evento] ([IdEvento], [Login], [Criticidad], [Fecha], [Hora], [NombreEvento], [Modulo], [DNI], [DVH]) VALUES (203, N'vicky', 1, CAST(N'2026-06-25' AS Date), CAST(N'17:34:05.1268413' AS Time), N'Cambio de Idioma', N'Idioma cambiado con éxito', 12345678, N'4y6cQI7bLbnESt0qAJaeth391tEalWEbTAll/hsgtfA=')
INSERT [dbo].[Evento] ([IdEvento], [Login], [Criticidad], [Fecha], [Hora], [NombreEvento], [Modulo], [DNI], [DVH]) VALUES (204, N'vicky', 1, CAST(N'2026-06-25' AS Date), CAST(N'17:34:11.2084278' AS Time), N'Cambio de Idioma', N'Idioma cambiado con éxito', 12345678, N'N1T7fgfIbtJRzNY+itvzYktNlbinUMUkq5LvvKf3D5E=')
INSERT [dbo].[Evento] ([IdEvento], [Login], [Criticidad], [Fecha], [Hora], [NombreEvento], [Modulo], [DNI], [DVH]) VALUES (205, N'vicky', 1, CAST(N'2026-06-25' AS Date), CAST(N'17:34:12.7163407' AS Time), N'Logout', N'Usuario', 12345678, N'BgYWmkzjsTyZlhSaY3rWJXtJteBJTOu79sX6VgUO7QY=')
INSERT [dbo].[Evento] ([IdEvento], [Login], [Criticidad], [Fecha], [Hora], [NombreEvento], [Modulo], [DNI], [DVH]) VALUES (206, N'vicky', 1, CAST(N'2026-06-25' AS Date), CAST(N'17:34:27.2001264' AS Time), N'Login', N'Usuario', 12345678, N'qLwse72ngooDoQicZ8DoNI1PQvDSbM5OMXSu+cpwdZU=')
INSERT [dbo].[Evento] ([IdEvento], [Login], [Criticidad], [Fecha], [Hora], [NombreEvento], [Modulo], [DNI], [DVH]) VALUES (207, N'vicky', 1, CAST(N'2026-06-25' AS Date), CAST(N'17:34:27.2030149' AS Time), N'Cambio de Idioma', N'Idioma cambiado con éxito', 12345678, N'9dRqU5H41kZ/uRVpmx7fHO9rnz6B2hFfcnceiIdYz4o=')
INSERT [dbo].[Evento] ([IdEvento], [Login], [Criticidad], [Fecha], [Hora], [NombreEvento], [Modulo], [DNI], [DVH]) VALUES (208, N'vicky', 1, CAST(N'2026-06-25' AS Date), CAST(N'18:13:22.8280140' AS Time), N'Login', N'Usuario', 12345678, N'jv3iJA6h6OI8M76cLAT6ZUqLarmy1x8xT9LjiNSi7Zk=')
INSERT [dbo].[Evento] ([IdEvento], [Login], [Criticidad], [Fecha], [Hora], [NombreEvento], [Modulo], [DNI], [DVH]) VALUES (209, N'vicky', 1, CAST(N'2026-06-25' AS Date), CAST(N'18:13:22.8527137' AS Time), N'Cambio de Idioma', N'Idioma cambiado con éxito', 12345678, N'sQCRZQOsECcpbNM7L52XxzppeY0ApIG++JQjfcjn6fg=')
INSERT [dbo].[Evento] ([IdEvento], [Login], [Criticidad], [Fecha], [Hora], [NombreEvento], [Modulo], [DNI], [DVH]) VALUES (210, N'vicky', 1, CAST(N'2026-06-25' AS Date), CAST(N'18:14:14.8361532' AS Time), N'Creación de nuevo Perfil', N'Perfiles', 12345678, N'gGPx30GLddfkpzc6t2j/2gBdN8h3lI8oGzsKoiOsc5g=')
INSERT [dbo].[Evento] ([IdEvento], [Login], [Criticidad], [Fecha], [Hora], [NombreEvento], [Modulo], [DNI], [DVH]) VALUES (211, N'vicky', 1, CAST(N'2026-06-25' AS Date), CAST(N'18:15:06.9001105' AS Time), N'Creación de nueva Familia', N'Perfiles', 12345678, N'B0RKmywhiH5UwBkbotaXZJvhrPY7oFNnDi+moGwsGA0=')
INSERT [dbo].[Evento] ([IdEvento], [Login], [Criticidad], [Fecha], [Hora], [NombreEvento], [Modulo], [DNI], [DVH]) VALUES (212, N'vicky', 1, CAST(N'2026-06-25' AS Date), CAST(N'18:15:33.0479698' AS Time), N'Eliminación de Familia', N'Perfiles', 12345678, N'4k2ngg60XiMCtzERInMBABTOEzYmwYWda0Pk3/MSSJc=')
INSERT [dbo].[Evento] ([IdEvento], [Login], [Criticidad], [Fecha], [Hora], [NombreEvento], [Modulo], [DNI], [DVH]) VALUES (213, N'vicky', 1, CAST(N'2026-06-25' AS Date), CAST(N'18:15:51.2937310' AS Time), N'Eliminación de Perfil', N'Perfiles', 12345678, N'IwoJeRjDVx+dBUFoM/+sYcRLIZ0gayJvgdLXSu07aLY=')
INSERT [dbo].[Evento] ([IdEvento], [Login], [Criticidad], [Fecha], [Hora], [NombreEvento], [Modulo], [DNI], [DVH]) VALUES (214, N'vicky', 1, CAST(N'2026-06-25' AS Date), CAST(N'18:16:38.1602981' AS Time), N'Modificación Perfil', N'Perfiles', 12345678, N'DRTjGEKSARKsvLs/m5v4ni7ot2KT2Onuis69EsqcEVg=')
INSERT [dbo].[Evento] ([IdEvento], [Login], [Criticidad], [Fecha], [Hora], [NombreEvento], [Modulo], [DNI], [DVH]) VALUES (215, N'vicky', 1, CAST(N'2026-06-25' AS Date), CAST(N'18:16:58.6661032' AS Time), N'Modificación Perfil', N'Perfiles', 12345678, N'uozaQIj0AKhKlEBec4sXw28HuzkLs4G160FyM2Ol5XY=')
INSERT [dbo].[Evento] ([IdEvento], [Login], [Criticidad], [Fecha], [Hora], [NombreEvento], [Modulo], [DNI], [DVH]) VALUES (216, N'vicky', 1, CAST(N'2026-06-25' AS Date), CAST(N'18:17:34.8985204' AS Time), N'Modificación Perfil', N'Perfiles', 12345678, N'HaOPVUC8dSYMK1B29MAQBb7SDofuQldJVgxphKXOOyI=')
INSERT [dbo].[Evento] ([IdEvento], [Login], [Criticidad], [Fecha], [Hora], [NombreEvento], [Modulo], [DNI], [DVH]) VALUES (217, N'vicky', 1, CAST(N'2026-06-25' AS Date), CAST(N'18:17:41.5116746' AS Time), N'Modificación Perfil', N'Perfiles', 12345678, N'L6uTk3kgw2U2EGg4HQLTFBLHNfRrAAgB6+0Dp+mhal4=')
INSERT [dbo].[Evento] ([IdEvento], [Login], [Criticidad], [Fecha], [Hora], [NombreEvento], [Modulo], [DNI], [DVH]) VALUES (218, N'vicky', 1, CAST(N'2026-06-25' AS Date), CAST(N'18:18:41.1203493' AS Time), N'Modificación Familia', N'Perfiles', 12345678, N'Fe8aUhs9QNHKVQtVLkC7vYOC1zi+sjlAClSfh+sDU0g=')
INSERT [dbo].[Evento] ([IdEvento], [Login], [Criticidad], [Fecha], [Hora], [NombreEvento], [Modulo], [DNI], [DVH]) VALUES (219, N'vicky', 1, CAST(N'2026-06-25' AS Date), CAST(N'18:18:54.9324270' AS Time), N'Modificación Familia', N'Perfiles', 12345678, N'NIfFH3iEZUWSoJ8zQg/gq/Lbw07ldBMfDOj7SHhcMfE=')
INSERT [dbo].[Evento] ([IdEvento], [Login], [Criticidad], [Fecha], [Hora], [NombreEvento], [Modulo], [DNI], [DVH]) VALUES (220, N'vicky', 1, CAST(N'2026-06-25' AS Date), CAST(N'18:19:31.3090397' AS Time), N'Modificación Familia', N'Perfiles', 12345678, N'Gua0WSC41FpWhLikzC0zbB2CEfVVLN/n1/LwMGX6c+I=')
INSERT [dbo].[Evento] ([IdEvento], [Login], [Criticidad], [Fecha], [Hora], [NombreEvento], [Modulo], [DNI], [DVH]) VALUES (221, N'vicky', 1, CAST(N'2026-06-25' AS Date), CAST(N'18:20:28.6939440' AS Time), N'Modificación Familia', N'Perfiles', 12345678, N'yhBMBzFO1pI5NWSP9ie/0gyE4tJxN5Hqc/OtV5uEnW0=')
INSERT [dbo].[Evento] ([IdEvento], [Login], [Criticidad], [Fecha], [Hora], [NombreEvento], [Modulo], [DNI], [DVH]) VALUES (222, N'vicky', 1, CAST(N'2026-06-25' AS Date), CAST(N'18:20:56.9226030' AS Time), N'Modificación Familia', N'Perfiles', 12345678, N'NuhdpjA5ZjgvtmBkxDPD+KZRVpZl/GuQaskwJ4CAHOo=')
INSERT [dbo].[Evento] ([IdEvento], [Login], [Criticidad], [Fecha], [Hora], [NombreEvento], [Modulo], [DNI], [DVH]) VALUES (223, N'vicky', 1, CAST(N'2026-06-25' AS Date), CAST(N'18:21:16.7620728' AS Time), N'Modificación Familia', N'Perfiles', 12345678, N'fPxiXZvpbKtAv2sNKQsHd1KrKhkhjOioK6vv/1O9Fo8=')
INSERT [dbo].[Evento] ([IdEvento], [Login], [Criticidad], [Fecha], [Hora], [NombreEvento], [Modulo], [DNI], [DVH]) VALUES (224, N'vicky', 1, CAST(N'2026-06-25' AS Date), CAST(N'18:21:45.9377707' AS Time), N'Logout', N'Usuario', 12345678, N'2Ojn2zTbJnlXpwIdQcyehBeGRZwoLzvfeb8mfF4WfcU=')
INSERT [dbo].[Evento] ([IdEvento], [Login], [Criticidad], [Fecha], [Hora], [NombreEvento], [Modulo], [DNI], [DVH]) VALUES (225, N'vicky', 1, CAST(N'2026-06-25' AS Date), CAST(N'20:12:00.4252808' AS Time), N'Login', N'Usuario', 12345678, N'4L3+PqgvuiwwW7vazd4qbiBOLt5E5ggSWy12gRx1PUY=')
INSERT [dbo].[Evento] ([IdEvento], [Login], [Criticidad], [Fecha], [Hora], [NombreEvento], [Modulo], [DNI], [DVH]) VALUES (226, N'vicky', 1, CAST(N'2026-06-25' AS Date), CAST(N'20:12:26.3577507' AS Time), N'Creación de nueva Familia', N'Perfiles', 12345678, N'jNeZbAnGP24nTfCF3tmB/gdOfZAEIZOlQOxQhjh27b8=')
INSERT [dbo].[Evento] ([IdEvento], [Login], [Criticidad], [Fecha], [Hora], [NombreEvento], [Modulo], [DNI], [DVH]) VALUES (227, N'vicky', 1, CAST(N'2026-06-25' AS Date), CAST(N'20:12:39.1247562' AS Time), N'Eliminación de Familia', N'Perfiles', 12345678, N'0SBVm2xMjzDGVQv/scNVCWtnZmbFnwHAs6OQPDagwqg=')
INSERT [dbo].[Evento] ([IdEvento], [Login], [Criticidad], [Fecha], [Hora], [NombreEvento], [Modulo], [DNI], [DVH]) VALUES (228, N'vicky', 1, CAST(N'2026-06-25' AS Date), CAST(N'20:19:04.0941472' AS Time), N'Login', N'Usuario', 12345678, N'+BpnulyEE8fTiS6ZuyrVk52hT5pN6t+x6gTvj9pvn4U=')
INSERT [dbo].[Evento] ([IdEvento], [Login], [Criticidad], [Fecha], [Hora], [NombreEvento], [Modulo], [DNI], [DVH]) VALUES (229, N'vicky', 1, CAST(N'2026-06-26' AS Date), CAST(N'00:23:00.1902872' AS Time), N'Login', N'Usuario', 12345678, N'zA7W0UO/8zkZOIF5HvA9l2uImgpm0tPvIYFA+ceiv5Q=')
INSERT [dbo].[Evento] ([IdEvento], [Login], [Criticidad], [Fecha], [Hora], [NombreEvento], [Modulo], [DNI], [DVH]) VALUES (230, N'vicky', 1, CAST(N'2026-06-26' AS Date), CAST(N'00:23:11.4315247' AS Time), N'Cambio de Idioma', N'Idioma cambiado con éxito', 12345678, N'cb4lA+wU/5WL3skgpXljJ0jF7A6pEwe52hi9d6mqY7w=')
INSERT [dbo].[Evento] ([IdEvento], [Login], [Criticidad], [Fecha], [Hora], [NombreEvento], [Modulo], [DNI], [DVH]) VALUES (231, N'vicky', 1, CAST(N'2026-06-26' AS Date), CAST(N'00:23:15.9408828' AS Time), N'Cambio de Idioma', N'Idioma cambiado con éxito', 12345678, N'0yhc+jeSjTkpjkyKSfwDhg7mLslASFRBK8/rZrIhznM=')
INSERT [dbo].[Evento] ([IdEvento], [Login], [Criticidad], [Fecha], [Hora], [NombreEvento], [Modulo], [DNI], [DVH]) VALUES (232, N'vicky', 1, CAST(N'2026-06-26' AS Date), CAST(N'00:23:20.9433978' AS Time), N'Logout', N'Usuario', 12345678, N'Y+qk3sQTxZ8a8s9KfwxRvykXdxkVFiAddWkWL1NXdlg=')
INSERT [dbo].[Evento] ([IdEvento], [Login], [Criticidad], [Fecha], [Hora], [NombreEvento], [Modulo], [DNI], [DVH]) VALUES (233, N'vicky', 1, CAST(N'2026-06-26' AS Date), CAST(N'00:27:53.7357220' AS Time), N'Login', N'Usuario', 12345678, N'JZNJMLpX25CXTruYFYbofuWTR3SLme7an/97BxUufSI=')
INSERT [dbo].[Evento] ([IdEvento], [Login], [Criticidad], [Fecha], [Hora], [NombreEvento], [Modulo], [DNI], [DVH]) VALUES (234, N'vicky', 1, CAST(N'2026-06-26' AS Date), CAST(N'00:27:53.7510355' AS Time), N'Cambio de Idioma', N'Idioma cambiado con éxito', 12345678, N'VNoCLIWFG5PwbvESmzBGaaAgu2vrf5JqIwcpNUgmgl4=')
INSERT [dbo].[Evento] ([IdEvento], [Login], [Criticidad], [Fecha], [Hora], [NombreEvento], [Modulo], [DNI], [DVH]) VALUES (235, N'vicky', 1, CAST(N'2026-06-26' AS Date), CAST(N'00:28:01.9732911' AS Time), N'Cambio de Idioma', N'Idioma cambiado con éxito', 12345678, N'6DQCdCcfftZqX3zGKAZApPcOGdRazpfj+3Tk5DJivhQ=')
INSERT [dbo].[Evento] ([IdEvento], [Login], [Criticidad], [Fecha], [Hora], [NombreEvento], [Modulo], [DNI], [DVH]) VALUES (236, N'vicky', 1, CAST(N'2026-06-26' AS Date), CAST(N'00:28:07.7988415' AS Time), N'Cambio de Idioma', N'Idioma cambiado con éxito', 12345678, N'qryds2a77vNl7VFPT7Emo5QQsfoUs8o16arn0u6lKwE=')
INSERT [dbo].[Evento] ([IdEvento], [Login], [Criticidad], [Fecha], [Hora], [NombreEvento], [Modulo], [DNI], [DVH]) VALUES (237, N'vicky', 1, CAST(N'2026-06-26' AS Date), CAST(N'00:28:09.5459626' AS Time), N'Logout', N'Usuario', 12345678, N'BFnNodJgPEA23G7s9wvSbqZ4pgjc9kAOT4v9+7mfQ54=')
INSERT [dbo].[Evento] ([IdEvento], [Login], [Criticidad], [Fecha], [Hora], [NombreEvento], [Modulo], [DNI], [DVH]) VALUES (238, N'vicky', 1, CAST(N'2026-06-26' AS Date), CAST(N'00:28:15.8848149' AS Time), N'Login', N'Usuario', 12345678, N'UTTprh6w+31U3Y+qPdPgoTq6RHHlybv3tHqiNwph+lY=')
INSERT [dbo].[Evento] ([IdEvento], [Login], [Criticidad], [Fecha], [Hora], [NombreEvento], [Modulo], [DNI], [DVH]) VALUES (239, N'vicky', 1, CAST(N'2026-06-26' AS Date), CAST(N'00:28:18.5144675' AS Time), N'Cambio de Idioma', N'Idioma cambiado con éxito', 12345678, N'1N7AoSVlfx1OSAEcG3FkzlQAvFrBhea82ttDtQT9Vv8=')
INSERT [dbo].[Evento] ([IdEvento], [Login], [Criticidad], [Fecha], [Hora], [NombreEvento], [Modulo], [DNI], [DVH]) VALUES (240, N'vicky', 1, CAST(N'2026-06-26' AS Date), CAST(N'00:28:20.4878745' AS Time), N'Logout', N'Usuario', 12345678, N'GpuOoto+nf8Uxq3wme4cRwlGRfCM9DUW1PesfS6FSN8=')
INSERT [dbo].[Evento] ([IdEvento], [Login], [Criticidad], [Fecha], [Hora], [NombreEvento], [Modulo], [DNI], [DVH]) VALUES (241, N'vicky', 1, CAST(N'2026-06-26' AS Date), CAST(N'00:28:26.4524130' AS Time), N'Login', N'Usuario', 12345678, N'nNs40T4nyxElRJOfHzTU2VebTOFAljYhtLZZ4rdzo2k=')
INSERT [dbo].[Evento] ([IdEvento], [Login], [Criticidad], [Fecha], [Hora], [NombreEvento], [Modulo], [DNI], [DVH]) VALUES (242, N'vicky', 1, CAST(N'2026-06-26' AS Date), CAST(N'00:28:26.4549826' AS Time), N'Cambio de Idioma', N'Idioma cambiado con éxito', 12345678, N'yyCeCMuOKdkXoqxM5sT5JdXa2i30iGBSKNr4azgs4Sc=')
INSERT [dbo].[Evento] ([IdEvento], [Login], [Criticidad], [Fecha], [Hora], [NombreEvento], [Modulo], [DNI], [DVH]) VALUES (243, N'vicky', 1, CAST(N'2026-06-26' AS Date), CAST(N'00:28:28.3999864' AS Time), N'Logout', N'Usuario', 12345678, N'xobADI6beBo0x+3n3XcFM2ijmXtI5QdvGg+8WSPMG/k=')
INSERT [dbo].[Evento] ([IdEvento], [Login], [Criticidad], [Fecha], [Hora], [NombreEvento], [Modulo], [DNI], [DVH]) VALUES (244, N'vicky', 1, CAST(N'2026-06-26' AS Date), CAST(N'00:28:32.1004347' AS Time), N'Login', N'Usuario', 12345678, N'j/Rypq4DtiAnXn3+O1IWbvjKvux2jw8WefxeJX/wSzo=')
INSERT [dbo].[Evento] ([IdEvento], [Login], [Criticidad], [Fecha], [Hora], [NombreEvento], [Modulo], [DNI], [DVH]) VALUES (245, N'vicky', 1, CAST(N'2026-06-26' AS Date), CAST(N'00:28:37.1359656' AS Time), N'Logout', N'Usuario', 12345678, N'Rtxlic5XH7P4YQxAZtIxSWj15Orug0Mit85iIlPcOQo=')
INSERT [dbo].[Evento] ([IdEvento], [Login], [Criticidad], [Fecha], [Hora], [NombreEvento], [Modulo], [DNI], [DVH]) VALUES (246, N'vicky', 1, CAST(N'2026-06-26' AS Date), CAST(N'00:39:59.4239885' AS Time), N'Login', N'Usuario', 12345678, N'3gw3uchs83CT0S49TEC+Ha5WbTK8THSk5Gusn1Qu7T8=')
INSERT [dbo].[Evento] ([IdEvento], [Login], [Criticidad], [Fecha], [Hora], [NombreEvento], [Modulo], [DNI], [DVH]) VALUES (247, N'vicky', 1, CAST(N'2026-06-26' AS Date), CAST(N'00:40:17.8061975' AS Time), N'Logout', N'Usuario', 12345678, N'J9gUhktV9LJQtMxyWy9Zsks4PVDMzbh/Zk5DirXtfvk=')
INSERT [dbo].[Evento] ([IdEvento], [Login], [Criticidad], [Fecha], [Hora], [NombreEvento], [Modulo], [DNI], [DVH]) VALUES (248, N'vicky', 1, CAST(N'2026-06-26' AS Date), CAST(N'00:40:21.9441996' AS Time), N'Login', N'Usuario', 12345678, N'lR1CV1QS7OjKwL34JtlGmgPwix0QK5ljVTuQDBba5dI=')
INSERT [dbo].[Evento] ([IdEvento], [Login], [Criticidad], [Fecha], [Hora], [NombreEvento], [Modulo], [DNI], [DVH]) VALUES (249, N'vicky', 1, CAST(N'2026-06-26' AS Date), CAST(N'00:40:27.9246680' AS Time), N'Cambio de Idioma', N'Idioma cambiado con éxito', 12345678, N'56PK5ejK/+awvt8Ppm4DWh1mWdK2hMQ4nnM0wu0EmCc=')
INSERT [dbo].[Evento] ([IdEvento], [Login], [Criticidad], [Fecha], [Hora], [NombreEvento], [Modulo], [DNI], [DVH]) VALUES (250, N'vicky', 1, CAST(N'2026-06-26' AS Date), CAST(N'00:40:30.3073107' AS Time), N'Logout', N'Usuario', 12345678, N'siJ3dLqYO4MMsMfE2jHXxuu1UlWO+ZJqXqz1EtnCQGY=')
INSERT [dbo].[Evento] ([IdEvento], [Login], [Criticidad], [Fecha], [Hora], [NombreEvento], [Modulo], [DNI], [DVH]) VALUES (251, N'vicky', 1, CAST(N'2026-06-26' AS Date), CAST(N'00:40:36.2641475' AS Time), N'Login', N'Usuario', 12345678, N'V32ZSKrBAveR43HODiT3BsATeNJu7rf4rXmxUOsvAaw=')
INSERT [dbo].[Evento] ([IdEvento], [Login], [Criticidad], [Fecha], [Hora], [NombreEvento], [Modulo], [DNI], [DVH]) VALUES (252, N'vicky', 1, CAST(N'2026-06-26' AS Date), CAST(N'00:40:52.8825446' AS Time), N'Logout', N'Usuario', 12345678, N'A/v2L5GvkfiBXNk1jxEOGtcmjroSZnrBUYGdhcaL4yY=')
INSERT [dbo].[Evento] ([IdEvento], [Login], [Criticidad], [Fecha], [Hora], [NombreEvento], [Modulo], [DNI], [DVH]) VALUES (253, N'vicky', 1, CAST(N'2026-06-26' AS Date), CAST(N'00:41:04.2555231' AS Time), N'Login', N'Usuario', 12345678, N'Xuruhz8htiXMgdKKbK8C853Qpown++XjHKCscK05Jbc=')
INSERT [dbo].[Evento] ([IdEvento], [Login], [Criticidad], [Fecha], [Hora], [NombreEvento], [Modulo], [DNI], [DVH]) VALUES (254, N'vicky', 1, CAST(N'2026-06-26' AS Date), CAST(N'00:41:04.2620672' AS Time), N'Cambio de Idioma', N'Idioma cambiado con éxito', 12345678, N'yfNn2S3kfhxDXefeEH1xhOIAd9J9MWY8lApRuB6AjtA=')
INSERT [dbo].[Evento] ([IdEvento], [Login], [Criticidad], [Fecha], [Hora], [NombreEvento], [Modulo], [DNI], [DVH]) VALUES (255, N'vicky', 1, CAST(N'2026-06-26' AS Date), CAST(N'00:41:17.2023548' AS Time), N'Logout', N'Usuario', 12345678, N'hVo2UHmAH47LuAcT8dfJ/5X7jlc/uwQ8onnioEGd46I=')
INSERT [dbo].[Evento] ([IdEvento], [Login], [Criticidad], [Fecha], [Hora], [NombreEvento], [Modulo], [DNI], [DVH]) VALUES (256, N'vicky', 1, CAST(N'2026-06-26' AS Date), CAST(N'00:41:22.3048828' AS Time), N'Login', N'Usuario', 12345678, N'fW2b4OctqMOwJ/zQgMZDD3ZgqzpRqrNCDwOH/6Quyvw=')
INSERT [dbo].[Evento] ([IdEvento], [Login], [Criticidad], [Fecha], [Hora], [NombreEvento], [Modulo], [DNI], [DVH]) VALUES (257, N'vicky', 1, CAST(N'2026-06-26' AS Date), CAST(N'00:41:31.9321795' AS Time), N'Logout', N'Usuario', 12345678, N'rdo9Bjjr0JvpaV+SDPwuHN/uR1te7xLKHf8F6wWkYVA=')
INSERT [dbo].[Evento] ([IdEvento], [Login], [Criticidad], [Fecha], [Hora], [NombreEvento], [Modulo], [DNI], [DVH]) VALUES (258, N'vicky', 1, CAST(N'2026-06-26' AS Date), CAST(N'00:41:38.4636818' AS Time), N'Login', N'Usuario', 12345678, N'89DaqWpiOHl+nnOBOzVpDI7f95m8MInK8NJhMbMKhM8=')
INSERT [dbo].[Evento] ([IdEvento], [Login], [Criticidad], [Fecha], [Hora], [NombreEvento], [Modulo], [DNI], [DVH]) VALUES (259, N'vicky', 1, CAST(N'2026-06-26' AS Date), CAST(N'00:42:09.3645249' AS Time), N'Logout', N'Usuario', 12345678, N'FLIffB6fLW3aSP4zjkO1pmFC5uwwm/Ot27qxX/47eaM=')
INSERT [dbo].[Evento] ([IdEvento], [Login], [Criticidad], [Fecha], [Hora], [NombreEvento], [Modulo], [DNI], [DVH]) VALUES (260, N'vicky', 1, CAST(N'2026-06-26' AS Date), CAST(N'00:42:16.5289333' AS Time), N'Login', N'Usuario', 12345678, N'XQLCiWdubfR8ZvVM+m39444zllXWqjoE9UAZ4OJiyJU=')
INSERT [dbo].[Evento] ([IdEvento], [Login], [Criticidad], [Fecha], [Hora], [NombreEvento], [Modulo], [DNI], [DVH]) VALUES (261, N'vicky', 1, CAST(N'2026-06-26' AS Date), CAST(N'00:42:22.3213162' AS Time), N'Cambio de Idioma', N'Idioma cambiado con éxito', 12345678, N'hF2pI9myi1FkU9pCXoD4YuqrRmMOEANaYvWFjBMbmpk=')
INSERT [dbo].[Evento] ([IdEvento], [Login], [Criticidad], [Fecha], [Hora], [NombreEvento], [Modulo], [DNI], [DVH]) VALUES (262, N'vicky', 1, CAST(N'2026-06-26' AS Date), CAST(N'00:42:25.9626921' AS Time), N'Logout', N'Usuario', 12345678, N'zUq5NtcJx6aG/Qjz/UPVQhZrBloZPqiuG2Fu3W7pynw=')
INSERT [dbo].[Evento] ([IdEvento], [Login], [Criticidad], [Fecha], [Hora], [NombreEvento], [Modulo], [DNI], [DVH]) VALUES (263, N'vicky', 1, CAST(N'2026-06-26' AS Date), CAST(N'00:42:38.8125068' AS Time), N'Login', N'Usuario', 12345678, N'MdrU0heXL4fL0+jRncMoXebUD4VmJCXKYrgUcyqsDaE=')
INSERT [dbo].[Evento] ([IdEvento], [Login], [Criticidad], [Fecha], [Hora], [NombreEvento], [Modulo], [DNI], [DVH]) VALUES (264, N'vicky', 1, CAST(N'2026-06-26' AS Date), CAST(N'00:42:38.8145450' AS Time), N'Cambio de Idioma', N'Idioma cambiado con éxito', 12345678, N'bzlCLJ660RxOoLt4F8YXB3O889vhDFe4LrN3GAuIuHc=')
INSERT [dbo].[Evento] ([IdEvento], [Login], [Criticidad], [Fecha], [Hora], [NombreEvento], [Modulo], [DNI], [DVH]) VALUES (265, N'vicky', 1, CAST(N'2026-06-26' AS Date), CAST(N'00:42:53.9722887' AS Time), N'Cambio de Idioma', N'Idioma cambiado con éxito', 12345678, N'Llusazg8l0r6DAkvHMYGv2l55sm2zzICWq2cykgI/z8=')
INSERT [dbo].[Evento] ([IdEvento], [Login], [Criticidad], [Fecha], [Hora], [NombreEvento], [Modulo], [DNI], [DVH]) VALUES (266, N'vicky', 1, CAST(N'2026-06-26' AS Date), CAST(N'00:42:57.8472719' AS Time), N'Logout', N'Usuario', 12345678, N'PUsOJS+IsYOYNvpVyV3XBlyb6hZSJJ8f/2ZFZsyUfTA=')
INSERT [dbo].[Evento] ([IdEvento], [Login], [Criticidad], [Fecha], [Hora], [NombreEvento], [Modulo], [DNI], [DVH]) VALUES (267, N'vicky', 1, CAST(N'2026-06-26' AS Date), CAST(N'00:44:13.9295127' AS Time), N'Login', N'Usuario', 12345678, N'7ZjumeY5zXK24eaxgiVyIJn95Te5ItzGS+R9BcT8mAg=')
INSERT [dbo].[Evento] ([IdEvento], [Login], [Criticidad], [Fecha], [Hora], [NombreEvento], [Modulo], [DNI], [DVH]) VALUES (268, N'vicky', 1, CAST(N'2026-06-26' AS Date), CAST(N'00:44:28.5007399' AS Time), N'Cambio de Idioma', N'Idioma cambiado con éxito', 12345678, N'uxdQZm6lNphL7+Uy5df3GR/888Dn2f8QbvsdI5GxUgI=')
INSERT [dbo].[Evento] ([IdEvento], [Login], [Criticidad], [Fecha], [Hora], [NombreEvento], [Modulo], [DNI], [DVH]) VALUES (269, N'vicky', 1, CAST(N'2026-06-26' AS Date), CAST(N'00:44:33.1417385' AS Time), N'Logout', N'Usuario', 12345678, N'nRYfXL0wQBJcr98MFTjoEP2r2+39X4h2e3mAFBgd3h0=')
INSERT [dbo].[Evento] ([IdEvento], [Login], [Criticidad], [Fecha], [Hora], [NombreEvento], [Modulo], [DNI], [DVH]) VALUES (270, N'vicky', 1, CAST(N'2026-06-26' AS Date), CAST(N'00:44:45.1146411' AS Time), N'Login', N'Usuario', 12345678, N'PJiZOcvG8vfv1Lxyf/fb7GNFsUStAY4b4E7EyWH7Dw8=')
INSERT [dbo].[Evento] ([IdEvento], [Login], [Criticidad], [Fecha], [Hora], [NombreEvento], [Modulo], [DNI], [DVH]) VALUES (271, N'vicky', 1, CAST(N'2026-06-26' AS Date), CAST(N'00:44:57.6748827' AS Time), N'Logout', N'Usuario', 12345678, N'ohMb3NH4Gr3EAcwOD98sV8on6R6UtPknE5tsuvMZqjk=')
INSERT [dbo].[Evento] ([IdEvento], [Login], [Criticidad], [Fecha], [Hora], [NombreEvento], [Modulo], [DNI], [DVH]) VALUES (272, N'vicky', 1, CAST(N'2026-06-26' AS Date), CAST(N'00:45:18.7448137' AS Time), N'Login', N'Usuario', 12345678, N'IRhExcPc5nqqh2oLEzOxTzUUj5OSQ7hW8hSiHrIK1XA=')
INSERT [dbo].[Evento] ([IdEvento], [Login], [Criticidad], [Fecha], [Hora], [NombreEvento], [Modulo], [DNI], [DVH]) VALUES (273, N'vicky', 1, CAST(N'2026-06-26' AS Date), CAST(N'00:45:18.7477028' AS Time), N'Cambio de Idioma', N'Idioma cambiado con éxito', 12345678, N'x5LLBcHDJ4T1/4VgcfwWfbyoCaVJ0Fn4CckZPztahEw=')
INSERT [dbo].[Evento] ([IdEvento], [Login], [Criticidad], [Fecha], [Hora], [NombreEvento], [Modulo], [DNI], [DVH]) VALUES (274, N'vicky', 1, CAST(N'2026-06-26' AS Date), CAST(N'00:47:48.6337886' AS Time), N'Logout', N'Usuario', 12345678, N'7HtcldCs5gb7rMhVgl2VhnsPWkI61JZRpH5EEQRnppA=')
INSERT [dbo].[Evento] ([IdEvento], [Login], [Criticidad], [Fecha], [Hora], [NombreEvento], [Modulo], [DNI], [DVH]) VALUES (275, N'sofigesualdo', 1, CAST(N'2026-06-26' AS Date), CAST(N'00:47:58.5828494' AS Time), N'Login', N'Usuario', 46956657, N'5LAj/t4ZHOEOU9FnHlNXzvuGiNasqDedjRpB6NJ4Whw=')
INSERT [dbo].[Evento] ([IdEvento], [Login], [Criticidad], [Fecha], [Hora], [NombreEvento], [Modulo], [DNI], [DVH]) VALUES (276, N'sofigesualdo', 1, CAST(N'2026-06-26' AS Date), CAST(N'00:48:08.0416213' AS Time), N'Cambio de Idioma', N'Idioma cambiado con éxito', 46956657, N'WrrFbrL3tmjsEk4EqrJB2PVSBlyuCd1oskuqMcejs28=')
INSERT [dbo].[Evento] ([IdEvento], [Login], [Criticidad], [Fecha], [Hora], [NombreEvento], [Modulo], [DNI], [DVH]) VALUES (277, N'sofigesualdo', 1, CAST(N'2026-06-26' AS Date), CAST(N'00:48:21.1500313' AS Time), N'Logout', N'Usuario', 46956657, N'7dItC4rkehVqSlUcXOoPKeWjDVaLeZIWAte1MU0TI1g=')
INSERT [dbo].[Evento] ([IdEvento], [Login], [Criticidad], [Fecha], [Hora], [NombreEvento], [Modulo], [DNI], [DVH]) VALUES (278, N'vicky', 1, CAST(N'2026-06-29' AS Date), CAST(N'21:06:55.9703131' AS Time), N'Login', N'Usuario', 12345678, N'Wd2JkoPtQ2yIM5tG8kBwEI19CRdMOW1cgeYfQyy59Pw=')
INSERT [dbo].[Evento] ([IdEvento], [Login], [Criticidad], [Fecha], [Hora], [NombreEvento], [Modulo], [DNI], [DVH]) VALUES (279, N'vicky', 1, CAST(N'2026-06-29' AS Date), CAST(N'21:06:59.5381378' AS Time), N'Cambio de Idioma', N'Idioma cambiado con éxito', 12345678, N'TpdB23Z1Sg3vFUkfqSoiZ5dWdJdVDWHkha7Zq3hxgBw=')
INSERT [dbo].[Evento] ([IdEvento], [Login], [Criticidad], [Fecha], [Hora], [NombreEvento], [Modulo], [DNI], [DVH]) VALUES (280, N'vicky', 1, CAST(N'2026-06-29' AS Date), CAST(N'21:07:06.9748843' AS Time), N'Cambio de Idioma', N'Idioma cambiado con éxito', 12345678, N'8kX6QVVMGrar/V4hwKalgzUNT6DkCu2tuNV+Un2e7zw=')
INSERT [dbo].[Evento] ([IdEvento], [Login], [Criticidad], [Fecha], [Hora], [NombreEvento], [Modulo], [DNI], [DVH]) VALUES (281, N'vicky', 1, CAST(N'2026-06-29' AS Date), CAST(N'21:15:04.7028216' AS Time), N'Realizar Restore', N'Respaldo', 12345678, N'R501qvjSpBONm683/R2EYgkjxxL2vVnwCryuo9Ncu1w=')
INSERT [dbo].[Evento] ([IdEvento], [Login], [Criticidad], [Fecha], [Hora], [NombreEvento], [Modulo], [DNI], [DVH]) VALUES (282, N'vicky', 1, CAST(N'2026-06-29' AS Date), CAST(N'21:15:06.3294866' AS Time), N'Logout', N'Usuario', 12345678, N'TqLBVOjeRPbjUCB6N+Inn0Nl0xGxQ+Koq4BFVUuhl7U=')
INSERT [dbo].[Evento] ([IdEvento], [Login], [Criticidad], [Fecha], [Hora], [NombreEvento], [Modulo], [DNI], [DVH]) VALUES (283, N'vicky', 1, CAST(N'2026-06-29' AS Date), CAST(N'21:15:10.8379563' AS Time), N'Login', N'Usuario', 12345678, N'aP8sY9C6MeBaJnfep3xzkY9EWXcewbf46VWDRMJ2xDE=')
INSERT [dbo].[Evento] ([IdEvento], [Login], [Criticidad], [Fecha], [Hora], [NombreEvento], [Modulo], [DNI], [DVH]) VALUES (284, N'vicky', 1, CAST(N'2026-06-29' AS Date), CAST(N'21:17:34.1994044' AS Time), N'Logout', N'Usuario', 12345678, N'8Yzx4+jaNulU44ZMf7K3AhbcN/rMeTWYs7PYrcHaq+I=')
INSERT [dbo].[Evento] ([IdEvento], [Login], [Criticidad], [Fecha], [Hora], [NombreEvento], [Modulo], [DNI], [DVH]) VALUES (285, N'vicky', 1, CAST(N'2026-06-29' AS Date), CAST(N'21:24:07.6164275' AS Time), N'Login', N'Usuario', 12345678, N'mrXqiBIdZU33fBOwfDZbRAatp03iP9oJUTmOZ/1Jl0g=')
INSERT [dbo].[Evento] ([IdEvento], [Login], [Criticidad], [Fecha], [Hora], [NombreEvento], [Modulo], [DNI], [DVH]) VALUES (286, N'vicky', 1, CAST(N'2026-06-29' AS Date), CAST(N'21:24:49.7933316' AS Time), N'Login', N'Usuario', 12345678, N'Ann9/lpASBja41Ur2oqU8rmksTeatpnsNACGteqQmoA=')
INSERT [dbo].[Evento] ([IdEvento], [Login], [Criticidad], [Fecha], [Hora], [NombreEvento], [Modulo], [DNI], [DVH]) VALUES (287, N'vicky', 1, CAST(N'2026-06-29' AS Date), CAST(N'21:25:59.1299350' AS Time), N'Login', N'Usuario', 12345678, N'49J9taqzdWJRQQlUHK424ZVrFbeEvAgc1sBq8nXO2WY=')
INSERT [dbo].[Evento] ([IdEvento], [Login], [Criticidad], [Fecha], [Hora], [NombreEvento], [Modulo], [DNI], [DVH]) VALUES (288, N'vicky', 1, CAST(N'2026-06-29' AS Date), CAST(N'21:28:05.3068383' AS Time), N'Login', N'Usuario', 12345678, N'5qiJyfhkWFVMMKsnVg1hfz1iC88HpjPIXLjaZeqK8FU=')
INSERT [dbo].[Evento] ([IdEvento], [Login], [Criticidad], [Fecha], [Hora], [NombreEvento], [Modulo], [DNI], [DVH]) VALUES (289, N'vicky', 1, CAST(N'2026-06-29' AS Date), CAST(N'21:28:07.6916012' AS Time), N'Cambio de Idioma', N'Idioma cambiado con éxito', 12345678, N'NBlJJQW+DJM/1y3/zUFREEkQ1HAhTToF0cw8lOyqJw0=')
INSERT [dbo].[Evento] ([IdEvento], [Login], [Criticidad], [Fecha], [Hora], [NombreEvento], [Modulo], [DNI], [DVH]) VALUES (290, N'vicky', 1, CAST(N'2026-06-29' AS Date), CAST(N'21:28:25.9392582' AS Time), N'Logout', N'Usuario', 12345678, N'JX97XpzQkcyabkQbRtY+qkGNs2mViYLyNJ/sOWVB2c8=')
INSERT [dbo].[Evento] ([IdEvento], [Login], [Criticidad], [Fecha], [Hora], [NombreEvento], [Modulo], [DNI], [DVH]) VALUES (291, N'vicky', 1, CAST(N'2026-06-29' AS Date), CAST(N'21:28:33.6862348' AS Time), N'Login', N'Usuario', 12345678, N'vMJUgL4UI/Jj4zPTzHamZGb7+bgHXn9dBPJrtmf2jwQ=')
INSERT [dbo].[Evento] ([IdEvento], [Login], [Criticidad], [Fecha], [Hora], [NombreEvento], [Modulo], [DNI], [DVH]) VALUES (292, N'vicky', 1, CAST(N'2026-06-29' AS Date), CAST(N'21:32:26.5242756' AS Time), N'Login', N'Usuario', 12345678, N'CtaGL5eC9oRU5dacghIqZnneu06IPOsn9nsYTOjtprQ=')
INSERT [dbo].[Evento] ([IdEvento], [Login], [Criticidad], [Fecha], [Hora], [NombreEvento], [Modulo], [DNI], [DVH]) VALUES (293, N'vicky', 1, CAST(N'2026-06-29' AS Date), CAST(N'21:32:29.1391373' AS Time), N'Logout', N'Usuario', 12345678, N'2Y4iRHS2fVno7zxVYU1zIdF9KdPKqULrXkLnJ2SZXYU=')
INSERT [dbo].[Evento] ([IdEvento], [Login], [Criticidad], [Fecha], [Hora], [NombreEvento], [Modulo], [DNI], [DVH]) VALUES (294, N'vicky', 1, CAST(N'2026-06-29' AS Date), CAST(N'23:07:23.2553944' AS Time), N'Login', N'Usuario', 12345678, N'xdQpddPEJJiAVqRHY2MDt/gMuOjW6LlIXcwiP7jqWUQ=')
INSERT [dbo].[Evento] ([IdEvento], [Login], [Criticidad], [Fecha], [Hora], [NombreEvento], [Modulo], [DNI], [DVH]) VALUES (295, N'vicky', 1, CAST(N'2026-06-29' AS Date), CAST(N'23:07:40.7790120' AS Time), N'Login', N'Usuario', 12345678, N'EqZMyw0FzVVr7tArxnodKMPb1d2jQebEEPy79zb5YBE=')
INSERT [dbo].[Evento] ([IdEvento], [Login], [Criticidad], [Fecha], [Hora], [NombreEvento], [Modulo], [DNI], [DVH]) VALUES (296, N'vicky', 1, CAST(N'2026-06-29' AS Date), CAST(N'23:07:52.4313399' AS Time), N'Cambio de Idioma', N'Idioma cambiado con éxito', 12345678, N'Z3H365wscbD++K3uoZYQPPQcJQmOVXbQLNydLD2OggA=')
INSERT [dbo].[Evento] ([IdEvento], [Login], [Criticidad], [Fecha], [Hora], [NombreEvento], [Modulo], [DNI], [DVH]) VALUES (297, N'vicky', 1, CAST(N'2026-06-29' AS Date), CAST(N'23:07:57.4104334' AS Time), N'Logout', N'Usuario', 12345678, N'eiR6IaRKk6XK3/vrLNMhPsgs6qUPCy5+AaPcLr1zkxY=')
INSERT [dbo].[Evento] ([IdEvento], [Login], [Criticidad], [Fecha], [Hora], [NombreEvento], [Modulo], [DNI], [DVH]) VALUES (298, N'vicky', 1, CAST(N'2026-06-29' AS Date), CAST(N'23:08:15.8364169' AS Time), N'Login', N'Usuario', 12345678, N'4MERQUfMex4mMMkzozTGncDNdZ/qZb2NWo2e45MeeOs=')
INSERT [dbo].[Evento] ([IdEvento], [Login], [Criticidad], [Fecha], [Hora], [NombreEvento], [Modulo], [DNI], [DVH]) VALUES (299, N'vicky', 1, CAST(N'2026-06-29' AS Date), CAST(N'23:08:22.6819945' AS Time), N'Logout', N'Usuario', 12345678, N'f+VIzLzPaKXhmXGiuAfzLjXVuvpt30BDVgbyY9T1Fbs=')
INSERT [dbo].[Evento] ([IdEvento], [Login], [Criticidad], [Fecha], [Hora], [NombreEvento], [Modulo], [DNI], [DVH]) VALUES (300, N'sofigesualdo', 1, CAST(N'2026-06-29' AS Date), CAST(N'23:08:30.3967427' AS Time), N'Login', N'Usuario', 46956657, N'+cF9cdgV3YbAu914QNFkRT2S5kQLm0y5mE1BhWYb350=')
GO
INSERT [dbo].[Evento] ([IdEvento], [Login], [Criticidad], [Fecha], [Hora], [NombreEvento], [Modulo], [DNI], [DVH]) VALUES (301, N'sofigesualdo', 1, CAST(N'2026-06-29' AS Date), CAST(N'23:08:33.6578411' AS Time), N'Logout', N'Usuario', 46956657, N'eB95tC7/6ToXk2tGlYVSmFUpv9o7ITnxJ56iH9K0XH8=')
INSERT [dbo].[Evento] ([IdEvento], [Login], [Criticidad], [Fecha], [Hora], [NombreEvento], [Modulo], [DNI], [DVH]) VALUES (302, N'vicky', 1, CAST(N'2026-06-29' AS Date), CAST(N'23:11:33.7712167' AS Time), N'Login', N'Usuario', 12345678, N'OKPcDcbR3Osl5uO/Brb3I3qIpPEXHSbrRFFL4CgnOsc=')
INSERT [dbo].[Evento] ([IdEvento], [Login], [Criticidad], [Fecha], [Hora], [NombreEvento], [Modulo], [DNI], [DVH]) VALUES (303, N'vicky', 1, CAST(N'2026-06-29' AS Date), CAST(N'23:14:35.2500988' AS Time), N'Login', N'Usuario', 12345678, N'gK8J5ZfVEjbVx3atDArrPYmso0qMMrtgKeKLfTMSNFA=')
INSERT [dbo].[Evento] ([IdEvento], [Login], [Criticidad], [Fecha], [Hora], [NombreEvento], [Modulo], [DNI], [DVH]) VALUES (304, N'vicky', 1, CAST(N'2026-06-29' AS Date), CAST(N'23:14:51.1547940' AS Time), N'Logout', N'Usuario', 12345678, N'Za3RZ2gFfyFzn+tkWQ1Tng35j99kTww3JR/SZakgJKw=')
INSERT [dbo].[Evento] ([IdEvento], [Login], [Criticidad], [Fecha], [Hora], [NombreEvento], [Modulo], [DNI], [DVH]) VALUES (305, N'vicky', 1, CAST(N'2026-06-29' AS Date), CAST(N'23:16:03.3417142' AS Time), N'Login', N'Usuario', 12345678, N'r3MVYid+YlK5ab5EOry+UvssDoe/egw3nXyXwliPd44=')
INSERT [dbo].[Evento] ([IdEvento], [Login], [Criticidad], [Fecha], [Hora], [NombreEvento], [Modulo], [DNI], [DVH]) VALUES (306, N'vicky', 1, CAST(N'2026-06-29' AS Date), CAST(N'23:16:06.4904660' AS Time), N'Cambio de Idioma', N'Idioma cambiado con éxito', 12345678, N'41A+g76SMNymO/ecZZ4AIn14VSZshqViRYeiSt6Ot80=')
INSERT [dbo].[Evento] ([IdEvento], [Login], [Criticidad], [Fecha], [Hora], [NombreEvento], [Modulo], [DNI], [DVH]) VALUES (307, N'vicky', 1, CAST(N'2026-06-29' AS Date), CAST(N'23:25:18.0664979' AS Time), N'Login', N'Usuario', 12345678, N'FbrQzeovXZczqEFaC2+2k13suzlVbW+SU7RpGHlArfo=')
INSERT [dbo].[Evento] ([IdEvento], [Login], [Criticidad], [Fecha], [Hora], [NombreEvento], [Modulo], [DNI], [DVH]) VALUES (308, N'vicky', 1, CAST(N'2026-06-29' AS Date), CAST(N'23:25:20.7478460' AS Time), N'Cambio de Idioma', N'Idioma cambiado con éxito', 12345678, N'vME1wFRW4VfY5ANEdsWH7o2KEJ7VPmxfC28vrOqxzaA=')
INSERT [dbo].[Evento] ([IdEvento], [Login], [Criticidad], [Fecha], [Hora], [NombreEvento], [Modulo], [DNI], [DVH]) VALUES (309, N'vicky', 1, CAST(N'2026-06-29' AS Date), CAST(N'23:30:13.8714574' AS Time), N'Login', N'Usuario', 12345678, N'jRm8WHokBH7JfgLc+fUlRwWUWvbxjUC/DhFUmxtiioA=')
INSERT [dbo].[Evento] ([IdEvento], [Login], [Criticidad], [Fecha], [Hora], [NombreEvento], [Modulo], [DNI], [DVH]) VALUES (310, N'vicky', 1, CAST(N'2026-06-29' AS Date), CAST(N'23:30:16.3048273' AS Time), N'Cambio de Idioma', N'Idioma cambiado con éxito', 12345678, N'JhTPXXya7aQUw+D1OGlaBRvq6tN2DJDXE9WRh0Pt/KU=')
INSERT [dbo].[Evento] ([IdEvento], [Login], [Criticidad], [Fecha], [Hora], [NombreEvento], [Modulo], [DNI], [DVH]) VALUES (311, N'vicky', 1, CAST(N'2026-06-29' AS Date), CAST(N'23:30:22.4080945' AS Time), N'Cambio de Idioma', N'Idioma cambiado con éxito', 12345678, N'ls5axki9oJB9fD0Gia57afJo2d6MROwdV0xlogDqAxk=')
INSERT [dbo].[Evento] ([IdEvento], [Login], [Criticidad], [Fecha], [Hora], [NombreEvento], [Modulo], [DNI], [DVH]) VALUES (312, N'vicky', 1, CAST(N'2026-06-29' AS Date), CAST(N'23:30:29.8799425' AS Time), N'Cambio de Idioma', N'Idioma cambiado con éxito', 12345678, N'9IKM3/w4dFwYtikez2HHDCUnXjfZDyUrdKG0rBn0axc=')
INSERT [dbo].[Evento] ([IdEvento], [Login], [Criticidad], [Fecha], [Hora], [NombreEvento], [Modulo], [DNI], [DVH]) VALUES (313, N'vicky', 1, CAST(N'2026-06-29' AS Date), CAST(N'23:31:43.0282674' AS Time), N'Realizar Restore', N'Respaldos', 12345678, N'du5RjeeZdFGAFkv2HpiOF9hJDVzZLg820PgrEvYZsdU=')
INSERT [dbo].[Evento] ([IdEvento], [Login], [Criticidad], [Fecha], [Hora], [NombreEvento], [Modulo], [DNI], [DVH]) VALUES (314, N'vicky', 1, CAST(N'2026-06-29' AS Date), CAST(N'23:31:45.8295065' AS Time), N'Logout', N'Usuario', 12345678, N'2CAHtaIyNUKrm/scjpYU1QV/N2z618vsWvBFU2a3nR8=')
INSERT [dbo].[Evento] ([IdEvento], [Login], [Criticidad], [Fecha], [Hora], [NombreEvento], [Modulo], [DNI], [DVH]) VALUES (315, N'vicky', 1, CAST(N'2026-06-29' AS Date), CAST(N'23:31:52.3188185' AS Time), N'Login', N'Usuario', 12345678, N'ej7hzLO0kJ6yFJm7MKvuSFmakpVbHxpj9sdmtQI1618=')
INSERT [dbo].[Evento] ([IdEvento], [Login], [Criticidad], [Fecha], [Hora], [NombreEvento], [Modulo], [DNI], [DVH]) VALUES (316, N'vicky', 1, CAST(N'2026-06-29' AS Date), CAST(N'23:32:05.9675656' AS Time), N'Cambio de Idioma', N'Idioma cambiado con éxito', 12345678, N'xymAE0XzHfEo78x+udXZMZchXiTiC9kyy2KYIy3CNTE=')
INSERT [dbo].[Evento] ([IdEvento], [Login], [Criticidad], [Fecha], [Hora], [NombreEvento], [Modulo], [DNI], [DVH]) VALUES (317, N'vicky', 1, CAST(N'2026-06-29' AS Date), CAST(N'23:32:40.0151414' AS Time), N'Logout', N'Usuario', 12345678, N'TbMRoqLdcT3Gq/2+Peo8DexrblJxNmeg2W/rR5IBQm4=')
INSERT [dbo].[Evento] ([IdEvento], [Login], [Criticidad], [Fecha], [Hora], [NombreEvento], [Modulo], [DNI], [DVH]) VALUES (318, N'vicky', 1, CAST(N'2026-07-01' AS Date), CAST(N'20:31:41.4088341' AS Time), N'Logout', N'Usuario', 12345678, N'K7B0DG0HC0Qaw59VV3+T8esnPcbq2vk0K3FDQLW7nyo=')
INSERT [dbo].[Evento] ([IdEvento], [Login], [Criticidad], [Fecha], [Hora], [NombreEvento], [Modulo], [DNI], [DVH]) VALUES (319, N'vicky', 1, CAST(N'2026-07-01' AS Date), CAST(N'20:56:39.0177475' AS Time), N'Logout', N'Usuario', 12345678, N'guCK/833trUvxuhbnU1bxPyVdx9uvBS+VI3GDZ7o9WA=')
INSERT [dbo].[Evento] ([IdEvento], [Login], [Criticidad], [Fecha], [Hora], [NombreEvento], [Modulo], [DNI], [DVH]) VALUES (320, N'vicky', 1, CAST(N'2026-07-01' AS Date), CAST(N'20:59:15.1230701' AS Time), N'Login', N'Usuario', 12345678, N'lfh7TOGL284zawKUa8GPouUgILqcCs+Qqrr9ekH/w3A=')
INSERT [dbo].[Evento] ([IdEvento], [Login], [Criticidad], [Fecha], [Hora], [NombreEvento], [Modulo], [DNI], [DVH]) VALUES (321, N'vicky', 1, CAST(N'2026-07-01' AS Date), CAST(N'20:59:29.1775336' AS Time), N'Cambio de Idioma', N'Idioma cambiado con éxito', 12345678, N'dzuCImw8b4MAhB/kkm4KKmpDrawc3F58hc8CNGGFs/U=')
INSERT [dbo].[Evento] ([IdEvento], [Login], [Criticidad], [Fecha], [Hora], [NombreEvento], [Modulo], [DNI], [DVH]) VALUES (322, N'vicky', 1, CAST(N'2026-07-01' AS Date), CAST(N'20:59:54.2014115' AS Time), N'Logout', N'Usuario', 12345678, N'0htHwmOW3Yr9t7pf6FOK8If0HSZ1Nb9bbGxHP62NCVc=')
INSERT [dbo].[Evento] ([IdEvento], [Login], [Criticidad], [Fecha], [Hora], [NombreEvento], [Modulo], [DNI], [DVH]) VALUES (323, N'vicky', 1, CAST(N'2026-07-01' AS Date), CAST(N'21:01:20.5566364' AS Time), N'Login', N'Usuario', 12345678, N'GqtAZSIxS1BMMkVElKgHZ/r5rn+6oHp5eoBCPeSOvEo=')
INSERT [dbo].[Evento] ([IdEvento], [Login], [Criticidad], [Fecha], [Hora], [NombreEvento], [Modulo], [DNI], [DVH]) VALUES (324, N'vicky', 1, CAST(N'2026-07-01' AS Date), CAST(N'21:01:36.1999526' AS Time), N'Logout', N'Usuario', 12345678, N'xaYgTMNLKcqVv7iXuLAk21LlRdWoR43iCPu8ZgtONEs=')
INSERT [dbo].[Evento] ([IdEvento], [Login], [Criticidad], [Fecha], [Hora], [NombreEvento], [Modulo], [DNI], [DVH]) VALUES (325, N'vicky', 1, CAST(N'2026-07-01' AS Date), CAST(N'21:02:37.9023294' AS Time), N'Logout', N'Usuario', 12345678, N'QzKx+yDl/Dr14Q7aG2l+U5Dvq4PpsfCM+f+YAZZsCWE=')
INSERT [dbo].[Evento] ([IdEvento], [Login], [Criticidad], [Fecha], [Hora], [NombreEvento], [Modulo], [DNI], [DVH]) VALUES (326, N'vicky', 1, CAST(N'2026-07-01' AS Date), CAST(N'21:03:03.5154981' AS Time), N'Login', N'Usuario', 12345678, N'jFA6f0Ya+0iZuApBLJ7apDvEtpfPETdDvg0W/xCDVzs=')
INSERT [dbo].[Evento] ([IdEvento], [Login], [Criticidad], [Fecha], [Hora], [NombreEvento], [Modulo], [DNI], [DVH]) VALUES (327, N'vicky', 1, CAST(N'2026-07-01' AS Date), CAST(N'21:03:07.8196015' AS Time), N'Logout', N'Usuario', 12345678, N'DVKnLqmblpL/wQ5x2j8JoeMzk2H1KNtKxWaeNf6Aw2s=')
INSERT [dbo].[Evento] ([IdEvento], [Login], [Criticidad], [Fecha], [Hora], [NombreEvento], [Modulo], [DNI], [DVH]) VALUES (328, N'sofigesualdo', 1, CAST(N'2026-07-01' AS Date), CAST(N'21:03:12.6051519' AS Time), N'Login', N'Usuario', 46956657, N'iBJ0dEChEmLHE8ffCOxqB71uURcxQqkUYyX9hAhc85g=')
INSERT [dbo].[Evento] ([IdEvento], [Login], [Criticidad], [Fecha], [Hora], [NombreEvento], [Modulo], [DNI], [DVH]) VALUES (329, N'sofigesualdo', 1, CAST(N'2026-07-01' AS Date), CAST(N'21:03:17.3496217' AS Time), N'Logout', N'Usuario', 46956657, N'1pNSXREAuYM2mZ/jzXMEyZWBl1S4GWrc5UlAPXGNG7s=')
INSERT [dbo].[Evento] ([IdEvento], [Login], [Criticidad], [Fecha], [Hora], [NombreEvento], [Modulo], [DNI], [DVH]) VALUES (330, N'vicky', 1, CAST(N'2026-07-01' AS Date), CAST(N'21:13:13.4964664' AS Time), N'Login', N'Usuario', 12345678, N'ZbhWCs0o4VvJnKwVRki2xKmnR3pBSBIrnfYVnOYLrHU=')
INSERT [dbo].[Evento] ([IdEvento], [Login], [Criticidad], [Fecha], [Hora], [NombreEvento], [Modulo], [DNI], [DVH]) VALUES (331, N'vicky', 1, CAST(N'2026-07-01' AS Date), CAST(N'21:13:19.4389157' AS Time), N'Cambio de Idioma', N'Idioma cambiado con éxito', 12345678, N'qIAS6Zr2zKdMfaNL2lAVkowfF9BREZtGlQ98VZyxFbs=')
INSERT [dbo].[Evento] ([IdEvento], [Login], [Criticidad], [Fecha], [Hora], [NombreEvento], [Modulo], [DNI], [DVH]) VALUES (332, N'vicky', 1, CAST(N'2026-07-01' AS Date), CAST(N'21:13:21.5169240' AS Time), N'Logout', N'Usuario', 12345678, N'p/NR2KGFyPaF9ddgKCGap1keb+I6LA5mncmhU2D+FZA=')
INSERT [dbo].[Evento] ([IdEvento], [Login], [Criticidad], [Fecha], [Hora], [NombreEvento], [Modulo], [DNI], [DVH]) VALUES (333, N'vicky', 1, CAST(N'2026-07-01' AS Date), CAST(N'21:14:04.5887071' AS Time), N'Login', N'Usuario', 12345678, N'3qn75LlcyCav0ed5iVF7792AN9/c+BgxCThdDSgRlhE=')
INSERT [dbo].[Evento] ([IdEvento], [Login], [Criticidad], [Fecha], [Hora], [NombreEvento], [Modulo], [DNI], [DVH]) VALUES (334, N'vicky', 1, CAST(N'2026-07-01' AS Date), CAST(N'22:13:53.3694963' AS Time), N'Login', N'Usuario', 12345678, N'ZkMig7B2FFxXJDGeta1R8APouqYTQ/P1Ikq4D7ghb5I=')
INSERT [dbo].[Evento] ([IdEvento], [Login], [Criticidad], [Fecha], [Hora], [NombreEvento], [Modulo], [DNI], [DVH]) VALUES (335, N'vicky', 1, CAST(N'2026-07-01' AS Date), CAST(N'22:16:07.1553244' AS Time), N'Realizar Restore', N'Respaldos', 12345678, N'/Ce3y++yjV1pIY5aFzWCvB7Jq63aXl0FBwCB09H3cdk=')
INSERT [dbo].[Evento] ([IdEvento], [Login], [Criticidad], [Fecha], [Hora], [NombreEvento], [Modulo], [DNI], [DVH]) VALUES (336, N'vicky', 1, CAST(N'2026-07-01' AS Date), CAST(N'22:16:10.0982508' AS Time), N'Logout', N'Usuario', 12345678, N'5JriUOkBxGYzTwCmAicdbw4lZAEVAYh42kqtztFC0Dk=')
INSERT [dbo].[Evento] ([IdEvento], [Login], [Criticidad], [Fecha], [Hora], [NombreEvento], [Modulo], [DNI], [DVH]) VALUES (337, N'vicky', 1, CAST(N'2026-07-01' AS Date), CAST(N'22:16:13.5434418' AS Time), N'Login', N'Usuario', 12345678, N'GL3gXPbXVQwVQXpJsjKKru29bBJLejlpfzgDj8kC4T4=')
INSERT [dbo].[Evento] ([IdEvento], [Login], [Criticidad], [Fecha], [Hora], [NombreEvento], [Modulo], [DNI], [DVH]) VALUES (338, N'vicky', 1, CAST(N'2026-07-01' AS Date), CAST(N'22:16:45.1604024' AS Time), N'Logout', N'Usuario', 12345678, N'YfNAKq9TunXactGow2Ld54oPqoxUyzzLdjuo3uM8hIM=')
INSERT [dbo].[Evento] ([IdEvento], [Login], [Criticidad], [Fecha], [Hora], [NombreEvento], [Modulo], [DNI], [DVH]) VALUES (339, N'vicky', 1, CAST(N'2026-07-01' AS Date), CAST(N'23:22:47.1158180' AS Time), N'Login', N'Usuario', 12345678, N'6mOWeG9SvpApD1/wn++jeTGb8GyNEkuTTowNxx7nkrk=')
INSERT [dbo].[Evento] ([IdEvento], [Login], [Criticidad], [Fecha], [Hora], [NombreEvento], [Modulo], [DNI], [DVH]) VALUES (340, N'vicky', 1, CAST(N'2026-07-01' AS Date), CAST(N'23:22:53.9281321' AS Time), N'Logout', N'Usuario', 12345678, N'QurWOjIYyx/KHRGaUGPJ44nGs7mPmbA44ta2cDOeecU=')
INSERT [dbo].[Evento] ([IdEvento], [Login], [Criticidad], [Fecha], [Hora], [NombreEvento], [Modulo], [DNI], [DVH]) VALUES (341, N'vicky', 1, CAST(N'2026-07-02' AS Date), CAST(N'00:26:38.1501706' AS Time), N'Login', N'Usuario', 12345678, N'5aJ3e1KekKTemqeFAswejYWHiLixi4tTmSX06gku/wg=')
INSERT [dbo].[Evento] ([IdEvento], [Login], [Criticidad], [Fecha], [Hora], [NombreEvento], [Modulo], [DNI], [DVH]) VALUES (342, N'vicky', 1, CAST(N'2026-07-02' AS Date), CAST(N'00:26:53.6663339' AS Time), N'Logout', N'Usuario', 12345678, N'QQ66+IdJNe/IXM/SVHdVFkgHMyD0a6HC7oJMGQ+7+bk=')
INSERT [dbo].[Evento] ([IdEvento], [Login], [Criticidad], [Fecha], [Hora], [NombreEvento], [Modulo], [DNI], [DVH]) VALUES (343, N'vicky', 1, CAST(N'2026-07-02' AS Date), CAST(N'17:06:52.6161562' AS Time), N'Login', N'Usuario', 12345678, N'cHnhN2RwkbgtWqvTnAIZbgNcB2g1drHJyeD5hcWoISs=')
INSERT [dbo].[Evento] ([IdEvento], [Login], [Criticidad], [Fecha], [Hora], [NombreEvento], [Modulo], [DNI], [DVH]) VALUES (344, N'vicky', 1, CAST(N'2026-07-02' AS Date), CAST(N'17:07:02.2289908' AS Time), N'Logout', N'Usuario', 12345678, N'L4B278cJRq5Huod+lHDW9FS6wa3jn7ne+eLxkycQkIw=')
INSERT [dbo].[Evento] ([IdEvento], [Login], [Criticidad], [Fecha], [Hora], [NombreEvento], [Modulo], [DNI], [DVH]) VALUES (345, N'vicky', 1, CAST(N'2026-07-02' AS Date), CAST(N'23:54:29.1846153' AS Time), N'Login', N'Usuario', 12345678, N'At+5+mQfl/r0bCJReHsihGYzA90Iwre9LAtltSKb5mk=')
INSERT [dbo].[Evento] ([IdEvento], [Login], [Criticidad], [Fecha], [Hora], [NombreEvento], [Modulo], [DNI], [DVH]) VALUES (346, N'vicky', 1, CAST(N'2026-07-02' AS Date), CAST(N'23:54:32.2843641' AS Time), N'Cambio de Idioma', N'Idioma cambiado con éxito', 12345678, N'gzkXu/szA/NwW3qODFKbQBqvGLB6k34mehUBLpb2/A4=')
INSERT [dbo].[Evento] ([IdEvento], [Login], [Criticidad], [Fecha], [Hora], [NombreEvento], [Modulo], [DNI], [DVH]) VALUES (347, N'vicky', 1, CAST(N'2026-07-02' AS Date), CAST(N'23:58:43.9721179' AS Time), N'Login', N'Usuario', 12345678, N'6jlbk+ba8C65IL4lDSJmMjj/TebTWDKGdfkvHWncsyM=')
INSERT [dbo].[Evento] ([IdEvento], [Login], [Criticidad], [Fecha], [Hora], [NombreEvento], [Modulo], [DNI], [DVH]) VALUES (348, N'vicky', 1, CAST(N'2026-07-03' AS Date), CAST(N'00:14:45.3159546' AS Time), N'Login', N'Usuario', 12345678, N'e2Zh8hndINGfIDJyMKxfHvMztosV7dHN/L2vTLQQhao=')
INSERT [dbo].[Evento] ([IdEvento], [Login], [Criticidad], [Fecha], [Hora], [NombreEvento], [Modulo], [DNI], [DVH]) VALUES (349, N'vicky', 1, CAST(N'2026-07-03' AS Date), CAST(N'00:14:48.6138003' AS Time), N'Cambio de Idioma', N'Idioma cambiado con éxito', 12345678, N'GeXUjIth9PTnrSyxouECag8PSAcqVYVbyCK8+gNUdeI=')
INSERT [dbo].[Evento] ([IdEvento], [Login], [Criticidad], [Fecha], [Hora], [NombreEvento], [Modulo], [DNI], [DVH]) VALUES (350, N'vicky', 1, CAST(N'2026-07-03' AS Date), CAST(N'00:21:41.2064852' AS Time), N'Login', N'Usuario', 12345678, N'z0b1coMi3CwVYg9Q4VCNc3y8tiS0S6NFJEjU1S3UB3I=')
INSERT [dbo].[Evento] ([IdEvento], [Login], [Criticidad], [Fecha], [Hora], [NombreEvento], [Modulo], [DNI], [DVH]) VALUES (351, N'vicky', 1, CAST(N'2026-07-03' AS Date), CAST(N'00:21:46.1241902' AS Time), N'Cambio de Idioma', N'Idioma cambiado con éxito', 12345678, N'PpjbdYHoJiP2TC7slSjhCCGB6qKi6ghXh2IgYalHV/Q=')
INSERT [dbo].[Evento] ([IdEvento], [Login], [Criticidad], [Fecha], [Hora], [NombreEvento], [Modulo], [DNI], [DVH]) VALUES (352, N'vicky', 1, CAST(N'2026-07-03' AS Date), CAST(N'00:24:23.2743810' AS Time), N'Login', N'Usuario', 12345678, N'ctL+wMupawxf3CBIw/KgUfwXM6feT639TnkMauwQ7Lc=')
INSERT [dbo].[Evento] ([IdEvento], [Login], [Criticidad], [Fecha], [Hora], [NombreEvento], [Modulo], [DNI], [DVH]) VALUES (353, N'vicky', 1, CAST(N'2026-07-03' AS Date), CAST(N'00:24:25.7968528' AS Time), N'Cambio de Idioma', N'Idioma cambiado con éxito', 12345678, N'EY2RMdGDhJ79w0bbR+qzBszRkJVCnYY4bcFazi94oso=')
INSERT [dbo].[Evento] ([IdEvento], [Login], [Criticidad], [Fecha], [Hora], [NombreEvento], [Modulo], [DNI], [DVH]) VALUES (354, N'vicky', 1, CAST(N'2026-07-03' AS Date), CAST(N'00:25:22.0131700' AS Time), N'Login', N'Usuario', 12345678, N'C3vWaA/uv56qu+mWNwry332QDh2PZGFrlXsLhPnLzpE=')
INSERT [dbo].[Evento] ([IdEvento], [Login], [Criticidad], [Fecha], [Hora], [NombreEvento], [Modulo], [DNI], [DVH]) VALUES (355, N'vicky', 1, CAST(N'2026-07-03' AS Date), CAST(N'00:25:24.5608358' AS Time), N'Cambio de Idioma', N'Idioma cambiado con éxito', 12345678, N'Y3O2o+kGl3FggvDFDa8bfPz8OoF9dpDVXKQT8j6Vosw=')
INSERT [dbo].[Evento] ([IdEvento], [Login], [Criticidad], [Fecha], [Hora], [NombreEvento], [Modulo], [DNI], [DVH]) VALUES (356, N'vicky', 1, CAST(N'2026-07-03' AS Date), CAST(N'00:25:59.7550844' AS Time), N'Login', N'Usuario', 12345678, N'cXRJI6eLDLhS/JKDOWlRp0t5++2a5mfKYHoXVAtcLRA=')
INSERT [dbo].[Evento] ([IdEvento], [Login], [Criticidad], [Fecha], [Hora], [NombreEvento], [Modulo], [DNI], [DVH]) VALUES (357, N'vicky', 1, CAST(N'2026-07-03' AS Date), CAST(N'00:26:22.5265224' AS Time), N'Login', N'Usuario', 12345678, N'8NgnjxMBp7LQ78H6+ITftkPH6PAJ/HxuvALj+erdgQs=')
INSERT [dbo].[Evento] ([IdEvento], [Login], [Criticidad], [Fecha], [Hora], [NombreEvento], [Modulo], [DNI], [DVH]) VALUES (358, N'vicky', 1, CAST(N'2026-07-03' AS Date), CAST(N'00:32:59.5347568' AS Time), N'Login', N'Usuario', 12345678, N'9vqopN+4xoSeKJ0H5R4Vz+S1kVuIDOl/wTBokifmwro=')
INSERT [dbo].[Evento] ([IdEvento], [Login], [Criticidad], [Fecha], [Hora], [NombreEvento], [Modulo], [DNI], [DVH]) VALUES (359, N'vicky', 1, CAST(N'2026-07-03' AS Date), CAST(N'00:33:08.0374943' AS Time), N'Modificar Usuario: sofigesualdo', N'Usuario', 12345678, N'iaTqZ6vxWwZgVYENDmT6T6wPhA8oWpbWwoodBCsJtjQ=')
INSERT [dbo].[Evento] ([IdEvento], [Login], [Criticidad], [Fecha], [Hora], [NombreEvento], [Modulo], [DNI], [DVH]) VALUES (360, N'vicky', 1, CAST(N'2026-07-03' AS Date), CAST(N'00:33:11.5975840' AS Time), N'Modificar Usuario: sofigesualdo', N'Usuario', 12345678, N'+tf06tVb0IsqPB3HxuADi6o3A0vAc9HWMNMtdzwZfOY=')
INSERT [dbo].[Evento] ([IdEvento], [Login], [Criticidad], [Fecha], [Hora], [NombreEvento], [Modulo], [DNI], [DVH]) VALUES (361, N'vicky', 1, CAST(N'2026-07-03' AS Date), CAST(N'00:33:14.1542246' AS Time), N'Modificar Usuario: sofigesualdo', N'Usuario', 12345678, N'BXMKhv6lbygfKZTuNZY7Q2/2lQdh6lnSfb7Kxg+q8/U=')
INSERT [dbo].[Evento] ([IdEvento], [Login], [Criticidad], [Fecha], [Hora], [NombreEvento], [Modulo], [DNI], [DVH]) VALUES (362, N'vicky', 1, CAST(N'2026-07-03' AS Date), CAST(N'00:33:15.2680785' AS Time), N'Modificar Usuario: sofigesualdo', N'Usuario', 12345678, N'Kr94BDfA7/jVuYpx2ArOdeywDYf+/iBm0ljChtvz9W4=')
INSERT [dbo].[Evento] ([IdEvento], [Login], [Criticidad], [Fecha], [Hora], [NombreEvento], [Modulo], [DNI], [DVH]) VALUES (363, N'vicky', 1, CAST(N'2026-07-03' AS Date), CAST(N'00:33:15.8512112' AS Time), N'Modificar Usuario: sofigesualdo', N'Usuario', 12345678, N'ehIKfB6HEypqY0+tm1LSmeZI6aNU0YB9j2wcPcj785U=')
INSERT [dbo].[Evento] ([IdEvento], [Login], [Criticidad], [Fecha], [Hora], [NombreEvento], [Modulo], [DNI], [DVH]) VALUES (364, N'vicky', 1, CAST(N'2026-07-03' AS Date), CAST(N'00:33:16.1139532' AS Time), N'Modificar Usuario: sofigesualdo', N'Usuario', 12345678, N'14PIevZs6vTlOciJ81h6GXChxHPBB0sd0T83XfCZAcw=')
INSERT [dbo].[Evento] ([IdEvento], [Login], [Criticidad], [Fecha], [Hora], [NombreEvento], [Modulo], [DNI], [DVH]) VALUES (365, N'vicky', 1, CAST(N'2026-07-03' AS Date), CAST(N'00:33:16.3068504' AS Time), N'Modificar Usuario: sofigesualdo', N'Usuario', 12345678, N'WHKwapAdlUblY9ct74Y9r2N4+79Fq+VMDpwqtO7rW98=')
INSERT [dbo].[Evento] ([IdEvento], [Login], [Criticidad], [Fecha], [Hora], [NombreEvento], [Modulo], [DNI], [DVH]) VALUES (366, N'vicky', 1, CAST(N'2026-07-03' AS Date), CAST(N'00:33:16.4746331' AS Time), N'Modificar Usuario: sofigesualdo', N'Usuario', 12345678, N'1tjM+P8ByDwowAHOhJE7/HkWZAcp7nZl0VVRjWfm6ZI=')
INSERT [dbo].[Evento] ([IdEvento], [Login], [Criticidad], [Fecha], [Hora], [NombreEvento], [Modulo], [DNI], [DVH]) VALUES (367, N'vicky', 1, CAST(N'2026-07-03' AS Date), CAST(N'00:33:16.6408415' AS Time), N'Modificar Usuario: sofigesualdo', N'Usuario', 12345678, N'fIr1qccLnG+MFUEXk9HCN/ZE/vNTSVZlcue/trZw4II=')
INSERT [dbo].[Evento] ([IdEvento], [Login], [Criticidad], [Fecha], [Hora], [NombreEvento], [Modulo], [DNI], [DVH]) VALUES (368, N'vicky', 1, CAST(N'2026-07-03' AS Date), CAST(N'00:33:16.8035490' AS Time), N'Modificar Usuario: sofigesualdo', N'Usuario', 12345678, N'1f8ahhRj4rdlsF8qKXlsJLXQ+IVmkvhKxd4wVUj675U=')
INSERT [dbo].[Evento] ([IdEvento], [Login], [Criticidad], [Fecha], [Hora], [NombreEvento], [Modulo], [DNI], [DVH]) VALUES (369, N'vicky', 1, CAST(N'2026-07-03' AS Date), CAST(N'00:42:20.3739079' AS Time), N'Login', N'Usuario', 12345678, N'XS6VNaDwoSt71hKZ6hlo+T8yDb/HtEm8HAOeyE1j0tg=')
INSERT [dbo].[Evento] ([IdEvento], [Login], [Criticidad], [Fecha], [Hora], [NombreEvento], [Modulo], [DNI], [DVH]) VALUES (370, N'vicky', 1, CAST(N'2026-07-03' AS Date), CAST(N'00:42:37.0395988' AS Time), N'Modificar Usuario: sofigesualdo', N'Usuario', 12345678, N'Ci/Ff2xFUeLT+ejfroSpgZc+K5/pJCQdjVBOJDEq8UY=')
INSERT [dbo].[Evento] ([IdEvento], [Login], [Criticidad], [Fecha], [Hora], [NombreEvento], [Modulo], [DNI], [DVH]) VALUES (371, N'vicky', 1, CAST(N'2026-07-03' AS Date), CAST(N'00:42:39.3130179' AS Time), N'Modificar Usuario: sofigesualdo', N'Usuario', 12345678, N'axSCtzgB8oc/WULICNwgp2JQRVP0wvs+++O86TcZx60=')
INSERT [dbo].[Evento] ([IdEvento], [Login], [Criticidad], [Fecha], [Hora], [NombreEvento], [Modulo], [DNI], [DVH]) VALUES (372, N'vicky', 1, CAST(N'2026-07-03' AS Date), CAST(N'00:43:37.6428148' AS Time), N'Login', N'Usuario', 12345678, N'KIPRJODCV0Q8FAxWL20eLCka36GloYlbniFY+qpamb4=')
INSERT [dbo].[Evento] ([IdEvento], [Login], [Criticidad], [Fecha], [Hora], [NombreEvento], [Modulo], [DNI], [DVH]) VALUES (373, N'vicky', 1, CAST(N'2026-07-03' AS Date), CAST(N'00:47:01.0367177' AS Time), N'Login', N'Usuario', 12345678, N'gUU/kNTJYGlofqF+F8M3HntSthop4G8z+UtUcWKEkI8=')
INSERT [dbo].[Evento] ([IdEvento], [Login], [Criticidad], [Fecha], [Hora], [NombreEvento], [Modulo], [DNI], [DVH]) VALUES (374, N'vicky', 1, CAST(N'2026-07-03' AS Date), CAST(N'00:47:08.7280962' AS Time), N'Modificar Usuario: sofigesualdo', N'Usuario', 12345678, N'kELUzq26tu6dzaVnOySbTZ3UaiVumEFF9p29Fm0GKk4=')
INSERT [dbo].[Evento] ([IdEvento], [Login], [Criticidad], [Fecha], [Hora], [NombreEvento], [Modulo], [DNI], [DVH]) VALUES (375, N'vicky', 1, CAST(N'2026-07-03' AS Date), CAST(N'00:47:12.4417105' AS Time), N'Modificar Usuario: sofigesualdo', N'Usuario', 12345678, N'mrUIAIPNDg8/TyhEkw7Oj9+ozLFuiLPCh5psXpM0PJ0=')
INSERT [dbo].[Evento] ([IdEvento], [Login], [Criticidad], [Fecha], [Hora], [NombreEvento], [Modulo], [DNI], [DVH]) VALUES (376, N'sofigesualdo', 1, CAST(N'2026-08-31' AS Date), CAST(N'10:12:58.5870402' AS Time), N'Login', N'Usuario', 46956657, N'49YwIQX0T7mk52AHZgOhb+d7DRkotBXVV1mH1X1lxoc=')
INSERT [dbo].[Evento] ([IdEvento], [Login], [Criticidad], [Fecha], [Hora], [NombreEvento], [Modulo], [DNI], [DVH]) VALUES (377, N'sofigesualdo', 1, CAST(N'2026-08-31' AS Date), CAST(N'12:12:30.4971395' AS Time), N'Login', N'Usuario', 46956657, N'XCJhhoi98jGBJtMCnPVBjPQCllvdDiVTG0cQJel9yLY=')
INSERT [dbo].[Evento] ([IdEvento], [Login], [Criticidad], [Fecha], [Hora], [NombreEvento], [Modulo], [DNI], [DVH]) VALUES (378, N'sofigesualdo', 1, CAST(N'2026-08-31' AS Date), CAST(N'12:13:43.7610263' AS Time), N'Login', N'Usuario', 46956657, N'9lHFLO27ir8IwslVpp9UXsRTELiLHmZcgUR4A5ll0d8=')
INSERT [dbo].[Evento] ([IdEvento], [Login], [Criticidad], [Fecha], [Hora], [NombreEvento], [Modulo], [DNI], [DVH]) VALUES (379, N'sofigesualdo', 1, CAST(N'2026-08-31' AS Date), CAST(N'12:14:14.2962170' AS Time), N'Login', N'Usuario', 46956657, N'7SzYC+OAN+Fa42C76f/LFbjJ+JiiZydU/k7AS83WeFU=')
INSERT [dbo].[Evento] ([IdEvento], [Login], [Criticidad], [Fecha], [Hora], [NombreEvento], [Modulo], [DNI], [DVH]) VALUES (380, N'sofigesualdo', 1, CAST(N'2026-08-31' AS Date), CAST(N'12:21:36.7133875' AS Time), N'Login', N'Usuario', 46956657, N'W4ecoLA8Kfo996lEEzUssk9V84Wdivl/QVGRQaD8gPE=')
INSERT [dbo].[Evento] ([IdEvento], [Login], [Criticidad], [Fecha], [Hora], [NombreEvento], [Modulo], [DNI], [DVH]) VALUES (381, N'sofigesualdo', 1, CAST(N'2026-08-31' AS Date), CAST(N'12:24:07.6817536' AS Time), N'Login', N'Usuario', 46956657, N'X3awmA26055VO5XUa85JawYJFP9raETaVGJn2iqqWHs=')
INSERT [dbo].[Evento] ([IdEvento], [Login], [Criticidad], [Fecha], [Hora], [NombreEvento], [Modulo], [DNI], [DVH]) VALUES (382, N'sofigesualdo', 1, CAST(N'2026-08-31' AS Date), CAST(N'12:24:59.4981827' AS Time), N'Login', N'Usuario', 46956657, N'tKPXYhEmvjpahvVusqZbngHjnKt6DVCUePqpSi+7jtM=')
INSERT [dbo].[Evento] ([IdEvento], [Login], [Criticidad], [Fecha], [Hora], [NombreEvento], [Modulo], [DNI], [DVH]) VALUES (383, N'sofigesualdo', 1, CAST(N'2026-08-31' AS Date), CAST(N'12:25:44.4964416' AS Time), N'Login', N'Usuario', 46956657, N'3KfK3h9fY6RmCaSSbvvYsG1+YDcprzuDkJQ9sA7jjdA=')
INSERT [dbo].[Evento] ([IdEvento], [Login], [Criticidad], [Fecha], [Hora], [NombreEvento], [Modulo], [DNI], [DVH]) VALUES (384, N'sofigesualdo', 1, CAST(N'2026-08-31' AS Date), CAST(N'12:26:33.0677604' AS Time), N'Login', N'Usuario', 46956657, N'+4PDNW9K1fCTOQQU91A/lO3xrIDUNnyXlBB2Hv7Nnj8=')
INSERT [dbo].[Evento] ([IdEvento], [Login], [Criticidad], [Fecha], [Hora], [NombreEvento], [Modulo], [DNI], [DVH]) VALUES (385, N'sofigesualdo', 1, CAST(N'2026-08-31' AS Date), CAST(N'12:28:41.4638255' AS Time), N'Login', N'Usuario', 46956657, N'KNMG58Iwz3c9HqQruHdS73R9sf7OtUiHmRPFDvk3yeU=')
INSERT [dbo].[Evento] ([IdEvento], [Login], [Criticidad], [Fecha], [Hora], [NombreEvento], [Modulo], [DNI], [DVH]) VALUES (386, N'sofigesualdo', 1, CAST(N'2026-08-31' AS Date), CAST(N'12:32:10.0261735' AS Time), N'Login', N'Usuario', 46956657, N'vtYzi1AVQsdxo2Nr643NSKXcv2GvC9GgGPIUTJFxpRo=')
INSERT [dbo].[Evento] ([IdEvento], [Login], [Criticidad], [Fecha], [Hora], [NombreEvento], [Modulo], [DNI], [DVH]) VALUES (387, N'sofigesualdo', 1, CAST(N'2026-08-31' AS Date), CAST(N'12:37:32.9933046' AS Time), N'Login', N'Usuario', 46956657, N'I+NMExT2xTbURLXmF1FB1XsFMCU2FrRoGjg4rD8mQh8=')
INSERT [dbo].[Evento] ([IdEvento], [Login], [Criticidad], [Fecha], [Hora], [NombreEvento], [Modulo], [DNI], [DVH]) VALUES (388, N'vicky', 1, CAST(N'2026-08-31' AS Date), CAST(N'12:39:32.4293674' AS Time), N'Login', N'Usuario', 12345678, N'MzHLScGSxpRwcNxrqR9WUsns9IhZQnts2egtHRFjjuA=')
INSERT [dbo].[Evento] ([IdEvento], [Login], [Criticidad], [Fecha], [Hora], [NombreEvento], [Modulo], [DNI], [DVH]) VALUES (389, N'sofigesualdo', 1, CAST(N'2026-08-31' AS Date), CAST(N'12:45:06.5392239' AS Time), N'Login', N'Usuario', 46956657, N'2UyjJhxGNta4t+GrTzQoDpFSKHDFgJDB72TZkRMm6JI=')
INSERT [dbo].[Evento] ([IdEvento], [Login], [Criticidad], [Fecha], [Hora], [NombreEvento], [Modulo], [DNI], [DVH]) VALUES (390, N'sofigesualdo', 1, CAST(N'2026-08-31' AS Date), CAST(N'12:45:09.6977228' AS Time), N'Cambio de Idioma', N'Idioma cambiado con éxito', 46956657, N'L7eUfb1eqw9S49m8vSYAH775zC7z1ZKQGNlRV/sKe8U=')
INSERT [dbo].[Evento] ([IdEvento], [Login], [Criticidad], [Fecha], [Hora], [NombreEvento], [Modulo], [DNI], [DVH]) VALUES (391, N'sofigesualdo', 1, CAST(N'2026-08-31' AS Date), CAST(N'12:45:18.1098445' AS Time), N'Cambio de Idioma', N'Idioma cambiado con éxito', 46956657, N'PqXACBcpaQZl9a5mIBsr7kxM5brHaeW+ujcUZnUtQsQ=')
INSERT [dbo].[Evento] ([IdEvento], [Login], [Criticidad], [Fecha], [Hora], [NombreEvento], [Modulo], [DNI], [DVH]) VALUES (392, N'sofigesualdo', 1, CAST(N'2026-08-31' AS Date), CAST(N'12:52:16.8495312' AS Time), N'Login', N'Usuario', 46956657, N'j5LNQ8g404vvGQCGnOBSQEqjdtXWb/Mcsm1bXBKkrC0=')
INSERT [dbo].[Evento] ([IdEvento], [Login], [Criticidad], [Fecha], [Hora], [NombreEvento], [Modulo], [DNI], [DVH]) VALUES (393, N'sofigesualdo', 1, CAST(N'2026-08-31' AS Date), CAST(N'12:55:33.9010877' AS Time), N'Login', N'Usuario', 46956657, N'y9bDj1jaCo0Mafgf2LdT5N3bn5yqzGB4o+z8vwjJVqc=')
INSERT [dbo].[Evento] ([IdEvento], [Login], [Criticidad], [Fecha], [Hora], [NombreEvento], [Modulo], [DNI], [DVH]) VALUES (394, N'sofigesualdo', 1, CAST(N'2026-08-31' AS Date), CAST(N'12:56:43.2939332' AS Time), N'Login', N'Usuario', 46956657, N'AHYZl3xKQ9tU/rkh+vRbz6zhRXFBor4UV6AkbouTb9c=')
INSERT [dbo].[Evento] ([IdEvento], [Login], [Criticidad], [Fecha], [Hora], [NombreEvento], [Modulo], [DNI], [DVH]) VALUES (395, N'sofigesualdo', 1, CAST(N'2026-08-31' AS Date), CAST(N'12:57:22.5220070' AS Time), N'Login', N'Usuario', 46956657, N'EA5KUcD2B3WRKSPRNA08A8h835Bx/m3Q8nZXvkGcF64=')
INSERT [dbo].[Evento] ([IdEvento], [Login], [Criticidad], [Fecha], [Hora], [NombreEvento], [Modulo], [DNI], [DVH]) VALUES (396, N'sofigesualdo', 1, CAST(N'2026-08-31' AS Date), CAST(N'13:48:24.1624210' AS Time), N'Login', N'Usuario', 46956657, N'Exwjxhtsy08q/RPo8M0Y/IPMVJSt3pW1DwQpHf3SUTQ=')
INSERT [dbo].[Evento] ([IdEvento], [Login], [Criticidad], [Fecha], [Hora], [NombreEvento], [Modulo], [DNI], [DVH]) VALUES (397, N'sofigesualdo', 1, CAST(N'2026-08-31' AS Date), CAST(N'13:50:50.6794195' AS Time), N'Login', N'Usuario', 46956657, N'Qdb0qwudR6ddypl7a7IJDpdMu1e4v+ogUNYjzFoK2pg=')
INSERT [dbo].[Evento] ([IdEvento], [Login], [Criticidad], [Fecha], [Hora], [NombreEvento], [Modulo], [DNI], [DVH]) VALUES (398, N'sofigesualdo', 1, CAST(N'2026-08-31' AS Date), CAST(N'13:50:53.2703024' AS Time), N'Cambio de Idioma', N'Idioma cambiado con éxito', 46956657, N'8PMRPeyts7u5m9q0uAjDC/ga67Vofb3jj3lKZlRWF4Y=')
INSERT [dbo].[Evento] ([IdEvento], [Login], [Criticidad], [Fecha], [Hora], [NombreEvento], [Modulo], [DNI], [DVH]) VALUES (399, N'sofigesualdo', 1, CAST(N'2026-08-31' AS Date), CAST(N'13:51:01.6911868' AS Time), N'Cambio de Idioma', N'Idioma cambiado con éxito', 46956657, N'/AJQfPOZx9I0Rr0nNLNTh2DKg7hsqCT/UvcnFDOXNrg=')
INSERT [dbo].[Evento] ([IdEvento], [Login], [Criticidad], [Fecha], [Hora], [NombreEvento], [Modulo], [DNI], [DVH]) VALUES (400, N'sofigesualdo', 1, CAST(N'2026-08-31' AS Date), CAST(N'13:51:39.2934200' AS Time), N'Login', N'Usuario', 46956657, N'hbkzX/Oq+LXDgX9aKskOeiuRBxR3uUvnUAwSDkAz784=')
GO
INSERT [dbo].[Evento] ([IdEvento], [Login], [Criticidad], [Fecha], [Hora], [NombreEvento], [Modulo], [DNI], [DVH]) VALUES (401, N'sofigesualdo', 1, CAST(N'2026-08-31' AS Date), CAST(N'13:51:43.2652595' AS Time), N'Cambio de Idioma', N'Idioma cambiado con éxito', 46956657, N'V9XoBG2t7j13afjuZvEEGbFZAHeG3UtLvftcrnRVmBI=')
INSERT [dbo].[Evento] ([IdEvento], [Login], [Criticidad], [Fecha], [Hora], [NombreEvento], [Modulo], [DNI], [DVH]) VALUES (402, N'sofigesualdo', 1, CAST(N'2026-08-31' AS Date), CAST(N'13:55:42.2413737' AS Time), N'Login', N'Usuario', 46956657, N'shhFOqI8ItQcdhgwfGrCwUbRcbVfmPCwRykpkXtxKKI=')
INSERT [dbo].[Evento] ([IdEvento], [Login], [Criticidad], [Fecha], [Hora], [NombreEvento], [Modulo], [DNI], [DVH]) VALUES (403, N'sofigesualdo', 1, CAST(N'2026-08-31' AS Date), CAST(N'13:56:09.8689908' AS Time), N'Cambio de Idioma', N'Idioma cambiado con éxito', 46956657, N'8LPq8l53VZJiVpghoSWzsGlxjUEKqs9Y4JtI9v2kz2E=')
INSERT [dbo].[Evento] ([IdEvento], [Login], [Criticidad], [Fecha], [Hora], [NombreEvento], [Modulo], [DNI], [DVH]) VALUES (404, N'sofigesualdo', 1, CAST(N'2026-08-31' AS Date), CAST(N'13:56:12.2003192' AS Time), N'Cambio de Idioma', N'Idioma cambiado con éxito', 46956657, N'lbSmScBACMvfPUPfwa5+/8/Exc1JPDLlTgcq3nlrIy0=')
INSERT [dbo].[Evento] ([IdEvento], [Login], [Criticidad], [Fecha], [Hora], [NombreEvento], [Modulo], [DNI], [DVH]) VALUES (405, N'sofigesualdo', 1, CAST(N'2026-08-31' AS Date), CAST(N'13:56:21.4913180' AS Time), N'Cambio de Idioma', N'Idioma cambiado con éxito', 46956657, N'YrO7PH8z47pBkDuRFvQiUHLWdGYoDFp8mOctpvqaYKI=')
INSERT [dbo].[Evento] ([IdEvento], [Login], [Criticidad], [Fecha], [Hora], [NombreEvento], [Modulo], [DNI], [DVH]) VALUES (406, N'sofigesualdo', 1, CAST(N'2026-08-31' AS Date), CAST(N'13:57:26.2949301' AS Time), N'Login', N'Usuario', 46956657, N'Ma4acV+5CYvE3ziZRTAI08VBJsYWC+lT8lFJNEFeTAY=')
INSERT [dbo].[Evento] ([IdEvento], [Login], [Criticidad], [Fecha], [Hora], [NombreEvento], [Modulo], [DNI], [DVH]) VALUES (407, N'sofigesualdo', 1, CAST(N'2026-08-31' AS Date), CAST(N'13:57:29.9163959' AS Time), N'Cambio de Idioma', N'Idioma cambiado con éxito', 46956657, N'o6X/sharh02BcxL0t5tJd6sMJzE+ySjjkT6q3wV9tFw=')
INSERT [dbo].[Evento] ([IdEvento], [Login], [Criticidad], [Fecha], [Hora], [NombreEvento], [Modulo], [DNI], [DVH]) VALUES (408, N'sofigesualdo', 1, CAST(N'2026-08-31' AS Date), CAST(N'14:01:27.2924578' AS Time), N'Login', N'Usuario', 46956657, N'waSl7WXmslVJXrJLLwPZL/9Sn3KvzEDi3Id+DB5ry1k=')
INSERT [dbo].[Evento] ([IdEvento], [Login], [Criticidad], [Fecha], [Hora], [NombreEvento], [Modulo], [DNI], [DVH]) VALUES (409, N'sofigesualdo', 1, CAST(N'2026-09-03' AS Date), CAST(N'20:40:43.4086313' AS Time), N'Login', N'Usuario', 46956657, N'1bejUq6WTbyiqfDrJsZr6T6pNYWjpwB10pQUg3VBtos=')
INSERT [dbo].[Evento] ([IdEvento], [Login], [Criticidad], [Fecha], [Hora], [NombreEvento], [Modulo], [DNI], [DVH]) VALUES (410, N'sofigesualdo', 1, CAST(N'2026-09-03' AS Date), CAST(N'20:40:47.3828795' AS Time), N'Cambio de Idioma', N'Idioma cambiado con éxito', 46956657, N'+nf/Q6PJxMgQTbKwz3PoOjN5SZC7cqcni8GouyhzT08=')
INSERT [dbo].[Evento] ([IdEvento], [Login], [Criticidad], [Fecha], [Hora], [NombreEvento], [Modulo], [DNI], [DVH]) VALUES (411, N'sofigesualdo', 1, CAST(N'2026-09-03' AS Date), CAST(N'20:46:36.3239927' AS Time), N'Login', N'Usuario', 46956657, N'DIuEdw8ieX6jQJmfc6bqicDcrU3fG53mFZAsWd+xqv4=')
INSERT [dbo].[Evento] ([IdEvento], [Login], [Criticidad], [Fecha], [Hora], [NombreEvento], [Modulo], [DNI], [DVH]) VALUES (412, N'sofigesualdo', 1, CAST(N'2026-09-03' AS Date), CAST(N'20:48:50.3355808' AS Time), N'Login', N'Usuario', 46956657, N'vzuR/TMr72mwnM+zf8+D8z8UKzIYcE4M7ItoD0GiPmk=')
INSERT [dbo].[Evento] ([IdEvento], [Login], [Criticidad], [Fecha], [Hora], [NombreEvento], [Modulo], [DNI], [DVH]) VALUES (413, N'sofigesualdo', 1, CAST(N'2026-09-03' AS Date), CAST(N'20:49:13.2885931' AS Time), N'Logout', N'Usuario', 46956657, N'l3zAsZvxiMqh29a47nvyd4aKS7JkSKotRuFjzQrc8fA=')
INSERT [dbo].[Evento] ([IdEvento], [Login], [Criticidad], [Fecha], [Hora], [NombreEvento], [Modulo], [DNI], [DVH]) VALUES (414, N'vicky', 1, CAST(N'2026-09-03' AS Date), CAST(N'20:49:16.6608539' AS Time), N'Login', N'Usuario', 12345678, N'bjHxdGpqxJh5ykdsO8DusHgFv+rwcrO/pP2aX/coky4=')
INSERT [dbo].[Evento] ([IdEvento], [Login], [Criticidad], [Fecha], [Hora], [NombreEvento], [Modulo], [DNI], [DVH]) VALUES (415, N'vicky', 1, CAST(N'2026-09-03' AS Date), CAST(N'20:50:10.3355831' AS Time), N'Cambio de Idioma', N'Idioma cambiado con éxito', 12345678, N'mkA+Bvui6bSjQUtCeDnXkcPmRz+WjT7fznPtg6zHHW4=')
INSERT [dbo].[Evento] ([IdEvento], [Login], [Criticidad], [Fecha], [Hora], [NombreEvento], [Modulo], [DNI], [DVH]) VALUES (416, N'vicky', 1, CAST(N'2026-09-03' AS Date), CAST(N'20:50:12.4686691' AS Time), N'Cambio de Idioma', N'Idioma cambiado con éxito', 12345678, N'Wz54RwCDzqA0a7rcZU9LF/+HTewtcAbICocnb6DcRDs=')
INSERT [dbo].[Evento] ([IdEvento], [Login], [Criticidad], [Fecha], [Hora], [NombreEvento], [Modulo], [DNI], [DVH]) VALUES (417, N'vicky', 1, CAST(N'2026-09-03' AS Date), CAST(N'20:50:56.8830875' AS Time), N'Logout', N'Usuario', 12345678, N'WqKOQMu3rizVnQw14uERpyAMeAy1L3+SO5joHUOFlB8=')
INSERT [dbo].[Evento] ([IdEvento], [Login], [Criticidad], [Fecha], [Hora], [NombreEvento], [Modulo], [DNI], [DVH]) VALUES (418, N'vicky', 1, CAST(N'2026-09-03' AS Date), CAST(N'20:53:19.2841325' AS Time), N'Login', N'Usuario', 12345678, N'EL8Fj9kus5RQwK31pFlAGxflhz6nD8E9UUjwm/TQN9Q=')
INSERT [dbo].[Evento] ([IdEvento], [Login], [Criticidad], [Fecha], [Hora], [NombreEvento], [Modulo], [DNI], [DVH]) VALUES (419, N'vicky', 1, CAST(N'2026-09-04' AS Date), CAST(N'17:48:00.5030994' AS Time), N'Login', N'Usuario', 12345678, N'Eh3FFYPD7zNfDgw4Vql79yKjbft82Lfr5nUK5MayxA4=')
INSERT [dbo].[Evento] ([IdEvento], [Login], [Criticidad], [Fecha], [Hora], [NombreEvento], [Modulo], [DNI], [DVH]) VALUES (420, N'vicky', 1, CAST(N'2026-09-04' AS Date), CAST(N'17:48:25.2077726' AS Time), N'Cambio de Idioma', N'Idioma cambiado con éxito', 12345678, N'LCFJ+7VhYuWik3mVTRQSGcTobilcw15QBECzJITyFc0=')
INSERT [dbo].[Evento] ([IdEvento], [Login], [Criticidad], [Fecha], [Hora], [NombreEvento], [Modulo], [DNI], [DVH]) VALUES (421, N'vicky', 1, CAST(N'2026-09-04' AS Date), CAST(N'17:48:27.0773162' AS Time), N'Logout', N'Usuario', 12345678, N'iwzvfMEOkDM+g7I60cxU6nulbwPg/OOmS0v+9MAvKeI=')
INSERT [dbo].[Evento] ([IdEvento], [Login], [Criticidad], [Fecha], [Hora], [NombreEvento], [Modulo], [DNI], [DVH]) VALUES (422, N'vicky', 1, CAST(N'2026-09-04' AS Date), CAST(N'20:29:15.2723864' AS Time), N'Login', N'Usuario', 12345678, N'z38240Tn5jj2z93t8KLYru9mgkWBsMSROxlje+MzMBQ=')
INSERT [dbo].[Evento] ([IdEvento], [Login], [Criticidad], [Fecha], [Hora], [NombreEvento], [Modulo], [DNI], [DVH]) VALUES (423, N'vicky', 1, CAST(N'2026-09-04' AS Date), CAST(N'20:31:51.4908735' AS Time), N'Login', N'Usuario', 12345678, N'Wn5QFE5EyhZ8fMy7E5pH5RYohDEBudlhTX9ijXCvoqc=')
INSERT [dbo].[Evento] ([IdEvento], [Login], [Criticidad], [Fecha], [Hora], [NombreEvento], [Modulo], [DNI], [DVH]) VALUES (424, N'vicky', 1, CAST(N'2026-09-04' AS Date), CAST(N'20:47:39.3322392' AS Time), N'Login', N'Usuario', 12345678, N'D56r34II8BmvdFLNhVGI7wE3Xhb80SWIkITXqEAYE7o=')
INSERT [dbo].[Evento] ([IdEvento], [Login], [Criticidad], [Fecha], [Hora], [NombreEvento], [Modulo], [DNI], [DVH]) VALUES (425, N'vicky', 1, CAST(N'2026-09-04' AS Date), CAST(N'20:52:22.1635425' AS Time), N'Login', N'Usuario', 12345678, N'h0SoUEZDSrwxN6gtx8gZuC8AdiGKaCAmUocPZGBkOJY=')
INSERT [dbo].[Evento] ([IdEvento], [Login], [Criticidad], [Fecha], [Hora], [NombreEvento], [Modulo], [DNI], [DVH]) VALUES (426, N'vicky', 1, CAST(N'2026-09-04' AS Date), CAST(N'20:54:36.9500587' AS Time), N'Login', N'Usuario', 12345678, N'YHAvlVEDV/1Na9PXkta6HiW5/H7YMraV4iuyEr3k6WA=')
INSERT [dbo].[Evento] ([IdEvento], [Login], [Criticidad], [Fecha], [Hora], [NombreEvento], [Modulo], [DNI], [DVH]) VALUES (427, N'vicky', 1, CAST(N'2026-09-04' AS Date), CAST(N'20:58:29.2816686' AS Time), N'Login', N'Usuario', 12345678, N'z5nW9j2ohR9TTmXe3Pmb8LFRgIeKvAHpmVAKFUa3Ipw=')
INSERT [dbo].[Evento] ([IdEvento], [Login], [Criticidad], [Fecha], [Hora], [NombreEvento], [Modulo], [DNI], [DVH]) VALUES (428, N'vicky', 1, CAST(N'2026-09-04' AS Date), CAST(N'20:59:33.7419497' AS Time), N'Login', N'Usuario', 12345678, N'lsPnqlT1492Wf0Pkktxc5Xb6KYzeBrzQEQJKZ83UuUw=')
INSERT [dbo].[Evento] ([IdEvento], [Login], [Criticidad], [Fecha], [Hora], [NombreEvento], [Modulo], [DNI], [DVH]) VALUES (429, N'vicky', 1, CAST(N'2026-09-04' AS Date), CAST(N'21:01:00.3793175' AS Time), N'Login', N'Usuario', 12345678, N'UZXnn/ayWzSD67IzY4UrdtXgTjydJ5QHPDkyVkr0T6I=')
INSERT [dbo].[Evento] ([IdEvento], [Login], [Criticidad], [Fecha], [Hora], [NombreEvento], [Modulo], [DNI], [DVH]) VALUES (430, N'vicky', 1, CAST(N'2026-09-04' AS Date), CAST(N'21:01:22.8084242' AS Time), N'Login', N'Usuario', 12345678, N'LaVYZmc8AKc8uzFN0zhaOf7ht9fMoekehsa1Wkj+nB8=')
INSERT [dbo].[Evento] ([IdEvento], [Login], [Criticidad], [Fecha], [Hora], [NombreEvento], [Modulo], [DNI], [DVH]) VALUES (431, N'vicky', 1, CAST(N'2026-09-04' AS Date), CAST(N'21:04:31.8859818' AS Time), N'Login', N'Usuario', 12345678, N'7X99LbyMQTRugWRXMUNZQYoNDKAjeOE+kgBMviSHZcw=')
INSERT [dbo].[Evento] ([IdEvento], [Login], [Criticidad], [Fecha], [Hora], [NombreEvento], [Modulo], [DNI], [DVH]) VALUES (432, N'sofigesualdo', 1, CAST(N'2026-09-04' AS Date), CAST(N'21:05:36.6350304' AS Time), N'Login', N'Usuario', 46956657, N'HAylroV1ghJllRS+wUuD3X8//JZV5E36N9kSBfT2csk=')
INSERT [dbo].[Evento] ([IdEvento], [Login], [Criticidad], [Fecha], [Hora], [NombreEvento], [Modulo], [DNI], [DVH]) VALUES (433, N'sofigesualdo', 1, CAST(N'2026-09-04' AS Date), CAST(N'21:09:30.2597322' AS Time), N'Cambio de Idioma', N'Idioma cambiado con éxito', 46956657, N'Cyigrr5K9OzaOBvv1E+V8fprGgI05RdprjEFqt1pML4=')
INSERT [dbo].[Evento] ([IdEvento], [Login], [Criticidad], [Fecha], [Hora], [NombreEvento], [Modulo], [DNI], [DVH]) VALUES (434, N'sofigesualdo', 1, CAST(N'2026-09-04' AS Date), CAST(N'21:09:44.2724121' AS Time), N'Logout', N'Usuario', 46956657, N'OIJty1ETFFk5hdKZDXSpDMjicSlrX1XVucaT5Nlu2LU=')
INSERT [dbo].[Evento] ([IdEvento], [Login], [Criticidad], [Fecha], [Hora], [NombreEvento], [Modulo], [DNI], [DVH]) VALUES (435, N'sofigesualdo', 1, CAST(N'2026-09-04' AS Date), CAST(N'21:13:21.1584932' AS Time), N'Login', N'Usuario', 46956657, N'G5exVoJi0m7qIivKCW1dMnbUA4JmrkTUi478m1kx5eo=')
INSERT [dbo].[Evento] ([IdEvento], [Login], [Criticidad], [Fecha], [Hora], [NombreEvento], [Modulo], [DNI], [DVH]) VALUES (436, N'sofigesualdo', 1, CAST(N'2026-09-04' AS Date), CAST(N'21:14:06.4562189' AS Time), N'Logout', N'Usuario', 46956657, N'YYu3BPYUgUh42/o0/mXMlVlh0v9dYH7HdVhh4RKPgQg=')
INSERT [dbo].[Evento] ([IdEvento], [Login], [Criticidad], [Fecha], [Hora], [NombreEvento], [Modulo], [DNI], [DVH]) VALUES (437, N'vicky', 1, CAST(N'2026-09-04' AS Date), CAST(N'21:18:36.2594458' AS Time), N'Login', N'Usuario', 12345678, N'IdVA+8uTY23eFgzBuHqd3fuCPvwRlFvYL3nGboQmE88=')
INSERT [dbo].[Evento] ([IdEvento], [Login], [Criticidad], [Fecha], [Hora], [NombreEvento], [Modulo], [DNI], [DVH]) VALUES (438, N'vicky', 1, CAST(N'2026-09-04' AS Date), CAST(N'21:19:27.5104629' AS Time), N'Login', N'Usuario', 12345678, N'JIKH+4S4cOKQLrkrBR3GFrXGaHHbBbR6B7Ok7aTLX78=')
INSERT [dbo].[Evento] ([IdEvento], [Login], [Criticidad], [Fecha], [Hora], [NombreEvento], [Modulo], [DNI], [DVH]) VALUES (439, N'vicky', 1, CAST(N'2026-09-04' AS Date), CAST(N'21:21:35.4947217' AS Time), N'Login', N'Usuario', 12345678, N'aIcWbYf9selcE7YeDOAxx2ACEMVVyGCBBTE6N9y3TDA=')
INSERT [dbo].[Evento] ([IdEvento], [Login], [Criticidad], [Fecha], [Hora], [NombreEvento], [Modulo], [DNI], [DVH]) VALUES (440, N'vicky', 1, CAST(N'2026-09-04' AS Date), CAST(N'21:21:55.2870815' AS Time), N'Cambio de Idioma', N'Idioma cambiado con éxito', 12345678, N'kLOZ2RdY6v10N3ur0J8tsHhw66+muxbB8bmWSeL5DNo=')
INSERT [dbo].[Evento] ([IdEvento], [Login], [Criticidad], [Fecha], [Hora], [NombreEvento], [Modulo], [DNI], [DVH]) VALUES (441, N'vicky', 1, CAST(N'2026-09-04' AS Date), CAST(N'21:24:48.3540669' AS Time), N'Login', N'Usuario', 12345678, N'3XiOpqRXJRKU8y/POuZGxyicbbsO+0TCb0n7HOfY6gk=')
INSERT [dbo].[Evento] ([IdEvento], [Login], [Criticidad], [Fecha], [Hora], [NombreEvento], [Modulo], [DNI], [DVH]) VALUES (442, N'vicky', 1, CAST(N'2026-09-04' AS Date), CAST(N'21:25:01.5229176' AS Time), N'Cambio de Idioma', N'Idioma cambiado con éxito', 12345678, N'TpaCpcMxO5Gb7Lf0aHjAE1ln92MkOPJaOBMtneVgQHE=')
INSERT [dbo].[Evento] ([IdEvento], [Login], [Criticidad], [Fecha], [Hora], [NombreEvento], [Modulo], [DNI], [DVH]) VALUES (443, N'vicky', 1, CAST(N'2026-09-04' AS Date), CAST(N'21:30:10.9859471' AS Time), N'Login', N'Usuario', 12345678, N'X+L8d2EXgK+HIg/sVABkMpxKAHFJ2mRLPfxsGuPZwXI=')
INSERT [dbo].[Evento] ([IdEvento], [Login], [Criticidad], [Fecha], [Hora], [NombreEvento], [Modulo], [DNI], [DVH]) VALUES (444, N'vicky', 1, CAST(N'2026-09-04' AS Date), CAST(N'21:30:13.6486582' AS Time), N'Cambio de Idioma', N'Idioma cambiado con éxito', 12345678, N'hCgL7AFxvp9sHLK/z3K2Dk9FQse5w+o6c0N277RvJKw=')
INSERT [dbo].[Evento] ([IdEvento], [Login], [Criticidad], [Fecha], [Hora], [NombreEvento], [Modulo], [DNI], [DVH]) VALUES (445, N'vicky', 1, CAST(N'2026-09-04' AS Date), CAST(N'21:31:59.2801290' AS Time), N'Login', N'Usuario', 12345678, N'7dJvkB+NEztaEamI9YpzmEh7RBddh2xMk7U4NUfQ+/M=')
INSERT [dbo].[Evento] ([IdEvento], [Login], [Criticidad], [Fecha], [Hora], [NombreEvento], [Modulo], [DNI], [DVH]) VALUES (446, N'vicky', 1, CAST(N'2026-09-04' AS Date), CAST(N'21:32:02.1142937' AS Time), N'Cambio de Idioma', N'Idioma cambiado con éxito', 12345678, N'eRUDO1S6AxsZWNXnPQA+xDJezx8V/fW7+J2u50UUR3U=')
INSERT [dbo].[Evento] ([IdEvento], [Login], [Criticidad], [Fecha], [Hora], [NombreEvento], [Modulo], [DNI], [DVH]) VALUES (447, N'vicky', 1, CAST(N'2026-09-04' AS Date), CAST(N'21:32:13.8330907' AS Time), N'Cambio de Idioma', N'Idioma cambiado con éxito', 12345678, N'RaZwouVpps5gXzgKpBYxpylqKk/hjgdNhYf2fOWRyGc=')
INSERT [dbo].[Evento] ([IdEvento], [Login], [Criticidad], [Fecha], [Hora], [NombreEvento], [Modulo], [DNI], [DVH]) VALUES (448, N'vicky', 1, CAST(N'2026-09-04' AS Date), CAST(N'21:32:23.9256527' AS Time), N'Eliminación de Perfil', N'Perfiles', 12345678, N'Wu4yJrxzGPqUx/lZkwYErPQ57tTXDhiFIEhritHFfO0=')
INSERT [dbo].[Evento] ([IdEvento], [Login], [Criticidad], [Fecha], [Hora], [NombreEvento], [Modulo], [DNI], [DVH]) VALUES (449, N'vicky', 1, CAST(N'2026-09-04' AS Date), CAST(N'21:32:29.1590238' AS Time), N'Eliminación de Perfil', N'Perfiles', 12345678, N'cQNqVa/VkiYFjla03H7prlBOLTPEwWb/xrPwAHsVcEs=')
INSERT [dbo].[Evento] ([IdEvento], [Login], [Criticidad], [Fecha], [Hora], [NombreEvento], [Modulo], [DNI], [DVH]) VALUES (450, N'vicky', 1, CAST(N'2026-09-04' AS Date), CAST(N'22:44:35.4716325' AS Time), N'Login', N'Usuario', 12345678, N'Lde7Ar6VdRZhkh1OXiQNfR/ZU6k0UuBavp4cPeHyPDU=')
INSERT [dbo].[Evento] ([IdEvento], [Login], [Criticidad], [Fecha], [Hora], [NombreEvento], [Modulo], [DNI], [DVH]) VALUES (451, N'sofigesualdo', 1, CAST(N'2026-09-04' AS Date), CAST(N'22:56:52.4115521' AS Time), N'Login', N'Usuario', 46956657, N'zyBGxDYG3daQsvaDZLjwwet/6JEnxnThCmLE0Dyzv/g=')
INSERT [dbo].[Evento] ([IdEvento], [Login], [Criticidad], [Fecha], [Hora], [NombreEvento], [Modulo], [DNI], [DVH]) VALUES (452, N'sofigesualdo', 1, CAST(N'2026-09-04' AS Date), CAST(N'23:00:54.6971171' AS Time), N'Login', N'Usuario', 46956657, N'f/bOW9mRjZ6sZTgcR9Dmxo5b/IuVmHyNfg+N080M390=')
INSERT [dbo].[Evento] ([IdEvento], [Login], [Criticidad], [Fecha], [Hora], [NombreEvento], [Modulo], [DNI], [DVH]) VALUES (453, N'sofigesualdo', 1, CAST(N'2026-09-04' AS Date), CAST(N'23:13:21.2952256' AS Time), N'Login', N'Usuario', 46956657, N'gmAuLIUvGAX+Rw+N9U3kJMkeh3etejOT9sEE2jd83dw=')
INSERT [dbo].[Evento] ([IdEvento], [Login], [Criticidad], [Fecha], [Hora], [NombreEvento], [Modulo], [DNI], [DVH]) VALUES (454, N'sofigesualdo', 2, CAST(N'2026-09-04' AS Date), CAST(N'23:14:14.6453230' AS Time), N'Crear Libro', N'Libro', 46956657, N'SDvZiawbeXKJ/qh8hy0l3OluOAT00GHvZz2ZqKJgRpk=')
INSERT [dbo].[Evento] ([IdEvento], [Login], [Criticidad], [Fecha], [Hora], [NombreEvento], [Modulo], [DNI], [DVH]) VALUES (455, N'sofigesualdo', 1, CAST(N'2026-09-04' AS Date), CAST(N'23:14:26.3792976' AS Time), N'Logout', N'Usuario', 46956657, N'Q1x6nIIAIFjSBSSO3dWAtWrWq0Kev18pfryNW1t8z6g=')
INSERT [dbo].[Evento] ([IdEvento], [Login], [Criticidad], [Fecha], [Hora], [NombreEvento], [Modulo], [DNI], [DVH]) VALUES (456, N'sofigesualdo', 1, CAST(N'2026-09-04' AS Date), CAST(N'23:19:27.2966005' AS Time), N'Login', N'Usuario', 46956657, N'7txPGwIxZ+C7d94C0aRo4x0OUg2DGjV9qmxdccDVOAE=')
INSERT [dbo].[Evento] ([IdEvento], [Login], [Criticidad], [Fecha], [Hora], [NombreEvento], [Modulo], [DNI], [DVH]) VALUES (457, N'vicky', 1, CAST(N'2026-09-04' AS Date), CAST(N'23:20:41.1526441' AS Time), N'Login', N'Usuario', 12345678, N'XVaj75r+a6SXQgcwtBRJ321K6uowTeOUwaQoMHBbjL4=')
INSERT [dbo].[Evento] ([IdEvento], [Login], [Criticidad], [Fecha], [Hora], [NombreEvento], [Modulo], [DNI], [DVH]) VALUES (458, N'vicky', 1, CAST(N'2026-09-04' AS Date), CAST(N'23:20:52.9117681' AS Time), N'Cambio de Idioma', N'Idioma cambiado con éxito', 12345678, N'CZ+3D7gOVpzweX4D8hbqXX+ahHuvDnoJtekv1FP4bQM=')
INSERT [dbo].[Evento] ([IdEvento], [Login], [Criticidad], [Fecha], [Hora], [NombreEvento], [Modulo], [DNI], [DVH]) VALUES (459, N'vicky', 1, CAST(N'2026-09-04' AS Date), CAST(N'23:21:56.1065606' AS Time), N'Logout', N'Usuario', 12345678, N'6j8b+TpRVjHksigbWrZz6b8upQT4hgo1JZz3PdqSYwY=')
INSERT [dbo].[Evento] ([IdEvento], [Login], [Criticidad], [Fecha], [Hora], [NombreEvento], [Modulo], [DNI], [DVH]) VALUES (460, N'vicky', 1, CAST(N'2026-09-04' AS Date), CAST(N'23:26:34.1468180' AS Time), N'Login', N'Usuario', 12345678, N'YCkSsr5cDbFEud9QIrsWVVkL/F3wCNmas+9HmHwHxtU=')
INSERT [dbo].[Evento] ([IdEvento], [Login], [Criticidad], [Fecha], [Hora], [NombreEvento], [Modulo], [DNI], [DVH]) VALUES (461, N'sofigesualdo', 1, CAST(N'2026-09-06' AS Date), CAST(N'14:24:26.1585772' AS Time), N'Login', N'Usuario', 46956657, N'gF+4TicCrfSQDbJo4z/1r4+tWM9pK4Sv+x2QlcTpRtg=')
INSERT [dbo].[Evento] ([IdEvento], [Login], [Criticidad], [Fecha], [Hora], [NombreEvento], [Modulo], [DNI], [DVH]) VALUES (462, N'sofigesualdo', 1, CAST(N'2026-09-06' AS Date), CAST(N'14:26:20.9078865' AS Time), N'Login', N'Usuario', 46956657, N'6dVfDaTSfAo1RO3XBIlp0g0xRwvBebq+8Regf1Sikck=')
INSERT [dbo].[Evento] ([IdEvento], [Login], [Criticidad], [Fecha], [Hora], [NombreEvento], [Modulo], [DNI], [DVH]) VALUES (463, N'sofigesualdo', 1, CAST(N'2026-09-06' AS Date), CAST(N'14:26:55.2752969' AS Time), N'Logout', N'Usuario', 46956657, N'GylbfCyzLuKOVXhdzYjVfkzxDkpbx0qiasqoiEgn0Tg=')
INSERT [dbo].[Evento] ([IdEvento], [Login], [Criticidad], [Fecha], [Hora], [NombreEvento], [Modulo], [DNI], [DVH]) VALUES (464, N'vicky', 1, CAST(N'2026-09-06' AS Date), CAST(N'14:26:59.1014189' AS Time), N'Login', N'Usuario', 12345678, N'VpQzbGxzV7/hGlngIRGNzfY3GO5yXU2nEyapcASmvuA=')
INSERT [dbo].[Evento] ([IdEvento], [Login], [Criticidad], [Fecha], [Hora], [NombreEvento], [Modulo], [DNI], [DVH]) VALUES (465, N'vicky', 1, CAST(N'2026-09-06' AS Date), CAST(N'14:27:10.7720024' AS Time), N'Creación de backup', N'Respaldos', 12345678, N'WlANIl2nwqC8pAZpGdz4cpK1KT41FI6y6mujTdlS4rk=')
INSERT [dbo].[Evento] ([IdEvento], [Login], [Criticidad], [Fecha], [Hora], [NombreEvento], [Modulo], [DNI], [DVH]) VALUES (466, N'vicky', 1, CAST(N'2026-09-06' AS Date), CAST(N'14:27:36.5215826' AS Time), N'Creación de backup', N'Respaldos', 12345678, N'eHgdgC2oJceiszMPHBSpnCbttx1uQKJqgMC/M3dHDqU=')
INSERT [dbo].[Evento] ([IdEvento], [Login], [Criticidad], [Fecha], [Hora], [NombreEvento], [Modulo], [DNI], [DVH]) VALUES (467, N'vicky', 1, CAST(N'2026-09-06' AS Date), CAST(N'14:27:39.3977916' AS Time), N'Logout', N'Usuario', 12345678, N'ZfKyZpgEGtp7X/b6OBp65YmSMsd7ODThMQ2uP6ex3mU=')
INSERT [dbo].[Evento] ([IdEvento], [Login], [Criticidad], [Fecha], [Hora], [NombreEvento], [Modulo], [DNI], [DVH]) VALUES (468, N'vicky', 1, CAST(N'2026-09-06' AS Date), CAST(N'14:31:28.8393993' AS Time), N'Login', N'Usuario', 12345678, N'JqZ8y0m/k8MNWKNTdLAn5vR05/vegZnkFHcLuMHiuXg=')
INSERT [dbo].[Evento] ([IdEvento], [Login], [Criticidad], [Fecha], [Hora], [NombreEvento], [Modulo], [DNI], [DVH]) VALUES (469, N'vicky', 1, CAST(N'2026-09-06' AS Date), CAST(N'14:34:11.2340302' AS Time), N'Login', N'Usuario', 12345678, N'ynG0LjoPdpx3JkRIr8CbgWPO8G1liAUSCH8S9CFceaQ=')
INSERT [dbo].[Evento] ([IdEvento], [Login], [Criticidad], [Fecha], [Hora], [NombreEvento], [Modulo], [DNI], [DVH]) VALUES (470, N'vicky', 1, CAST(N'2026-09-06' AS Date), CAST(N'14:34:45.8256090' AS Time), N'Login', N'Usuario', 12345678, N'OAxCtsnu3w6RbiygJyEZjaI63CrLssb3DqTOPLyKYuQ=')
INSERT [dbo].[Evento] ([IdEvento], [Login], [Criticidad], [Fecha], [Hora], [NombreEvento], [Modulo], [DNI], [DVH]) VALUES (471, N'vicky', 1, CAST(N'2026-09-06' AS Date), CAST(N'14:59:51.3710380' AS Time), N'Login', N'Usuario', 12345678, N'/viqcu4qMyCQ3b+6KYtwDcw43Zsd8LoP4zSYQcLZauE=')
INSERT [dbo].[Evento] ([IdEvento], [Login], [Criticidad], [Fecha], [Hora], [NombreEvento], [Modulo], [DNI], [DVH]) VALUES (472, N'vicky', 1, CAST(N'2026-09-06' AS Date), CAST(N'15:00:03.3545779' AS Time), N'Logout', N'Usuario', 12345678, N'dhHkpoSN06iIYzp+4d4nmkWLDv/piBPXFqnX28nLpIQ=')
INSERT [dbo].[Evento] ([IdEvento], [Login], [Criticidad], [Fecha], [Hora], [NombreEvento], [Modulo], [DNI], [DVH]) VALUES (473, N'vicky', 1, CAST(N'2026-09-06' AS Date), CAST(N'15:08:07.5527640' AS Time), N'Login', N'Usuario', 12345678, N'ri6+g9gn4ZGA6qbjeDlCh2laYfZYhkkeB2QYbbdahg4=')
INSERT [dbo].[Evento] ([IdEvento], [Login], [Criticidad], [Fecha], [Hora], [NombreEvento], [Modulo], [DNI], [DVH]) VALUES (474, N'vicky', 1, CAST(N'2026-09-06' AS Date), CAST(N'15:08:11.5646730' AS Time), N'Cambio de Idioma', N'Idioma cambiado con éxito', 12345678, N'fZ8TE9CUsVozZuoxh0OOowIwLyJtOXSKo1UmbQXhMi8=')
INSERT [dbo].[Evento] ([IdEvento], [Login], [Criticidad], [Fecha], [Hora], [NombreEvento], [Modulo], [DNI], [DVH]) VALUES (475, N'vicky', 1, CAST(N'2026-09-06' AS Date), CAST(N'15:08:23.5524204' AS Time), N'Activar / Desactivar Usuario', N'Usuario', 12345678, N't4ORtEMhnrFhaQ3tHC1hSdjZl/H7u/imax+qEpAAuLM=')
INSERT [dbo].[Evento] ([IdEvento], [Login], [Criticidad], [Fecha], [Hora], [NombreEvento], [Modulo], [DNI], [DVH]) VALUES (476, N'vicky', 1, CAST(N'2026-09-06' AS Date), CAST(N'15:08:33.1975192' AS Time), N'Logout', N'Usuario', 12345678, N'v2PQ9rhah9MZPB8pJ68KAhl8zmXnMQuHaAog5gppWJM=')
INSERT [dbo].[Evento] ([IdEvento], [Login], [Criticidad], [Fecha], [Hora], [NombreEvento], [Modulo], [DNI], [DVH]) VALUES (477, N'sofigesualdo', 1, CAST(N'2026-09-06' AS Date), CAST(N'15:56:02.9250859' AS Time), N'Login', N'Usuario', 46956657, N'FfvKc4TzvAH36WKLYmhz5Ih3u+VZy5/HJRCcUhrOBCc=')
INSERT [dbo].[Evento] ([IdEvento], [Login], [Criticidad], [Fecha], [Hora], [NombreEvento], [Modulo], [DNI], [DVH]) VALUES (478, N'sofigesualdo', 1, CAST(N'2026-09-06' AS Date), CAST(N'15:56:08.2933080' AS Time), N'Cambio de Idioma', N'Idioma cambiado con éxito', 46956657, N'IHRN4FmLWb2nnQy3gTcPTsmdyj/iq5Qe0iJqsfyhuxc=')
INSERT [dbo].[Evento] ([IdEvento], [Login], [Criticidad], [Fecha], [Hora], [NombreEvento], [Modulo], [DNI], [DVH]) VALUES (479, N'sofigesualdo', 2, CAST(N'2026-09-06' AS Date), CAST(N'15:56:30.0825920' AS Time), N'Baja de Libro', N'Libro', 46956657, N'NSFpE5rElw/RdyvskgP7D2FMbRDB5K6i3PgAqjsHD+4=')
INSERT [dbo].[Evento] ([IdEvento], [Login], [Criticidad], [Fecha], [Hora], [NombreEvento], [Modulo], [DNI], [DVH]) VALUES (480, N'sofigesualdo', 1, CAST(N'2026-09-06' AS Date), CAST(N'15:57:09.0603603' AS Time), N'Logout', N'Usuario', 46956657, N'Ao3IHvok4/KnkxZVVPS0f633R7MZpakYVv9jB35s64A=')
INSERT [dbo].[Evento] ([IdEvento], [Login], [Criticidad], [Fecha], [Hora], [NombreEvento], [Modulo], [DNI], [DVH]) VALUES (481, N'sofigesualdo', 1, CAST(N'2026-09-06' AS Date), CAST(N'16:02:33.8941916' AS Time), N'Login', N'Usuario', 46956657, N'ek8f3hfccd2AhBGM6ignJ+N7pDTaE+zTypWMQLWQ01o=')
INSERT [dbo].[Evento] ([IdEvento], [Login], [Criticidad], [Fecha], [Hora], [NombreEvento], [Modulo], [DNI], [DVH]) VALUES (482, N'sofigesualdo', 1, CAST(N'2026-09-06' AS Date), CAST(N'16:02:53.4004365' AS Time), N'Cambio de Idioma', N'Idioma cambiado con éxito', 46956657, N'K8F2JmFbvkPwUKUzvX1dDftKSL8RgG5DIECQnpFDrak=')
INSERT [dbo].[Evento] ([IdEvento], [Login], [Criticidad], [Fecha], [Hora], [NombreEvento], [Modulo], [DNI], [DVH]) VALUES (483, N'sofigesualdo', 1, CAST(N'2026-09-06' AS Date), CAST(N'16:03:08.9282746' AS Time), N'Cambio de Idioma', N'Idioma cambiado con éxito', 46956657, N'HSdUnwIbdRRT2gQPRseRke2ZZMRcDArLOVsFdEH4cx0=')
INSERT [dbo].[Evento] ([IdEvento], [Login], [Criticidad], [Fecha], [Hora], [NombreEvento], [Modulo], [DNI], [DVH]) VALUES (484, N'sofigesualdo', 1, CAST(N'2026-09-06' AS Date), CAST(N'16:03:10.7485996' AS Time), N'Logout', N'Usuario', 46956657, N'aQ/Ux7sE0NRleej2cpkTiN+8SxGtrXrY3w4bbF7du1Y=')
INSERT [dbo].[Evento] ([IdEvento], [Login], [Criticidad], [Fecha], [Hora], [NombreEvento], [Modulo], [DNI], [DVH]) VALUES (485, N'vicky', 1, CAST(N'2026-09-06' AS Date), CAST(N'16:03:13.7790184' AS Time), N'Login', N'Usuario', 12345678, N'fY/BMpt9CT7QC4KsfdGCOLmVb6g/Nlo4RTkLYFKIvA8=')
INSERT [dbo].[Evento] ([IdEvento], [Login], [Criticidad], [Fecha], [Hora], [NombreEvento], [Modulo], [DNI], [DVH]) VALUES (486, N'sofigesualdo', 1, CAST(N'2026-09-06' AS Date), CAST(N'17:16:33.5497637' AS Time), N'Login', N'Usuario', 46956657, N'G3Qn849/u77tgDZqySHjHTdC3ERkbuHk6he3KWVkLNw=')
INSERT [dbo].[Evento] ([IdEvento], [Login], [Criticidad], [Fecha], [Hora], [NombreEvento], [Modulo], [DNI], [DVH]) VALUES (487, N'vicky', 1, CAST(N'2026-09-06' AS Date), CAST(N'17:17:44.0051389' AS Time), N'Login', N'Usuario', 12345678, N'pWUGguwv04D+ehIuPOAWVua9nAGea+La+vk/VT7jsf4=')
INSERT [dbo].[Evento] ([IdEvento], [Login], [Criticidad], [Fecha], [Hora], [NombreEvento], [Modulo], [DNI], [DVH]) VALUES (488, N'vicky', 1, CAST(N'2026-09-06' AS Date), CAST(N'17:37:07.3465529' AS Time), N'Login', N'Usuario', 12345678, N'vx8UWzzUxLbWQNfG5jrS72xnCBP9p4OwXHthiNlmPQg=')
INSERT [dbo].[Evento] ([IdEvento], [Login], [Criticidad], [Fecha], [Hora], [NombreEvento], [Modulo], [DNI], [DVH]) VALUES (489, N'vicky', 2, CAST(N'2026-09-06' AS Date), CAST(N'17:37:14.2461936' AS Time), N'Activar Libro', N'Libro', 12345678, N'bwWGOxXAZRAdRRp9eIJPYjU6x04N6vLjvLyJyCH18YA=')
INSERT [dbo].[Evento] ([IdEvento], [Login], [Criticidad], [Fecha], [Hora], [NombreEvento], [Modulo], [DNI], [DVH]) VALUES (490, N'vicky', 2, CAST(N'2026-09-06' AS Date), CAST(N'17:37:18.0470363' AS Time), N'Desactivar Libro', N'Libro', 12345678, N'+H4n7/M9I7kWvWFmMIxSGiMRvuQYi+1+fNk385GPHJg=')
INSERT [dbo].[Evento] ([IdEvento], [Login], [Criticidad], [Fecha], [Hora], [NombreEvento], [Modulo], [DNI], [DVH]) VALUES (491, N'vicky', 1, CAST(N'2026-09-06' AS Date), CAST(N'17:37:29.9648649' AS Time), N'Logout', N'Usuario', 12345678, N'0X10ikxx1uw/kpY20J884Whb/jKIurcs3J9C/sD+Ifc=')
INSERT [dbo].[Evento] ([IdEvento], [Login], [Criticidad], [Fecha], [Hora], [NombreEvento], [Modulo], [DNI], [DVH]) VALUES (492, N'sofigesualdo', 1, CAST(N'2026-09-06' AS Date), CAST(N'18:01:39.2364597' AS Time), N'Login', N'Usuario', 46956657, N'VnJ74GmRB0/pYaiR/zg5v3JPEvl+YY7Jc99nuKgMuqY=')
INSERT [dbo].[Evento] ([IdEvento], [Login], [Criticidad], [Fecha], [Hora], [NombreEvento], [Modulo], [DNI], [DVH]) VALUES (493, N'sofigesualdo', 2, CAST(N'2026-09-06' AS Date), CAST(N'18:01:46.3915585' AS Time), N'Activar Libro', N'Libro', 46956657, N'SD/U4lKn2iyjglZyqExQ1wq4HaqtFpYtqR9wWDrtuOM=')
INSERT [dbo].[Evento] ([IdEvento], [Login], [Criticidad], [Fecha], [Hora], [NombreEvento], [Modulo], [DNI], [DVH]) VALUES (494, N'sofigesualdo', 2, CAST(N'2026-09-06' AS Date), CAST(N'18:02:04.5577649' AS Time), N'Modificar Libro', N'Libro', 46956657, N'8xTAGP8wuXXaqPaHb0OM24sVC3DoxkD8xJkmKhLFBrI=')
INSERT [dbo].[Evento] ([IdEvento], [Login], [Criticidad], [Fecha], [Hora], [NombreEvento], [Modulo], [DNI], [DVH]) VALUES (495, N'sofigesualdo', 1, CAST(N'2026-09-06' AS Date), CAST(N'19:28:30.2544948' AS Time), N'Login', N'Usuario', 46956657, N'PN1uwfQa6NbtdC5N7/th2IJu93AhoMlnRFkrkkUsEo4=')
INSERT [dbo].[Evento] ([IdEvento], [Login], [Criticidad], [Fecha], [Hora], [NombreEvento], [Modulo], [DNI], [DVH]) VALUES (496, N'sofigesualdo', 1, CAST(N'2026-09-06' AS Date), CAST(N'19:29:23.6096245' AS Time), N'Logout', N'Usuario', 46956657, N'oP4wZe3Nw4y2d2EGG9CKt5lFSkE4SeEcNbxqxlspQz4=')
INSERT [dbo].[Evento] ([IdEvento], [Login], [Criticidad], [Fecha], [Hora], [NombreEvento], [Modulo], [DNI], [DVH]) VALUES (497, N'vicky', 1, CAST(N'2026-09-06' AS Date), CAST(N'19:29:28.6786022' AS Time), N'Login', N'Usuario', 12345678, N'zC1lFIkcKS+owSD3DNWM0PBbx6VTUbZb9XUWcIsx64o=')
INSERT [dbo].[Evento] ([IdEvento], [Login], [Criticidad], [Fecha], [Hora], [NombreEvento], [Modulo], [DNI], [DVH]) VALUES (498, N'vicky', 1, CAST(N'2026-09-06' AS Date), CAST(N'19:30:48.2707240' AS Time), N'Crear Usuario', N'Usuario', 12345678, N'1mqXf2yaV4Q40ptqgQC3wYX6f/IUROAqLEfaLad62x8=')
INSERT [dbo].[Evento] ([IdEvento], [Login], [Criticidad], [Fecha], [Hora], [NombreEvento], [Modulo], [DNI], [DVH]) VALUES (499, N'vicky', 1, CAST(N'2026-09-06' AS Date), CAST(N'19:33:02.0609106' AS Time), N'Logout', N'Usuario', 12345678, N'DqlydHUIwYbAPeHg++RzGyn6TP5iq9I+ZnT5MBSzSb0=')
INSERT [dbo].[Evento] ([IdEvento], [Login], [Criticidad], [Fecha], [Hora], [NombreEvento], [Modulo], [DNI], [DVH]) VALUES (500, N'vicky', 1, CAST(N'2026-09-06' AS Date), CAST(N'19:37:04.4362884' AS Time), N'Login', N'Usuario', 12345678, N'u3+THfqLKtMRpZd8DT1SZ5U+6GeyHqXCl2rksQiuVAo=')
GO
INSERT [dbo].[Evento] ([IdEvento], [Login], [Criticidad], [Fecha], [Hora], [NombreEvento], [Modulo], [DNI], [DVH]) VALUES (501, N'vicky', 1, CAST(N'2026-09-06' AS Date), CAST(N'19:38:13.5280962' AS Time), N'Logout', N'Usuario', 12345678, N'IMoh/GKv7+uDDd20wUuc/qTgrbSCiHk8OI7OL4fxweo=')
INSERT [dbo].[Evento] ([IdEvento], [Login], [Criticidad], [Fecha], [Hora], [NombreEvento], [Modulo], [DNI], [DVH]) VALUES (502, N'vicky', 1, CAST(N'2026-09-06' AS Date), CAST(N'19:39:24.3579022' AS Time), N'Login', N'Usuario', 12345678, N'C4qN+8W99DDAcqag6dFyHk7F5ap1zT0nXVpbtGimfi4=')
INSERT [dbo].[Evento] ([IdEvento], [Login], [Criticidad], [Fecha], [Hora], [NombreEvento], [Modulo], [DNI], [DVH]) VALUES (503, N'vicky', 1, CAST(N'2026-09-06' AS Date), CAST(N'19:41:01.6472290' AS Time), N'Login', N'Usuario', 12345678, N'NPOcVHQLopW8+n8NEC21C7uPEVmp9GTJDMlTHkwRg+E=')
INSERT [dbo].[Evento] ([IdEvento], [Login], [Criticidad], [Fecha], [Hora], [NombreEvento], [Modulo], [DNI], [DVH]) VALUES (504, N'vicky', 1, CAST(N'2026-09-06' AS Date), CAST(N'19:41:07.9138342' AS Time), N'Logout', N'Usuario', 12345678, N'6U6vNthF4Q5uVANFifg7RwfQVe1Ek2XYVBGQAphhKeE=')
INSERT [dbo].[Evento] ([IdEvento], [Login], [Criticidad], [Fecha], [Hora], [NombreEvento], [Modulo], [DNI], [DVH]) VALUES (505, N'vicky', 1, CAST(N'2026-09-06' AS Date), CAST(N'19:41:18.5883333' AS Time), N'Login', N'Usuario', 12345678, N'cogAjQ0M1hzgb27kANDqUDwErQI7EHbheirDxCic8Ss=')
INSERT [dbo].[Evento] ([IdEvento], [Login], [Criticidad], [Fecha], [Hora], [NombreEvento], [Modulo], [DNI], [DVH]) VALUES (506, N'vicky', 1, CAST(N'2026-09-06' AS Date), CAST(N'19:41:26.3901437' AS Time), N'Activar / Desactivar Usuario', N'Usuario', 12345678, N'1GRNkrvCjnJnQO8YoyzPJltuOpL/SEbyv/x9echGkGY=')
INSERT [dbo].[Evento] ([IdEvento], [Login], [Criticidad], [Fecha], [Hora], [NombreEvento], [Modulo], [DNI], [DVH]) VALUES (507, N'vicky', 1, CAST(N'2026-09-06' AS Date), CAST(N'19:41:30.0596386' AS Time), N'Logout', N'Usuario', 12345678, N'PJXH6dSJSaquCbEmmiuDF1h8a+/H+8z0gomwOusEdqU=')
INSERT [dbo].[Evento] ([IdEvento], [Login], [Criticidad], [Fecha], [Hora], [NombreEvento], [Modulo], [DNI], [DVH]) VALUES (509, N'vicky', 1, CAST(N'2026-09-06' AS Date), CAST(N'19:41:49.0581705' AS Time), N'Login', N'Usuario', 12345678, N'eGj/i/9OhTp6z5wsG9n7Qw2Itph0jZSihXf6HmJ0pPs=')
INSERT [dbo].[Evento] ([IdEvento], [Login], [Criticidad], [Fecha], [Hora], [NombreEvento], [Modulo], [DNI], [DVH]) VALUES (510, N'vicky', 1, CAST(N'2026-09-06' AS Date), CAST(N'19:41:58.2294621' AS Time), N'Desbloquear Usuario: pepe', N'Usuario', 12345678, N'2EivlfVPd3UpUFK3edykjP3YKjdicCa5/99Okm/wf1E=')
INSERT [dbo].[Evento] ([IdEvento], [Login], [Criticidad], [Fecha], [Hora], [NombreEvento], [Modulo], [DNI], [DVH]) VALUES (511, N'vicky', 1, CAST(N'2026-09-06' AS Date), CAST(N'19:42:22.6502643' AS Time), N'Activar / Desactivar Usuario', N'Usuario', 12345678, N'NA6uJbLvHiTnj0jnusG8NNTK+dQNhuUvdkZc12dX2GE=')
INSERT [dbo].[Evento] ([IdEvento], [Login], [Criticidad], [Fecha], [Hora], [NombreEvento], [Modulo], [DNI], [DVH]) VALUES (512, N'vicky', 1, CAST(N'2026-09-06' AS Date), CAST(N'19:44:12.1750325' AS Time), N'Modificar Usuario: pepe', N'Usuario', 12345678, N'hG0576bn+8V87MYf0vgfstYkbKO1meyORFJTShmmYQE=')
INSERT [dbo].[Evento] ([IdEvento], [Login], [Criticidad], [Fecha], [Hora], [NombreEvento], [Modulo], [DNI], [DVH]) VALUES (513, N'vicky', 1, CAST(N'2026-09-06' AS Date), CAST(N'19:48:21.0964422' AS Time), N'Activar / Desactivar Usuario', N'Usuario', 12345678, N'jX+B01uIIxpgO5T+cF8uqMTBSC2a+MmbgoTMZJR/4ts=')
INSERT [dbo].[Evento] ([IdEvento], [Login], [Criticidad], [Fecha], [Hora], [NombreEvento], [Modulo], [DNI], [DVH]) VALUES (514, N'vicky', 1, CAST(N'2026-09-06' AS Date), CAST(N'19:48:35.9200679' AS Time), N'Activar / Desactivar Usuario', N'Usuario', 12345678, N'EesvmuLTPDIc5+GM/WTBs4KO1Q80qvc1VcUE2hW3gbI=')
INSERT [dbo].[Evento] ([IdEvento], [Login], [Criticidad], [Fecha], [Hora], [NombreEvento], [Modulo], [DNI], [DVH]) VALUES (515, N'vicky', 1, CAST(N'2026-09-09' AS Date), CAST(N'18:01:43.0242009' AS Time), N'Login', N'Usuario', 12345678, N'tg9dkS6urdnTKcRHvoa0i5R6W4ebZbiI5DiWGpXnW3c=')
INSERT [dbo].[Evento] ([IdEvento], [Login], [Criticidad], [Fecha], [Hora], [NombreEvento], [Modulo], [DNI], [DVH]) VALUES (516, N'vicky', 1, CAST(N'2026-09-09' AS Date), CAST(N'18:02:19.7591378' AS Time), N'Login', N'Usuario', 12345678, N'UUCQfOPwr+9bKzi/5DgH+yCNvvc96x5DMxZRsTxtYAc=')
INSERT [dbo].[Evento] ([IdEvento], [Login], [Criticidad], [Fecha], [Hora], [NombreEvento], [Modulo], [DNI], [DVH]) VALUES (517, N'vicky', 1, CAST(N'2026-09-09' AS Date), CAST(N'18:02:35.1370655' AS Time), N'Cambio de Idioma', N'Idioma cambiado con éxito', 12345678, N'prdQDubc1UKsC4JV/g5mSbBBLhEeVh8Eqq0TGmedt9Y=')
INSERT [dbo].[Evento] ([IdEvento], [Login], [Criticidad], [Fecha], [Hora], [NombreEvento], [Modulo], [DNI], [DVH]) VALUES (518, N'vicky', 1, CAST(N'2026-09-09' AS Date), CAST(N'18:02:44.3064862' AS Time), N'Cambio de Idioma', N'Idioma cambiado con éxito', 12345678, N'BjeVAjXADvs/qcCe4Im5+eSSoJcTVfS94QhgwRwZLjc=')
INSERT [dbo].[Evento] ([IdEvento], [Login], [Criticidad], [Fecha], [Hora], [NombreEvento], [Modulo], [DNI], [DVH]) VALUES (519, N'vicky', 1, CAST(N'2026-09-09' AS Date), CAST(N'18:03:04.6981988' AS Time), N'Activar / Desactivar Usuario', N'Usuario', 12345678, N'qkyQ131N33lvJD/4skli6Vpi59cWi2v9e76QQrdzQG0=')
INSERT [dbo].[Evento] ([IdEvento], [Login], [Criticidad], [Fecha], [Hora], [NombreEvento], [Modulo], [DNI], [DVH]) VALUES (520, N'vicky', 1, CAST(N'2026-09-09' AS Date), CAST(N'18:03:11.0927739' AS Time), N'Activar / Desactivar Usuario', N'Usuario', 12345678, N'E/nhWRpLRpxanhwVoWXwwcfpch9qFHWWRy5xMrr241w=')
INSERT [dbo].[Evento] ([IdEvento], [Login], [Criticidad], [Fecha], [Hora], [NombreEvento], [Modulo], [DNI], [DVH]) VALUES (521, N'vicky', 2, CAST(N'2026-09-09' AS Date), CAST(N'18:04:58.5504384' AS Time), N'Crear Libro', N'Libro', 12345678, N'F+4pM39UesR0VmkrSZXOSuMj58E3COKZtR2iIhaC6Yk=')
INSERT [dbo].[Evento] ([IdEvento], [Login], [Criticidad], [Fecha], [Hora], [NombreEvento], [Modulo], [DNI], [DVH]) VALUES (522, N'vicky', 2, CAST(N'2026-09-09' AS Date), CAST(N'18:05:11.8139020' AS Time), N'Desactivar Libro', N'Libro', 12345678, N'5roAChmVEDibQTx1SNOeHOyja+tD6f6I6Dj5T9kiG8w=')
INSERT [dbo].[Evento] ([IdEvento], [Login], [Criticidad], [Fecha], [Hora], [NombreEvento], [Modulo], [DNI], [DVH]) VALUES (523, N'vicky', 1, CAST(N'2026-09-09' AS Date), CAST(N'18:06:49.8899530' AS Time), N'Cambio de Idioma', N'Idioma cambiado con éxito', 12345678, N'Azv+eOQfA12D3mfKNpruyM80yWytqYWOrfKZKp/U3aw=')
INSERT [dbo].[Evento] ([IdEvento], [Login], [Criticidad], [Fecha], [Hora], [NombreEvento], [Modulo], [DNI], [DVH]) VALUES (524, N'vicky', 1, CAST(N'2026-09-09' AS Date), CAST(N'18:06:57.4219579' AS Time), N'Logout', N'Usuario', 12345678, N'/tqGrvg5f8AcqFxvhhXfUz+ND0s/l3aipGCTf2ZGMH4=')
INSERT [dbo].[Evento] ([IdEvento], [Login], [Criticidad], [Fecha], [Hora], [NombreEvento], [Modulo], [DNI], [DVH]) VALUES (525, N'sofigesualdo', 1, CAST(N'2026-09-09' AS Date), CAST(N'18:07:03.2774219' AS Time), N'Login', N'Usuario', 46956657, N'oASVN/m/LnQcFopkZmkQpkuXoI7jas54KQAPIz+GNqk=')
INSERT [dbo].[Evento] ([IdEvento], [Login], [Criticidad], [Fecha], [Hora], [NombreEvento], [Modulo], [DNI], [DVH]) VALUES (526, N'sofigesualdo', 1, CAST(N'2026-09-09' AS Date), CAST(N'18:07:17.2036575' AS Time), N'Logout', N'Usuario', 46956657, N'3UKY/QruWgEkziL6KSyFbri+93fMXVYNwMgvvAPQrFo=')
INSERT [dbo].[Evento] ([IdEvento], [Login], [Criticidad], [Fecha], [Hora], [NombreEvento], [Modulo], [DNI], [DVH]) VALUES (527, N'vicky', 1, CAST(N'2026-09-09' AS Date), CAST(N'19:11:55.6813973' AS Time), N'Login', N'Usuario', 12345678, N'3XfswlWMGogCtsf4oVVoWfSZjj0ZYhOhXUyDikGVZrY=')
INSERT [dbo].[Evento] ([IdEvento], [Login], [Criticidad], [Fecha], [Hora], [NombreEvento], [Modulo], [DNI], [DVH]) VALUES (528, N'vicky', 1, CAST(N'2026-09-09' AS Date), CAST(N'19:11:59.1095014' AS Time), N'Cambio de Idioma', N'Idioma cambiado con éxito', 12345678, N'Mfatz74YuWD0D0wilk9c+qwUdlCsqA7Ekfnkpb5uXqo=')
INSERT [dbo].[Evento] ([IdEvento], [Login], [Criticidad], [Fecha], [Hora], [NombreEvento], [Modulo], [DNI], [DVH]) VALUES (529, N'vicky', 3, CAST(N'2026-09-09' AS Date), CAST(N'19:12:45.6593701' AS Time), N'Alta de Cliente', N'Cliente', 12345678, N'cK8etDJ9zG5F4tZ//d9aDeFNBU8X4aY94WyqYWFeS7g=')
INSERT [dbo].[Evento] ([IdEvento], [Login], [Criticidad], [Fecha], [Hora], [NombreEvento], [Modulo], [DNI], [DVH]) VALUES (530, N'vicky', 3, CAST(N'2026-09-09' AS Date), CAST(N'19:13:26.5135049' AS Time), N'Desactivar Cliente', N'Cliente', 12345678, N'VGLYDCjc4iKyrqcMPIhxZuxlYKdLDlslwJ0NBm/PZNs=')
INSERT [dbo].[Evento] ([IdEvento], [Login], [Criticidad], [Fecha], [Hora], [NombreEvento], [Modulo], [DNI], [DVH]) VALUES (531, N'vicky', 1, CAST(N'2026-09-09' AS Date), CAST(N'19:25:28.7148112' AS Time), N'Login', N'Usuario', 12345678, N'IZGb36TRrB1Yx2pv++EhI4yTalbizm14MxK/I2jV87Q=')
INSERT [dbo].[Evento] ([IdEvento], [Login], [Criticidad], [Fecha], [Hora], [NombreEvento], [Modulo], [DNI], [DVH]) VALUES (532, N'vicky', 3, CAST(N'2026-09-09' AS Date), CAST(N'19:27:14.2359886' AS Time), N'Alta de Cliente', N'Cliente', 12345678, N'3/FUtGSM5TCnf/uf/z22S1oREytelxBH3OWy+6Ry+Ws=')
INSERT [dbo].[Evento] ([IdEvento], [Login], [Criticidad], [Fecha], [Hora], [NombreEvento], [Modulo], [DNI], [DVH]) VALUES (533, N'vicky', 1, CAST(N'2026-09-09' AS Date), CAST(N'19:27:58.3819640' AS Time), N'Logout', N'Usuario', 12345678, N'V8WEYuaBADvweDrNV7zdrGT1IbJpRitYcdwP4oepuvg=')
INSERT [dbo].[Evento] ([IdEvento], [Login], [Criticidad], [Fecha], [Hora], [NombreEvento], [Modulo], [DNI], [DVH]) VALUES (534, N'vicky', 1, CAST(N'2026-09-09' AS Date), CAST(N'19:37:59.8717679' AS Time), N'Login', N'Usuario', 12345678, N'5h+8CBKdEs/08TmAurEZGbhRXYaLjqe0EsIRNpBMExo=')
INSERT [dbo].[Evento] ([IdEvento], [Login], [Criticidad], [Fecha], [Hora], [NombreEvento], [Modulo], [DNI], [DVH]) VALUES (535, N'vicky', 1, CAST(N'2026-09-09' AS Date), CAST(N'19:38:28.8576384' AS Time), N'Cambio de Idioma', N'Idioma cambiado con éxito', 12345678, N'oGGy4b7Db0R0wnMFgq7fwBoUl0INXsiW4jqHvA11t3I=')
INSERT [dbo].[Evento] ([IdEvento], [Login], [Criticidad], [Fecha], [Hora], [NombreEvento], [Modulo], [DNI], [DVH]) VALUES (536, N'vicky', 3, CAST(N'2026-09-09' AS Date), CAST(N'19:38:39.6921907' AS Time), N'Activar Cliente', N'Cliente', 12345678, N'WbKbqAVjSqynkrtF714HONxM0j/dUTH9SujGAsjHuiw=')
INSERT [dbo].[Evento] ([IdEvento], [Login], [Criticidad], [Fecha], [Hora], [NombreEvento], [Modulo], [DNI], [DVH]) VALUES (537, N'vicky', 3, CAST(N'2026-09-09' AS Date), CAST(N'19:38:45.2248658' AS Time), N'Desactivar Cliente', N'Cliente', 12345678, N'85lwj68iJkPJd0gwPLwvE2SGdH3PrbfhgUuItJ+tmwo=')
INSERT [dbo].[Evento] ([IdEvento], [Login], [Criticidad], [Fecha], [Hora], [NombreEvento], [Modulo], [DNI], [DVH]) VALUES (538, N'vicky', 3, CAST(N'2026-09-09' AS Date), CAST(N'19:39:07.3934935' AS Time), N'Modificar Cliente', N'Cliente', 12345678, N'nXmoMmyD45LBjpeGiBsp8cb/IAzotwYhx9Lu8A/bwDA=')
INSERT [dbo].[Evento] ([IdEvento], [Login], [Criticidad], [Fecha], [Hora], [NombreEvento], [Modulo], [DNI], [DVH]) VALUES (539, N'vicky', 1, CAST(N'2026-09-09' AS Date), CAST(N'19:41:49.7834472' AS Time), N'Logout', N'Usuario', 12345678, N'+N77vwOrwi7buSalNCdREwzUmvXQxQuOsAGmjQ1euwc=')
INSERT [dbo].[Evento] ([IdEvento], [Login], [Criticidad], [Fecha], [Hora], [NombreEvento], [Modulo], [DNI], [DVH]) VALUES (540, N'sofigesualdo', 1, CAST(N'2026-09-09' AS Date), CAST(N'19:45:33.7865818' AS Time), N'Login', N'Usuario', 46956657, N'3znE4K1H4/IbhqGQfj4lZhEyjN0QTgmlMTYIt5J6wsw=')
INSERT [dbo].[Evento] ([IdEvento], [Login], [Criticidad], [Fecha], [Hora], [NombreEvento], [Modulo], [DNI], [DVH]) VALUES (541, N'sofigesualdo', 3, CAST(N'2026-09-09' AS Date), CAST(N'19:45:46.3755972' AS Time), N'Modificar Cliente', N'Cliente', 46956657, N'VlYu5S+vE9PvjYOmGIDWhWNv6v12znvShwhRxbNCTV0=')
INSERT [dbo].[Evento] ([IdEvento], [Login], [Criticidad], [Fecha], [Hora], [NombreEvento], [Modulo], [DNI], [DVH]) VALUES (542, N'vicky', 1, CAST(N'2026-09-09' AS Date), CAST(N'19:49:51.8529645' AS Time), N'Login', N'Usuario', 12345678, N'NHXRA5CoBytfnX+cKKEhddw1RpZmEchMVaDkGVxvSEo=')
INSERT [dbo].[Evento] ([IdEvento], [Login], [Criticidad], [Fecha], [Hora], [NombreEvento], [Modulo], [DNI], [DVH]) VALUES (543, N'vicky', 3, CAST(N'2026-09-09' AS Date), CAST(N'19:50:14.5223470' AS Time), N'Alta de Cliente', N'Cliente', 12345678, N'9R5PvMw4H3wYbauqbwzfsB0Q19YF0xuJc0BWFHgTRlg=')
INSERT [dbo].[Evento] ([IdEvento], [Login], [Criticidad], [Fecha], [Hora], [NombreEvento], [Modulo], [DNI], [DVH]) VALUES (544, N'vicky', 3, CAST(N'2026-09-09' AS Date), CAST(N'19:50:21.2387381' AS Time), N'Desactivar Cliente', N'Cliente', 12345678, N'4B3i0uzGqgtvqTM4Jbn575wmWST7rmWZU7CSj6v90jE=')
INSERT [dbo].[Evento] ([IdEvento], [Login], [Criticidad], [Fecha], [Hora], [NombreEvento], [Modulo], [DNI], [DVH]) VALUES (545, N'vicky', 3, CAST(N'2026-09-09' AS Date), CAST(N'19:50:29.6424466' AS Time), N'Activar Cliente', N'Cliente', 12345678, N'tEmhiu84vVb7EjH/ztmR1DVEuBUMEaBlNC8PMygrfyA=')
INSERT [dbo].[Evento] ([IdEvento], [Login], [Criticidad], [Fecha], [Hora], [NombreEvento], [Modulo], [DNI], [DVH]) VALUES (546, N'vicky', 3, CAST(N'2026-09-09' AS Date), CAST(N'19:50:34.8679403' AS Time), N'Modificar Cliente', N'Cliente', 12345678, N'WjobUVXG4eUbZKJEqTId8aVAci39ZzWUwr+A6rfqnyM=')
INSERT [dbo].[Evento] ([IdEvento], [Login], [Criticidad], [Fecha], [Hora], [NombreEvento], [Modulo], [DNI], [DVH]) VALUES (547, N'sofigesualdo', 1, CAST(N'2026-09-09' AS Date), CAST(N'19:53:27.1215570' AS Time), N'Login', N'Usuario', 46956657, N'LuiG9hUWd02+50pJR5xbKN8JDRkTgq0Tr7JMOiApwJU=')
INSERT [dbo].[Evento] ([IdEvento], [Login], [Criticidad], [Fecha], [Hora], [NombreEvento], [Modulo], [DNI], [DVH]) VALUES (548, N'sofigesualdo', 1, CAST(N'2026-09-09' AS Date), CAST(N'19:53:34.2875936' AS Time), N'Cambio de Idioma', N'Idioma cambiado con éxito', 46956657, N'pqnxh8Zcx+cEwJdYuqhD49n+Zij6jQyPwgB8n3h2ccE=')
INSERT [dbo].[Evento] ([IdEvento], [Login], [Criticidad], [Fecha], [Hora], [NombreEvento], [Modulo], [DNI], [DVH]) VALUES (549, N'sofigesualdo', 3, CAST(N'2026-09-09' AS Date), CAST(N'19:53:53.7126414' AS Time), N'Desactivar Cliente', N'Cliente', 46956657, N'6uHcePPdckqY9z/wgbhsV+Y2+2BlDz+oSKBLHQm+T54=')
INSERT [dbo].[Evento] ([IdEvento], [Login], [Criticidad], [Fecha], [Hora], [NombreEvento], [Modulo], [DNI], [DVH]) VALUES (550, N'sofigesualdo', 3, CAST(N'2026-09-09' AS Date), CAST(N'19:53:58.7339171' AS Time), N'Activar Cliente', N'Cliente', 46956657, N'wChK3JX9acTy0bnhlwwhqwSDMYwUJx1i9tjrthYAcYc=')
INSERT [dbo].[Evento] ([IdEvento], [Login], [Criticidad], [Fecha], [Hora], [NombreEvento], [Modulo], [DNI], [DVH]) VALUES (551, N'sofigesualdo', 1, CAST(N'2026-09-09' AS Date), CAST(N'19:55:19.7335918' AS Time), N'Logout', N'Usuario', 46956657, N'C3NCp7pfARZ/17e2Z6M+usTkb6RVLSsiMAoBYUQGCJI=')
INSERT [dbo].[Evento] ([IdEvento], [Login], [Criticidad], [Fecha], [Hora], [NombreEvento], [Modulo], [DNI], [DVH]) VALUES (552, N'vicky', 1, CAST(N'2026-09-09' AS Date), CAST(N'19:55:24.4403812' AS Time), N'Login', N'Usuario', 12345678, N'Gu2JSmHo8TIUeVtL9uGS/+AnskPZuDnWVW3MAJh385U=')
INSERT [dbo].[Evento] ([IdEvento], [Login], [Criticidad], [Fecha], [Hora], [NombreEvento], [Modulo], [DNI], [DVH]) VALUES (553, N'vicky', 1, CAST(N'2026-09-09' AS Date), CAST(N'19:55:53.3159850' AS Time), N'Creación de backup', N'Respaldos', 12345678, N'jj9N3N0zutEDiQ/AEty7eav4HIDv8VEsqJhhWhY9yGA=')
INSERT [dbo].[Evento] ([IdEvento], [Login], [Criticidad], [Fecha], [Hora], [NombreEvento], [Modulo], [DNI], [DVH]) VALUES (554, N'vicky', 1, CAST(N'2026-09-09' AS Date), CAST(N'19:55:56.5637469' AS Time), N'Logout', N'Usuario', 12345678, N'/xXcKzObaJ2fVGZuGU7wcvks87yMy6hOsXnrQ5ZB60Y=')
INSERT [dbo].[Evento] ([IdEvento], [Login], [Criticidad], [Fecha], [Hora], [NombreEvento], [Modulo], [DNI], [DVH]) VALUES (555, N'vicky', 1, CAST(N'2026-09-10' AS Date), CAST(N'11:23:11.3616302' AS Time), N'Login', N'Usuario', 12345678, N'Ob6dXo8/k2LOus6czXx7UKW0t+hrE18ujZp4OAXeet0=')
INSERT [dbo].[Evento] ([IdEvento], [Login], [Criticidad], [Fecha], [Hora], [NombreEvento], [Modulo], [DNI], [DVH]) VALUES (556, N'vicky', 3, CAST(N'2026-09-10' AS Date), CAST(N'11:24:03.1284170' AS Time), N'Alta de Cliente', N'Cliente', 12345678, N'NXmCUk5JGgQmdfruxu3pJ6uriRpYvtBWdrZeQ9v5Tvw=')
INSERT [dbo].[Evento] ([IdEvento], [Login], [Criticidad], [Fecha], [Hora], [NombreEvento], [Modulo], [DNI], [DVH]) VALUES (557, N'vicky', 1, CAST(N'2026-09-10' AS Date), CAST(N'11:48:18.5447770' AS Time), N'Login', N'Usuario', 12345678, N'mP93QBQHrH6BBn0waSxvCl6NjkyKhLBfyrxJzY06qMI=')
INSERT [dbo].[Evento] ([IdEvento], [Login], [Criticidad], [Fecha], [Hora], [NombreEvento], [Modulo], [DNI], [DVH]) VALUES (558, N'vicky', 2, CAST(N'2026-09-10' AS Date), CAST(N'11:49:47.6192948' AS Time), N'Activar Libro', N'Libro', 12345678, N'3YqhxOaKwUgk1bqieDVmmM01571dNrPdtlfdEov3Hyk=')
INSERT [dbo].[Evento] ([IdEvento], [Login], [Criticidad], [Fecha], [Hora], [NombreEvento], [Modulo], [DNI], [DVH]) VALUES (559, N'vicky', 3, CAST(N'2026-09-10' AS Date), CAST(N'11:55:00.3501448' AS Time), N'Alta de Cliente', N'Cliente', 12345678, N'fnl+wEZKCt5R/h76jrt4jiaYv6mP3lYFo8gORFlpaZg=')
INSERT [dbo].[Evento] ([IdEvento], [Login], [Criticidad], [Fecha], [Hora], [NombreEvento], [Modulo], [DNI], [DVH]) VALUES (560, N'vicky', 1, CAST(N'2026-09-10' AS Date), CAST(N'20:28:11.4583126' AS Time), N'Login', N'Usuario', 12345678, N'MKcRDF7HGobNP8wFTQ8kEnpGtzm4fy9AjIul0ZgauM0=')
INSERT [dbo].[Evento] ([IdEvento], [Login], [Criticidad], [Fecha], [Hora], [NombreEvento], [Modulo], [DNI], [DVH]) VALUES (561, N'vicky', 1, CAST(N'2026-09-10' AS Date), CAST(N'20:29:25.9540535' AS Time), N'Login', N'Usuario', 12345678, N'sxdq9ufDaolePIsNKCVG/ixbnz2qAixwjF7SozmudIE=')
INSERT [dbo].[Evento] ([IdEvento], [Login], [Criticidad], [Fecha], [Hora], [NombreEvento], [Modulo], [DNI], [DVH]) VALUES (562, N'vicky', 2, CAST(N'2026-09-10' AS Date), CAST(N'20:29:40.7797070' AS Time), N'Modificar Libro', N'Libro', 12345678, N'wgpFMlY/9Fri5Q6k38uI+gGPe6a2fvG3UWtLak0ieCo=')
INSERT [dbo].[Evento] ([IdEvento], [Login], [Criticidad], [Fecha], [Hora], [NombreEvento], [Modulo], [DNI], [DVH]) VALUES (563, N'vicky', 3, CAST(N'2026-09-10' AS Date), CAST(N'20:29:57.9314452' AS Time), N'Alta de Cliente', N'Cliente', 12345678, N'o6Q8PJFhfFZIsYoCnHyej1aQkHNHxwBbcbLhi6e1Qjw=')
INSERT [dbo].[Evento] ([IdEvento], [Login], [Criticidad], [Fecha], [Hora], [NombreEvento], [Modulo], [DNI], [DVH]) VALUES (564, N'vicky', 1, CAST(N'2026-09-10' AS Date), CAST(N'21:07:02.6179128' AS Time), N'Login', N'Usuario', 12345678, N'fLRSLCtZanKVo7NQuCJi/QDlbHFop2vlcVSDkX7u6MU=')
INSERT [dbo].[Evento] ([IdEvento], [Login], [Criticidad], [Fecha], [Hora], [NombreEvento], [Modulo], [DNI], [DVH]) VALUES (565, N'vicky', 2, CAST(N'2026-09-10' AS Date), CAST(N'21:07:39.0965320' AS Time), N'Modificar Libro', N'Libro', 12345678, N'Qp7QPuECtjmg29oM0Pptcwj/3P4v14UpK0amgLE4SJk=')
INSERT [dbo].[Evento] ([IdEvento], [Login], [Criticidad], [Fecha], [Hora], [NombreEvento], [Modulo], [DNI], [DVH]) VALUES (566, N'vicky', 1, CAST(N'2026-09-10' AS Date), CAST(N'21:07:39.1049482' AS Time), N'Venta cobrada con éxito. Factura: FC-B-2026-2806', N'Venta', 12345678, N's5gi39dFIjJ7MR4P22FP5rYzbJq4O59nbyIhkWApJtA=')
INSERT [dbo].[Evento] ([IdEvento], [Login], [Criticidad], [Fecha], [Hora], [NombreEvento], [Modulo], [DNI], [DVH]) VALUES (567, N'vicky', 1, CAST(N'2026-09-10' AS Date), CAST(N'21:08:19.3413099' AS Time), N'Cambio de Idioma', N'Idioma cambiado con éxito', 12345678, N'jYcX6VC/bF7qhWfRl8QBg9lb3AxgZHVhCl9OEv5FNYc=')
INSERT [dbo].[Evento] ([IdEvento], [Login], [Criticidad], [Fecha], [Hora], [NombreEvento], [Modulo], [DNI], [DVH]) VALUES (568, N'vicky', 1, CAST(N'2026-09-10' AS Date), CAST(N'21:16:03.4369408' AS Time), N'Login', N'Usuario', 12345678, N'eEgDAxJM9PJhUPCXSPzJjDl6oWHiwL7m7Dht9C6r9QQ=')
INSERT [dbo].[Evento] ([IdEvento], [Login], [Criticidad], [Fecha], [Hora], [NombreEvento], [Modulo], [DNI], [DVH]) VALUES (569, N'vicky', 1, CAST(N'2026-09-10' AS Date), CAST(N'21:16:13.2212138' AS Time), N'Cambio de Idioma', N'Idioma cambiado con éxito', 12345678, N'8CGfAAerCZebAknCg0T0/YvJfntfALKVEycokWbrtGs=')
INSERT [dbo].[Evento] ([IdEvento], [Login], [Criticidad], [Fecha], [Hora], [NombreEvento], [Modulo], [DNI], [DVH]) VALUES (570, N'vicky', 1, CAST(N'2026-09-10' AS Date), CAST(N'23:32:53.9098009' AS Time), N'Login', N'Usuario', 12345678, N'k4r7AZjH9/vNpNjDQLpudRUBYmKget16hQetSNM0WX0=')
INSERT [dbo].[Evento] ([IdEvento], [Login], [Criticidad], [Fecha], [Hora], [NombreEvento], [Modulo], [DNI], [DVH]) VALUES (571, N'vicky', 1, CAST(N'2026-09-10' AS Date), CAST(N'23:33:08.0705420' AS Time), N'Creación de backup', N'Respaldos', 12345678, N'FBsZLlF1ouJfzqU9NmyJaJru2J5MlXori54XaAEgrN8=')
INSERT [dbo].[Evento] ([IdEvento], [Login], [Criticidad], [Fecha], [Hora], [NombreEvento], [Modulo], [DNI], [DVH]) VALUES (572, N'vicky', 1, CAST(N'2026-09-10' AS Date), CAST(N'23:33:11.3821919' AS Time), N'Logout', N'Usuario', 12345678, N'SZWBMInjuoMOfuMzenS9ZXn7k74gqNQ1X+rxKw+FmME=')
INSERT [dbo].[Evento] ([IdEvento], [Login], [Criticidad], [Fecha], [Hora], [NombreEvento], [Modulo], [DNI], [DVH]) VALUES (573, N'vicky', 1, CAST(N'2026-09-11' AS Date), CAST(N'17:30:01.6333950' AS Time), N'Login', N'Usuario', 12345678, N'sGvjOsI9Hh5UkR2uNa1VsjX3P5XaOtX8DTWYdZe5qT8=')
INSERT [dbo].[Evento] ([IdEvento], [Login], [Criticidad], [Fecha], [Hora], [NombreEvento], [Modulo], [DNI], [DVH]) VALUES (574, N'vicky', 1, CAST(N'2026-09-11' AS Date), CAST(N'17:30:24.1748467' AS Time), N'Logout', N'Usuario', 12345678, N'Eb4sRBTNkrhpic3z037St8dI4jCdd08PR9+T3cHmzYM=')
INSERT [dbo].[Evento] ([IdEvento], [Login], [Criticidad], [Fecha], [Hora], [NombreEvento], [Modulo], [DNI], [DVH]) VALUES (575, N'vicky', 1, CAST(N'2026-09-11' AS Date), CAST(N'17:32:44.9425655' AS Time), N'Login', N'Usuario', 12345678, N'VojxvFBThwrxjxEnRCW3zY2Jak/WeF00qDBa/VxE9nQ=')
INSERT [dbo].[Evento] ([IdEvento], [Login], [Criticidad], [Fecha], [Hora], [NombreEvento], [Modulo], [DNI], [DVH]) VALUES (576, N'vicky', 1, CAST(N'2026-09-11' AS Date), CAST(N'17:32:53.8964177' AS Time), N'Cambio de Idioma', N'Idioma cambiado con éxito', 12345678, N'z9+Gz+k7t6/Pj6IA2bbdzJpMUppPC1Y28aTd66gBSqM=')
INSERT [dbo].[Evento] ([IdEvento], [Login], [Criticidad], [Fecha], [Hora], [NombreEvento], [Modulo], [DNI], [DVH]) VALUES (577, N'vicky', 1, CAST(N'2026-09-11' AS Date), CAST(N'17:40:59.1843811' AS Time), N'Login', N'Usuario', 12345678, N'6K2gKSpnHjDKKmFurGshut3p96GUU0B35v5y3MgsuNY=')
INSERT [dbo].[Evento] ([IdEvento], [Login], [Criticidad], [Fecha], [Hora], [NombreEvento], [Modulo], [DNI], [DVH]) VALUES (578, N'vicky', 1, CAST(N'2026-09-11' AS Date), CAST(N'17:41:06.2485996' AS Time), N'Cambio de Idioma', N'Idioma cambiado con éxito', 12345678, N'0BPo6no5Y/zC6n6OeQQ7EWxUfhbs81GeKHv9RN3HMm8=')
INSERT [dbo].[Evento] ([IdEvento], [Login], [Criticidad], [Fecha], [Hora], [NombreEvento], [Modulo], [DNI], [DVH]) VALUES (579, N'vicky', 1, CAST(N'2026-09-11' AS Date), CAST(N'17:41:21.3194176' AS Time), N'Logout', N'Usuario', 12345678, N'n2Qvum2/mvJfCZhWEHNLCdfgh40ExbAiJu/Qxst4chg=')
INSERT [dbo].[Evento] ([IdEvento], [Login], [Criticidad], [Fecha], [Hora], [NombreEvento], [Modulo], [DNI], [DVH]) VALUES (580, N'vicky', 1, CAST(N'2026-09-11' AS Date), CAST(N'17:46:06.2161240' AS Time), N'Login', N'Usuario', 12345678, N'mi85fAqoqNF5W2Zq80cLnW42QHkd1a5NNuR2GLB0j0U=')
INSERT [dbo].[Evento] ([IdEvento], [Login], [Criticidad], [Fecha], [Hora], [NombreEvento], [Modulo], [DNI], [DVH]) VALUES (581, N'vicky', 1, CAST(N'2026-09-11' AS Date), CAST(N'17:46:11.4764717' AS Time), N'Cambio de Idioma', N'Idioma cambiado con éxito', 12345678, N'KGM+4EqDnRzqjvoHvgPfZPoz1Wq4JRuhy2wmARAVqy0=')
INSERT [dbo].[Evento] ([IdEvento], [Login], [Criticidad], [Fecha], [Hora], [NombreEvento], [Modulo], [DNI], [DVH]) VALUES (582, N'vicky', 1, CAST(N'2026-09-11' AS Date), CAST(N'19:48:11.3746753' AS Time), N'Login', N'Usuario', 12345678, N'7i0Vtdh5dAzRk5qiow/ueV1pLGvwY8YbzEkxvrFIarQ=')
INSERT [dbo].[Evento] ([IdEvento], [Login], [Criticidad], [Fecha], [Hora], [NombreEvento], [Modulo], [DNI], [DVH]) VALUES (583, N'vicky', 1, CAST(N'2026-09-11' AS Date), CAST(N'19:48:29.0989378' AS Time), N'Cambio de Idioma', N'Idioma cambiado con éxito', 12345678, N'1qXDsLPES1xKTNhNh3YuMHlnSb6aCl39LINvzi/sYGI=')
INSERT [dbo].[Evento] ([IdEvento], [Login], [Criticidad], [Fecha], [Hora], [NombreEvento], [Modulo], [DNI], [DVH]) VALUES (584, N'vicky', 1, CAST(N'2026-09-11' AS Date), CAST(N'19:48:46.4967513' AS Time), N'Creación de backup', N'Respaldos', 12345678, N'JsW+dfIiWKo9CCh7vftv3WlbU102Ft4Qv3+x7/UJRnw=')
INSERT [dbo].[Evento] ([IdEvento], [Login], [Criticidad], [Fecha], [Hora], [NombreEvento], [Modulo], [DNI], [DVH]) VALUES (585, N'vicky', 2, CAST(N'2026-09-11' AS Date), CAST(N'19:50:28.3559741' AS Time), N'Modificar Libro', N'Libro', 12345678, N'MVeS9lpgxbMJB4PVH9GboDlxuaxf4ZnWAa+/gSpY8+Y=')
INSERT [dbo].[Evento] ([IdEvento], [Login], [Criticidad], [Fecha], [Hora], [NombreEvento], [Modulo], [DNI], [DVH]) VALUES (586, N'vicky', 1, CAST(N'2026-09-11' AS Date), CAST(N'19:50:28.3960444' AS Time), N'Venta realizada. Factura: FC-B-2026-8307', N'Venta', 12345678, N'vei4x7Hvo6q2mazDAEIrT1yv0bisReO/7QCaPtFKq0I=')
INSERT [dbo].[Evento] ([IdEvento], [Login], [Criticidad], [Fecha], [Hora], [NombreEvento], [Modulo], [DNI], [DVH]) VALUES (587, N'vicky', 1, CAST(N'2026-09-11' AS Date), CAST(N'19:51:40.5650229' AS Time), N'Logout', N'Usuario', 12345678, N'BrvuUPkHVx/gQkmL6y/qTUrgJOmUniEJNf0TvkFZE6A=')
INSERT [dbo].[Evento] ([IdEvento], [Login], [Criticidad], [Fecha], [Hora], [NombreEvento], [Modulo], [DNI], [DVH]) VALUES (588, N'vicky', 1, CAST(N'2026-09-12' AS Date), CAST(N'14:41:28.7786069' AS Time), N'Login', N'Usuario', 12345678, N'gQaI0OHrf2O4Qw343eGK5qiNVEsP2sVllOMGqOrZWd0=')
INSERT [dbo].[Evento] ([IdEvento], [Login], [Criticidad], [Fecha], [Hora], [NombreEvento], [Modulo], [DNI], [DVH]) VALUES (589, N'vicky', 1, CAST(N'2026-09-12' AS Date), CAST(N'14:41:56.6157688' AS Time), N'Cambio de Idioma', N'Idioma cambiado con éxito', 12345678, N'jmTloizeWTc/LwfnYt/TirSC0JbqP6xsKYMSqIaXziY=')
INSERT [dbo].[Evento] ([IdEvento], [Login], [Criticidad], [Fecha], [Hora], [NombreEvento], [Modulo], [DNI], [DVH]) VALUES (590, N'vicky', 1, CAST(N'2026-09-12' AS Date), CAST(N'14:42:01.7146048' AS Time), N'Cambio de Idioma', N'Idioma cambiado con éxito', 12345678, N'c6oMTQ6PgBuYWlnb8Z8VBSW0ZkIplQ49ErZaaUFVOnE=')
INSERT [dbo].[Evento] ([IdEvento], [Login], [Criticidad], [Fecha], [Hora], [NombreEvento], [Modulo], [DNI], [DVH]) VALUES (591, N'vicky', 1, CAST(N'2026-09-12' AS Date), CAST(N'14:42:34.0352972' AS Time), N'Activar / Desactivar Usuario', N'Usuario', 12345678, N'pe/zIt7IXUKtNR1lsLrl4iFciSuTC+YgKII4iGuZr+Y=')
INSERT [dbo].[Evento] ([IdEvento], [Login], [Criticidad], [Fecha], [Hora], [NombreEvento], [Modulo], [DNI], [DVH]) VALUES (592, N'vicky', 1, CAST(N'2026-09-12' AS Date), CAST(N'14:42:53.8432857' AS Time), N'Modificar Usuario: pepeargento', N'Usuario', 12345678, N'/4J0T6pFDochoiCBntOiqSl2TZKDQVFNUhMgOzhDV70=')
INSERT [dbo].[Evento] ([IdEvento], [Login], [Criticidad], [Fecha], [Hora], [NombreEvento], [Modulo], [DNI], [DVH]) VALUES (593, N'vicky', 3, CAST(N'2026-09-12' AS Date), CAST(N'14:48:49.2811246' AS Time), N'Alta de Cliente', N'Cliente', 12345678, N'2u6wmoejnusRvj7c1nASUexXP4ZCEZj3ZV5jf66mjfM=')
INSERT [dbo].[Evento] ([IdEvento], [Login], [Criticidad], [Fecha], [Hora], [NombreEvento], [Modulo], [DNI], [DVH]) VALUES (594, N'vicky', 2, CAST(N'2026-09-12' AS Date), CAST(N'14:50:44.5908489' AS Time), N'Modificar Libro', N'Libro', 12345678, N'VVGd1UI67cABu/PuWShjrjBGsKSfpgqwXO+WckRj7VM=')
INSERT [dbo].[Evento] ([IdEvento], [Login], [Criticidad], [Fecha], [Hora], [NombreEvento], [Modulo], [DNI], [DVH]) VALUES (595, N'vicky', 1, CAST(N'2026-09-12' AS Date), CAST(N'14:50:44.7013849' AS Time), N'Venta realizada. Factura: FC-B-2026-7593', N'Venta', 12345678, N'8sHlP3h6FSkpSQzKgQ7O2rUM7d6JWaDP12aEFdg37Ck=')
INSERT [dbo].[Evento] ([IdEvento], [Login], [Criticidad], [Fecha], [Hora], [NombreEvento], [Modulo], [DNI], [DVH]) VALUES (596, N'vicky', 2, CAST(N'2026-09-12' AS Date), CAST(N'14:51:21.3357380' AS Time), N'Desactivar Libro', N'Libro', 12345678, N'ezd7R+p+JJAqJsg12Vi9S3HScXvXuCKrvmTb96oWs9M=')
INSERT [dbo].[Evento] ([IdEvento], [Login], [Criticidad], [Fecha], [Hora], [NombreEvento], [Modulo], [DNI], [DVH]) VALUES (597, N'vicky', 1, CAST(N'2026-09-12' AS Date), CAST(N'14:52:23.6971971' AS Time), N'Logout', N'Usuario', 12345678, N'6qRHi4c/q3EYrv74HtA4zHn0ZMc1GXpjMUL9TmylMOI=')
INSERT [dbo].[Evento] ([IdEvento], [Login], [Criticidad], [Fecha], [Hora], [NombreEvento], [Modulo], [DNI], [DVH]) VALUES (598, N'sofigesualdo', 1, CAST(N'2026-09-12' AS Date), CAST(N'14:52:48.1046158' AS Time), N'Login', N'Usuario', 46956657, N'a7W3TAWoXrQgOfBTHeksBmob2AXHRHv/9y01Hvi7hlU=')
INSERT [dbo].[Evento] ([IdEvento], [Login], [Criticidad], [Fecha], [Hora], [NombreEvento], [Modulo], [DNI], [DVH]) VALUES (599, N'sofigesualdo', 1, CAST(N'2026-09-12' AS Date), CAST(N'14:53:09.6724752' AS Time), N'Cambio de Idioma', N'Idioma cambiado con éxito', 46956657, N'WUwWg8H+mxnRLZ1VVjqT07yQJzLC060AD3WEFHHO3b0=')
INSERT [dbo].[Evento] ([IdEvento], [Login], [Criticidad], [Fecha], [Hora], [NombreEvento], [Modulo], [DNI], [DVH]) VALUES (600, N'sofigesualdo', 1, CAST(N'2026-09-12' AS Date), CAST(N'14:53:21.6407890' AS Time), N'Cambio de Idioma', N'Idioma cambiado con éxito', 46956657, N'qmfrN0a5V6bvI0PsSf/YTY7GHKPwDprex8QWXseiMYE=')
INSERT [dbo].[Evento] ([IdEvento], [Login], [Criticidad], [Fecha], [Hora], [NombreEvento], [Modulo], [DNI], [DVH]) VALUES (601, N'sofigesualdo', 1, CAST(N'2026-09-12' AS Date), CAST(N'14:53:58.9584869' AS Time), N'Logout', N'Usuario', 46956657, N'43q8NvhOL/peTcoKkQOKvVWZfnUsy4nW5a+N6fgodPc=')
GO
INSERT [dbo].[Evento] ([IdEvento], [Login], [Criticidad], [Fecha], [Hora], [NombreEvento], [Modulo], [DNI], [DVH]) VALUES (602, N'vicky', 1, CAST(N'2026-09-12' AS Date), CAST(N'14:54:02.3042110' AS Time), N'Login', N'Usuario', 12345678, N'WYvqGNMkIOjIeB+pcXCe5xpicocAf0lBssHo9YdVFTE=')
INSERT [dbo].[Evento] ([IdEvento], [Login], [Criticidad], [Fecha], [Hora], [NombreEvento], [Modulo], [DNI], [DVH]) VALUES (603, N'vicky', 1, CAST(N'2026-09-12' AS Date), CAST(N'14:54:36.4750134' AS Time), N'Login', N'Usuario', 12345678, N'NWNfNuspVxmcIzsOpW8Pfxp+aHL9Ty3ot3pH5M36SSA=')
INSERT [dbo].[Evento] ([IdEvento], [Login], [Criticidad], [Fecha], [Hora], [NombreEvento], [Modulo], [DNI], [DVH]) VALUES (604, N'vicky', 1, CAST(N'2026-09-12' AS Date), CAST(N'14:55:04.6382697' AS Time), N'Modificar Usuario: sofigesualdo', N'Usuario', 12345678, N'ixRzGlAcTPExR2fB17LHUMSJe5coiIZVDQFQbfFA+74=')
INSERT [dbo].[Evento] ([IdEvento], [Login], [Criticidad], [Fecha], [Hora], [NombreEvento], [Modulo], [DNI], [DVH]) VALUES (605, N'vicky', 1, CAST(N'2026-09-12' AS Date), CAST(N'14:55:12.5073196' AS Time), N'Logout', N'Usuario', 12345678, N'VVPdZ/DZesILWtPeOX7UjwJ2/oaZpxvD5hsH3f5HcHA=')
INSERT [dbo].[Evento] ([IdEvento], [Login], [Criticidad], [Fecha], [Hora], [NombreEvento], [Modulo], [DNI], [DVH]) VALUES (606, N'vicky', 1, CAST(N'2026-09-12' AS Date), CAST(N'15:59:50.2422222' AS Time), N'Login', N'Usuario', 12345678, N'9vYv8ydTPIvKR3QuFxUPQg7MPVZ7bavGuBU2TFekotA=')
INSERT [dbo].[Evento] ([IdEvento], [Login], [Criticidad], [Fecha], [Hora], [NombreEvento], [Modulo], [DNI], [DVH]) VALUES (607, N'vicky', 1, CAST(N'2026-09-12' AS Date), CAST(N'16:01:17.5121352' AS Time), N'Login', N'Usuario', 12345678, N'wyYOgg2R6G87SKsD+HPwbuqru/8waJQ0GQk5Pu0D4CM=')
INSERT [dbo].[Evento] ([IdEvento], [Login], [Criticidad], [Fecha], [Hora], [NombreEvento], [Modulo], [DNI], [DVH]) VALUES (609, N'sofigesualdo', 1, CAST(N'2026-09-12' AS Date), CAST(N'16:12:36.8850624' AS Time), N'Modificar Usuario: pepeargento', N'Usuario', 46956657, N'1BLXfqxNsrtmTH5TrQOB7gTW+vTUbbVL7YOpwCiCSTU=')
INSERT [dbo].[Evento] ([IdEvento], [Login], [Criticidad], [Fecha], [Hora], [NombreEvento], [Modulo], [DNI], [DVH]) VALUES (610, N'sofigesualdo', 1, CAST(N'2026-09-12' AS Date), CAST(N'16:12:36.9870444' AS Time), N'Modificar Usuario: pepeargento', N'Usuario', 46956657, N'cN+fGDBH8odSeOHDPj+5M3eIGCuD4h0kOOAomtdix0k=')
INSERT [dbo].[Evento] ([IdEvento], [Login], [Criticidad], [Fecha], [Hora], [NombreEvento], [Modulo], [DNI], [DVH]) VALUES (611, N'sofigesualdo', 1, CAST(N'2026-09-12' AS Date), CAST(N'16:13:27.9362551' AS Time), N'Modificar Usuario: pepeargento', N'Usuario', 46956657, N'bKbyDEXacdY/GbZAuEhn8xFWv6IoCQUYrkCFvtxhAvA=')
INSERT [dbo].[Evento] ([IdEvento], [Login], [Criticidad], [Fecha], [Hora], [NombreEvento], [Modulo], [DNI], [DVH]) VALUES (612, N'sofigesualdo', 1, CAST(N'2026-09-12' AS Date), CAST(N'16:28:06.3237282' AS Time), N'Login', N'Usuario', 46956657, N'+VsHuKCwLDAk+asp8rN0HKEAXYg32Dk95E8E+BmSDMk=')
INSERT [dbo].[Evento] ([IdEvento], [Login], [Criticidad], [Fecha], [Hora], [NombreEvento], [Modulo], [DNI], [DVH]) VALUES (613, N'sofigesualdo', 1, CAST(N'2026-09-12' AS Date), CAST(N'16:29:06.0083926' AS Time), N'Logout', N'Usuario', 46956657, N'7u17dRPxkOaEJGNSIMApAGfM5etuioj8sh3fW1dJxaE=')
INSERT [dbo].[Evento] ([IdEvento], [Login], [Criticidad], [Fecha], [Hora], [NombreEvento], [Modulo], [DNI], [DVH]) VALUES (614, N'vicky', 1, CAST(N'2026-09-12' AS Date), CAST(N'16:29:09.6249504' AS Time), N'Login', N'Usuario', 12345678, N'fEl0QziprFD+yueVFsMkOUjIEeS1weQ2V4mHAMuU5us=')
INSERT [dbo].[Evento] ([IdEvento], [Login], [Criticidad], [Fecha], [Hora], [NombreEvento], [Modulo], [DNI], [DVH]) VALUES (615, N'vicky', 1, CAST(N'2026-09-12' AS Date), CAST(N'16:29:23.3435987' AS Time), N'Modificar Usuario: pepe', N'Usuario', 12345678, N'Z5I6zicBfjp/3K/3H0044fkBwdH2XPfAiatBFqtClWs=')
INSERT [dbo].[Evento] ([IdEvento], [Login], [Criticidad], [Fecha], [Hora], [NombreEvento], [Modulo], [DNI], [DVH]) VALUES (616, N'vicky', 1, CAST(N'2026-09-12' AS Date), CAST(N'16:29:41.3278524' AS Time), N'Logout', N'Usuario', 12345678, N'/MCpK4SKcBDr5L+b4Jroca2We+jCUSTihGxG0yr6SUI=')
INSERT [dbo].[Evento] ([IdEvento], [Login], [Criticidad], [Fecha], [Hora], [NombreEvento], [Modulo], [DNI], [DVH]) VALUES (617, N'sofigesualdo', 1, CAST(N'2026-09-12' AS Date), CAST(N'16:29:47.1949767' AS Time), N'Login', N'Usuario', 46956657, N'gVzYlhxPE8p5PitOYK7txyR6+/WJgnbPzcXNIPk+U/4=')
INSERT [dbo].[Evento] ([IdEvento], [Login], [Criticidad], [Fecha], [Hora], [NombreEvento], [Modulo], [DNI], [DVH]) VALUES (618, N'sofigesualdo', 1, CAST(N'2026-09-12' AS Date), CAST(N'16:29:51.2000987' AS Time), N'Logout', N'Usuario', 46956657, N'9tSKfKgfGC8RhFsKrLOI1u39ob/X/ZXSoswGXUrwJZI=')
INSERT [dbo].[Evento] ([IdEvento], [Login], [Criticidad], [Fecha], [Hora], [NombreEvento], [Modulo], [DNI], [DVH]) VALUES (619, N'vicky', 1, CAST(N'2026-09-26' AS Date), CAST(N'23:21:45.1754687' AS Time), N'Login', N'Usuario', 12345678, N'hOxqt1kdZ4L8QUU+uz+H9OWPXQYQxWvPpGMp3hQpxgg=')
INSERT [dbo].[Evento] ([IdEvento], [Login], [Criticidad], [Fecha], [Hora], [NombreEvento], [Modulo], [DNI], [DVH]) VALUES (620, N'vicky', 1, CAST(N'2026-10-02' AS Date), CAST(N'20:46:40.6643338' AS Time), N'Login', N'Usuario', 12345678, N'o+OCyZdEcy544+XJ6pH3MyXsbJqIeZd4oHFJVwC/8uM=')
INSERT [dbo].[Evento] ([IdEvento], [Login], [Criticidad], [Fecha], [Hora], [NombreEvento], [Modulo], [DNI], [DVH]) VALUES (621, N'vicky', 1, CAST(N'2026-10-02' AS Date), CAST(N'20:46:43.5377903' AS Time), N'Cambio de Idioma', N'Idioma cambiado con éxito', 12345678, N'43vvVJwLRZslnwlqne/Jur4nTpv//z6kyiOLg+QfqKs=')
INSERT [dbo].[Evento] ([IdEvento], [Login], [Criticidad], [Fecha], [Hora], [NombreEvento], [Modulo], [DNI], [DVH]) VALUES (622, N'vicky', 1, CAST(N'2026-10-02' AS Date), CAST(N'20:51:28.1110171' AS Time), N'Logout', N'Usuario', 12345678, N'UArX86fOn+XyiFEi995XMnXbaPQt0PgpFrBps0DSqEo=')
INSERT [dbo].[Evento] ([IdEvento], [Login], [Criticidad], [Fecha], [Hora], [NombreEvento], [Modulo], [DNI], [DVH]) VALUES (623, N'vicky', 1, CAST(N'2026-10-02' AS Date), CAST(N'20:51:42.5143383' AS Time), N'Login', N'Usuario', 12345678, N'gUXuBCGZCDc08IqNkNFPS7gPDyA+8ENBnDBC63EyLlw=')
INSERT [dbo].[Evento] ([IdEvento], [Login], [Criticidad], [Fecha], [Hora], [NombreEvento], [Modulo], [DNI], [DVH]) VALUES (624, N'vicky', 1, CAST(N'2026-10-02' AS Date), CAST(N'20:51:45.6066229' AS Time), N'Cambio de Idioma', N'Idioma cambiado con éxito', 12345678, N'0xYFTkp0ZeNvnY8HqdX8q4VXYpFjsJw0haxsljCLey0=')
INSERT [dbo].[Evento] ([IdEvento], [Login], [Criticidad], [Fecha], [Hora], [NombreEvento], [Modulo], [DNI], [DVH]) VALUES (625, N'vicky', 1, CAST(N'2026-10-02' AS Date), CAST(N'20:54:22.9155116' AS Time), N'Login', N'Usuario', 12345678, N'zDut2yYGf/DdIOvy2lVORfxQgy20W7HlgGfa9Li5F+4=')
INSERT [dbo].[Evento] ([IdEvento], [Login], [Criticidad], [Fecha], [Hora], [NombreEvento], [Modulo], [DNI], [DVH]) VALUES (626, N'vicky', 1, CAST(N'2026-10-02' AS Date), CAST(N'20:54:27.7312530' AS Time), N'Cambio de Idioma', N'Idioma cambiado con éxito', 12345678, N'1dBmMQRZckYKI8r3QoyAcn6NOQTFs4X1XVSYa9jFayA=')
INSERT [dbo].[Evento] ([IdEvento], [Login], [Criticidad], [Fecha], [Hora], [NombreEvento], [Modulo], [DNI], [DVH]) VALUES (627, N'vicky', 1, CAST(N'2026-10-02' AS Date), CAST(N'20:56:12.2053789' AS Time), N'Login', N'Usuario', 12345678, N'dX7cip7SOIItLzWZrORUw9dVQ8R6ONkRBtUxjCbWfp0=')
INSERT [dbo].[Evento] ([IdEvento], [Login], [Criticidad], [Fecha], [Hora], [NombreEvento], [Modulo], [DNI], [DVH]) VALUES (628, N'vicky', 1, CAST(N'2026-10-02' AS Date), CAST(N'21:01:21.5284357' AS Time), N'Logout', N'Usuario', 12345678, N'bV12iaQetAIqC9WjgcG3XcmWGs7xPmyvF2caUjJR2R4=')
INSERT [dbo].[Evento] ([IdEvento], [Login], [Criticidad], [Fecha], [Hora], [NombreEvento], [Modulo], [DNI], [DVH]) VALUES (629, N'sofigesualdo', 1, CAST(N'2026-10-04' AS Date), CAST(N'18:45:18.6627346' AS Time), N'Login', N'Usuario', 46956657, N'CYbBS8mBiKhZTj5Wm9LQ7Uc3ylV9l2B+tEDZVmJK0z8=')
INSERT [dbo].[Evento] ([IdEvento], [Login], [Criticidad], [Fecha], [Hora], [NombreEvento], [Modulo], [DNI], [DVH]) VALUES (630, N'sofigesualdo', 1, CAST(N'2026-10-04' AS Date), CAST(N'18:45:25.2902716' AS Time), N'Logout', N'Usuario', 46956657, N'yi0A3+K76SKaDl6YjWKPkReX1mOSz6bETup7WzNDmjc=')
INSERT [dbo].[Evento] ([IdEvento], [Login], [Criticidad], [Fecha], [Hora], [NombreEvento], [Modulo], [DNI], [DVH]) VALUES (631, N'vicky', 1, CAST(N'2026-10-04' AS Date), CAST(N'18:45:28.6667810' AS Time), N'Login', N'Usuario', 12345678, N'mI9OHYS3vqjZ7Omhcy+39KvUu7WI3ac4U8IPN8WBSI4=')
INSERT [dbo].[Evento] ([IdEvento], [Login], [Criticidad], [Fecha], [Hora], [NombreEvento], [Modulo], [DNI], [DVH]) VALUES (632, N'vicky', 1, CAST(N'2026-10-04' AS Date), CAST(N'19:11:11.3134213' AS Time), N'Login', N'Usuario', 12345678, N'klLaGbZKwxS6qLDNZh/x/dgOx72VJdhOMXuC5bTB49U=')
INSERT [dbo].[Evento] ([IdEvento], [Login], [Criticidad], [Fecha], [Hora], [NombreEvento], [Modulo], [DNI], [DVH]) VALUES (633, N'vicky', 1, CAST(N'2026-10-04' AS Date), CAST(N'19:11:38.5278551' AS Time), N'Cambio de Idioma', N'Idioma cambiado con éxito', 12345678, N'RMD2ym7UdX4Brd7JsdtswnPlfnAply9PT/I9tkp/tT0=')
INSERT [dbo].[Evento] ([IdEvento], [Login], [Criticidad], [Fecha], [Hora], [NombreEvento], [Modulo], [DNI], [DVH]) VALUES (634, N'vicky', 1, CAST(N'2026-10-04' AS Date), CAST(N'19:12:25.6928584' AS Time), N'Cambio de Idioma', N'Idioma cambiado con éxito', 12345678, N'fYnCilAHPP6YdRoeVcTgj7jHUAWIenD0vEOaF6HawPM=')
INSERT [dbo].[Evento] ([IdEvento], [Login], [Criticidad], [Fecha], [Hora], [NombreEvento], [Modulo], [DNI], [DVH]) VALUES (635, N'vicky', 1, CAST(N'2026-10-04' AS Date), CAST(N'19:12:40.6037359' AS Time), N'Creación de nuevo Perfil', N'Perfiles', 12345678, N'pkqBSdfMniB+LzJa1cvL1d24h98jvsu/kptHvS+iZFs=')
INSERT [dbo].[Evento] ([IdEvento], [Login], [Criticidad], [Fecha], [Hora], [NombreEvento], [Modulo], [DNI], [DVH]) VALUES (636, N'vicky', 1, CAST(N'2026-10-04' AS Date), CAST(N'19:13:05.9721035' AS Time), N'Modificar Usuario: vicky', N'Usuario', 12345678, N'Ud6n+g22B/kXGdDSB42QxlJiERh6938wF5sJas6WBbE=')
INSERT [dbo].[Evento] ([IdEvento], [Login], [Criticidad], [Fecha], [Hora], [NombreEvento], [Modulo], [DNI], [DVH]) VALUES (637, N'vicky', 1, CAST(N'2026-10-04' AS Date), CAST(N'19:13:38.6660749' AS Time), N'Logout', N'Usuario', 12345678, N'b5wAkAqLnS/bIEXqPrN8ldzTQPljNOi52PLrnCI64Lc=')
INSERT [dbo].[Evento] ([IdEvento], [Login], [Criticidad], [Fecha], [Hora], [NombreEvento], [Modulo], [DNI], [DVH]) VALUES (638, N'vicky', 1, CAST(N'2026-10-04' AS Date), CAST(N'19:13:43.7664214' AS Time), N'Login', N'Usuario', 12345678, N'tQSZuW4z6Fuu+QlgL8e5+Uzrp85yZUq9+IMIoYz42d8=')
INSERT [dbo].[Evento] ([IdEvento], [Login], [Criticidad], [Fecha], [Hora], [NombreEvento], [Modulo], [DNI], [DVH]) VALUES (639, N'vicky', 1, CAST(N'2026-10-04' AS Date), CAST(N'19:33:45.1668320' AS Time), N'Login', N'Usuario', 12345678, N'KSc1VmofZu3T7JGnSA25cC8BbBRVmM4/6enUJ23QJAg=')
INSERT [dbo].[Evento] ([IdEvento], [Login], [Criticidad], [Fecha], [Hora], [NombreEvento], [Modulo], [DNI], [DVH]) VALUES (640, N'vicky', 1, CAST(N'2026-10-04' AS Date), CAST(N'19:34:17.1050994' AS Time), N'Cambio de Idioma', N'Idioma cambiado con éxito', 12345678, N'PiC7PfW+TTW0QhWRbaX7eK/llT94BC6/jKvryhYcu6Q=')
INSERT [dbo].[Evento] ([IdEvento], [Login], [Criticidad], [Fecha], [Hora], [NombreEvento], [Modulo], [DNI], [DVH]) VALUES (641, N'vicky', 1, CAST(N'2026-10-04' AS Date), CAST(N'19:34:36.4863318' AS Time), N'Cambio de Idioma', N'Idioma cambiado con éxito', 12345678, N'Jm0roWcDQBTzbO1kHqaHM4f+ahYFQfpTX/9HtXWSiUw=')
INSERT [dbo].[Evento] ([IdEvento], [Login], [Criticidad], [Fecha], [Hora], [NombreEvento], [Modulo], [DNI], [DVH]) VALUES (642, N'vicky', 1, CAST(N'2026-10-04' AS Date), CAST(N'19:40:19.3349635' AS Time), N'Login', N'Usuario', 12345678, N'+ECN1r7cGmnuz1pyysRHg7tegPBx3xPEl7eqqMOaPQ8=')
INSERT [dbo].[Evento] ([IdEvento], [Login], [Criticidad], [Fecha], [Hora], [NombreEvento], [Modulo], [DNI], [DVH]) VALUES (643, N'vicky', 1, CAST(N'2026-10-04' AS Date), CAST(N'19:41:28.0580941' AS Time), N'Crear Usuario', N'Usuario', 12345678, N'nPDtKQ4bj4Q9dczAXt9wzKrWeswwXSV/pwjXmjktxSg=')
INSERT [dbo].[Evento] ([IdEvento], [Login], [Criticidad], [Fecha], [Hora], [NombreEvento], [Modulo], [DNI], [DVH]) VALUES (644, N'vicky', 1, CAST(N'2026-10-04' AS Date), CAST(N'19:43:09.9263786' AS Time), N'Logout', N'Usuario', 12345678, N'M81tS9vYw13TZOGBgl+5l6YZKkIAZc3EHrh/KZBJ7f0=')
INSERT [dbo].[Evento] ([IdEvento], [Login], [Criticidad], [Fecha], [Hora], [NombreEvento], [Modulo], [DNI], [DVH]) VALUES (645, N'pruebaAdmin', 1, CAST(N'2026-10-04' AS Date), CAST(N'19:44:40.6416215' AS Time), N'Login', N'Usuario', 98765432, N'mmZoy4redVpKYf6OKGkuc79ecKrcNldPryr7AOzFWow=')
INSERT [dbo].[Evento] ([IdEvento], [Login], [Criticidad], [Fecha], [Hora], [NombreEvento], [Modulo], [DNI], [DVH]) VALUES (646, N'pruebaAdmin', 1, CAST(N'2026-10-04' AS Date), CAST(N'19:45:04.3007915' AS Time), N'Cambiar Clave', N'Usuario', 98765432, N'Nzij50Dq7VkCTywAny3HOer8CJUpdfM9bAny3vQusdc=')
INSERT [dbo].[Evento] ([IdEvento], [Login], [Criticidad], [Fecha], [Hora], [NombreEvento], [Modulo], [DNI], [DVH]) VALUES (647, N'pruebaAdmin', 1, CAST(N'2026-10-04' AS Date), CAST(N'19:45:05.4683653' AS Time), N'Logout', N'Usuario', 98765432, N'0wypOil18DOYMnUMzvdqKHaXjdQdLPODEkgaBC4BjPs=')
INSERT [dbo].[Evento] ([IdEvento], [Login], [Criticidad], [Fecha], [Hora], [NombreEvento], [Modulo], [DNI], [DVH]) VALUES (648, N'pruebaAdmin', 1, CAST(N'2026-10-04' AS Date), CAST(N'19:45:13.7428568' AS Time), N'Login', N'Usuario', 98765432, N'XcStvpqGgfGEtap5+tlzLXpcE72WoyNXSJ0g4TgVKeM=')
INSERT [dbo].[Evento] ([IdEvento], [Login], [Criticidad], [Fecha], [Hora], [NombreEvento], [Modulo], [DNI], [DVH]) VALUES (649, N'pruebaAdmin', 1, CAST(N'2026-10-04' AS Date), CAST(N'20:00:44.2069489' AS Time), N'Login', N'Usuario', 98765432, N'KN4T0+NzxUxmfhs2K2wdi4KgEYOKNcb4eKi/dZOcnlE=')
INSERT [dbo].[Evento] ([IdEvento], [Login], [Criticidad], [Fecha], [Hora], [NombreEvento], [Modulo], [DNI], [DVH]) VALUES (650, N'pruebaAdmin', 1, CAST(N'2026-10-04' AS Date), CAST(N'20:01:06.7636116' AS Time), N'Cambio de Idioma', N'Idioma cambiado con éxito', 98765432, N'LRu8JjHpkaoDRP/Naff1sQ/FjWL0L2oGDeKQ1qpFgMU=')
INSERT [dbo].[Evento] ([IdEvento], [Login], [Criticidad], [Fecha], [Hora], [NombreEvento], [Modulo], [DNI], [DVH]) VALUES (651, N'pruebaAdmin', 1, CAST(N'2026-10-04' AS Date), CAST(N'20:01:09.6557937' AS Time), N'Logout', N'Usuario', 98765432, N'ZZq/eTWJLLtrs5wioZK9QrVQ7k0rIs4uIYj+meq47bw=')
INSERT [dbo].[Evento] ([IdEvento], [Login], [Criticidad], [Fecha], [Hora], [NombreEvento], [Modulo], [DNI], [DVH]) VALUES (652, N'pruebaAdmin', 1, CAST(N'2026-10-24' AS Date), CAST(N'15:53:14.6934836' AS Time), N'Login', N'Usuario', 98765432, N'+bA3nBskVMcLKhebI/kxBs62INn8acOYIyYZoOw6ujo=')
INSERT [dbo].[Evento] ([IdEvento], [Login], [Criticidad], [Fecha], [Hora], [NombreEvento], [Modulo], [DNI], [DVH]) VALUES (653, N'vicky', 1, CAST(N'2026-10-24' AS Date), CAST(N'19:20:12.3680905' AS Time), N'Login', N'Usuario', 12345678, N'9DgPy5EKEv+dMLHk3VFVRB2idmXJvpgsgBXSoeut2tU=')
INSERT [dbo].[Evento] ([IdEvento], [Login], [Criticidad], [Fecha], [Hora], [NombreEvento], [Modulo], [DNI], [DVH]) VALUES (654, N'vicky', 1, CAST(N'2026-10-24' AS Date), CAST(N'19:20:46.8063438' AS Time), N'Logout', N'Usuario', 12345678, N'oz2s5skIZNxbsXtDiZvl1QryNj1TGUrhN1c0zX9QUcE=')
INSERT [dbo].[Evento] ([IdEvento], [Login], [Criticidad], [Fecha], [Hora], [NombreEvento], [Modulo], [DNI], [DVH]) VALUES (655, N'pruebaAdmin', 1, CAST(N'2026-10-24' AS Date), CAST(N'19:20:56.9449545' AS Time), N'Login', N'Usuario', 98765432, N'jCQoFW9kaIv8pZWFv/TpEjI7oEvI+/wopwlqveuUq8Q=')
INSERT [dbo].[Evento] ([IdEvento], [Login], [Criticidad], [Fecha], [Hora], [NombreEvento], [Modulo], [DNI], [DVH]) VALUES (656, N'pruebaAdmin', 1, CAST(N'2026-10-24' AS Date), CAST(N'19:21:18.3866301' AS Time), N'Logout', N'Usuario', 98765432, N'UwUJim5nVO5w/DFe807JZ74L2KLwiErtZkSatx+YUUg=')
INSERT [dbo].[Evento] ([IdEvento], [Login], [Criticidad], [Fecha], [Hora], [NombreEvento], [Modulo], [DNI], [DVH]) VALUES (657, N'vicky', 1, CAST(N'2026-10-24' AS Date), CAST(N'19:35:34.0323120' AS Time), N'Login', N'Usuario', 12345678, N'NUELTNUOtQCkrHN4Rfz5DPSMbuRAe9Ip1JxXBY6tagU=')
INSERT [dbo].[Evento] ([IdEvento], [Login], [Criticidad], [Fecha], [Hora], [NombreEvento], [Modulo], [DNI], [DVH]) VALUES (658, N'vicky', 1, CAST(N'2026-10-24' AS Date), CAST(N'19:36:02.6049416' AS Time), N'Login', N'Usuario', 12345678, N'U/dVggYaCjcktNZWw/+Bevq3LuhgEAzPC3QP1E9rxQ8=')
INSERT [dbo].[Evento] ([IdEvento], [Login], [Criticidad], [Fecha], [Hora], [NombreEvento], [Modulo], [DNI], [DVH]) VALUES (659, N'vicky', 1, CAST(N'2026-10-24' AS Date), CAST(N'19:36:19.3959301' AS Time), N'Logout', N'Usuario', 12345678, N'rKfXAeqwad3qOkwUzsu3BYV2z6WMW6VXj1YTFhvvghA=')
INSERT [dbo].[Evento] ([IdEvento], [Login], [Criticidad], [Fecha], [Hora], [NombreEvento], [Modulo], [DNI], [DVH]) VALUES (660, N'vicky', 1, CAST(N'2026-10-24' AS Date), CAST(N'20:09:05.0389869' AS Time), N'Login', N'Usuario', 12345678, N'7VR1s/nw3LD6P0thPgWhpDvpx0qNoo04NUQ1TRZRfAg=')
INSERT [dbo].[Evento] ([IdEvento], [Login], [Criticidad], [Fecha], [Hora], [NombreEvento], [Modulo], [DNI], [DVH]) VALUES (661, N'vicky', 2, CAST(N'2026-10-24' AS Date), CAST(N'20:10:03.4961954' AS Time), N'Crear Libro', N'Libro', 12345678, N'YaElzIYjRAwi8absYAmu+30ExxnrxrActQWs5I0CwMo=')
INSERT [dbo].[Evento] ([IdEvento], [Login], [Criticidad], [Fecha], [Hora], [NombreEvento], [Modulo], [DNI], [DVH]) VALUES (662, N'vicky', 1, CAST(N'2026-10-24' AS Date), CAST(N'20:11:36.2576705' AS Time), N'Login', N'Usuario', 12345678, N'PO++VWa0OMGEH8L5TE9e4yAjpoNUF4VbkTfMb0lOTRI=')
INSERT [dbo].[Evento] ([IdEvento], [Login], [Criticidad], [Fecha], [Hora], [NombreEvento], [Modulo], [DNI], [DVH]) VALUES (663, N'vicky', 1, CAST(N'2026-10-24' AS Date), CAST(N'20:12:52.0081998' AS Time), N'Login', N'Usuario', 12345678, N'PhAe+D/kUt4GiFIkqE/iNN+XC7oAWHFOebr3f7as7M0=')
INSERT [dbo].[Evento] ([IdEvento], [Login], [Criticidad], [Fecha], [Hora], [NombreEvento], [Modulo], [DNI], [DVH]) VALUES (664, N'vicky', 1, CAST(N'2026-10-24' AS Date), CAST(N'20:13:41.7468250' AS Time), N'Login', N'Usuario', 12345678, N'zd/6FVkygYqIYeEeoYl4N1kAUHxPPWHtGaVGagXN194=')
INSERT [dbo].[Evento] ([IdEvento], [Login], [Criticidad], [Fecha], [Hora], [NombreEvento], [Modulo], [DNI], [DVH]) VALUES (665, N'vicky', 1, CAST(N'2026-10-24' AS Date), CAST(N'20:32:01.5609862' AS Time), N'Login', N'Usuario', 12345678, N'VWvaX2Jq2+7D+BpjLZ5VSn5+gYRYPAEezxwRnVFOjRk=')
INSERT [dbo].[Evento] ([IdEvento], [Login], [Criticidad], [Fecha], [Hora], [NombreEvento], [Modulo], [DNI], [DVH]) VALUES (666, N'vicky', 1, CAST(N'2026-10-24' AS Date), CAST(N'20:34:41.1472751' AS Time), N'Login', N'Usuario', 12345678, N'cc0ospg9URTYcrph30D5wbPU0HK2YacOK5vAUn+CEMM=')
INSERT [dbo].[Evento] ([IdEvento], [Login], [Criticidad], [Fecha], [Hora], [NombreEvento], [Modulo], [DNI], [DVH]) VALUES (667, N'vicky', 1, CAST(N'2026-10-24' AS Date), CAST(N'21:34:50.8131092' AS Time), N'Login', N'Usuario', 12345678, N'nfYBvvp4qZNwyv1Sd1/Ul4d/d0rpkTObkeOier/r5+A=')
INSERT [dbo].[Evento] ([IdEvento], [Login], [Criticidad], [Fecha], [Hora], [NombreEvento], [Modulo], [DNI], [DVH]) VALUES (668, N'vicky', 2, CAST(N'2026-10-24' AS Date), CAST(N'21:36:32.0361302' AS Time), N'Crear Libro', N'Libro', 12345678, N'cDjPAM+lxIzU6ul3B5LmfzNQjj6ct7goWqtvOCF8nWU=')
INSERT [dbo].[Evento] ([IdEvento], [Login], [Criticidad], [Fecha], [Hora], [NombreEvento], [Modulo], [DNI], [DVH]) VALUES (669, N'vicky', 2, CAST(N'2026-10-24' AS Date), CAST(N'21:36:57.4027990' AS Time), N'Modificar Libro', N'Libro', 12345678, N'60iRiF4K0TYLQhBDz7niRNuLGqaSK8X4w92RcxzKf6w=')
INSERT [dbo].[Evento] ([IdEvento], [Login], [Criticidad], [Fecha], [Hora], [NombreEvento], [Modulo], [DNI], [DVH]) VALUES (670, N'vicky', 2, CAST(N'2026-10-24' AS Date), CAST(N'21:37:13.1054478' AS Time), N'Modificar Libro', N'Libro', 12345678, N'173Yby8DOPQApOr10BUStAxz/5B1HFR2XnbSVG6CqJ8=')
INSERT [dbo].[Evento] ([IdEvento], [Login], [Criticidad], [Fecha], [Hora], [NombreEvento], [Modulo], [DNI], [DVH]) VALUES (671, N'vicky', 2, CAST(N'2026-10-24' AS Date), CAST(N'21:38:52.4149469' AS Time), N'Habilitar Venta de Libro', N'Libro', 12345678, N'1as1EzjeDjNoLfU644lbj82iLz1slVz6KMqP6AGoCOw=')
INSERT [dbo].[Evento] ([IdEvento], [Login], [Criticidad], [Fecha], [Hora], [NombreEvento], [Modulo], [DNI], [DVH]) VALUES (672, N'vicky', 2, CAST(N'2026-10-24' AS Date), CAST(N'21:40:31.4376601' AS Time), N'Crear Libro', N'Libro', 12345678, N'ok1gP/evmDGlNDU908dTNDpkOyLelX+0+AWnUXpFDEM=')
INSERT [dbo].[Evento] ([IdEvento], [Login], [Criticidad], [Fecha], [Hora], [NombreEvento], [Modulo], [DNI], [DVH]) VALUES (673, N'vicky', 2, CAST(N'2026-10-24' AS Date), CAST(N'21:40:38.4388013' AS Time), N'Modificar Libro', N'Libro', 12345678, N'/gkCIDL4cCyiUedr2Jlq1II0uvtykkCPh0lRMk7EpPc=')
INSERT [dbo].[Evento] ([IdEvento], [Login], [Criticidad], [Fecha], [Hora], [NombreEvento], [Modulo], [DNI], [DVH]) VALUES (674, N'vicky', 2, CAST(N'2026-10-24' AS Date), CAST(N'21:40:45.2532235' AS Time), N'Desactivar Libro', N'Libro', 12345678, N'Fw75bXWO2zcbpnU4pk0comtqx3GvfD0iDa271C3i6RA=')
INSERT [dbo].[Evento] ([IdEvento], [Login], [Criticidad], [Fecha], [Hora], [NombreEvento], [Modulo], [DNI], [DVH]) VALUES (675, N'vicky', 2, CAST(N'2026-10-24' AS Date), CAST(N'21:40:49.1549674' AS Time), N'Activar Libro', N'Libro', 12345678, N'MHZE9ACJKheGxdU9o93LU9hNlLkCJ7t1ZS+xPCJl/qY=')
INSERT [dbo].[Evento] ([IdEvento], [Login], [Criticidad], [Fecha], [Hora], [NombreEvento], [Modulo], [DNI], [DVH]) VALUES (676, N'vicky', 2, CAST(N'2026-10-24' AS Date), CAST(N'21:41:20.7674916' AS Time), N'Modificar Libro', N'Libro', 12345678, N'TJLZ0TICRg7SVrZ9TmAom2rryFpPg6bIXofGZXqBkQM=')
INSERT [dbo].[Evento] ([IdEvento], [Login], [Criticidad], [Fecha], [Hora], [NombreEvento], [Modulo], [DNI], [DVH]) VALUES (677, N'vicky', 2, CAST(N'2026-10-24' AS Date), CAST(N'21:43:06.8624234' AS Time), N'Modificar Libro', N'Libro', 12345678, N'WE8i/+7/+XFMcWBPcfeRAk9jvFqbUPqNe9sbIvLok3A=')
INSERT [dbo].[Evento] ([IdEvento], [Login], [Criticidad], [Fecha], [Hora], [NombreEvento], [Modulo], [DNI], [DVH]) VALUES (678, N'vicky', 1, CAST(N'2026-10-24' AS Date), CAST(N'21:43:06.8699759' AS Time), N'Préstamo cobrado y activado. ID: 1, Factura: FC-P-', N'Préstamo', 12345678, N'zL03FmDXSnZX9PdEnGvSYcn5xcvyZge3qWEE7ZKGPVk=')
INSERT [dbo].[Evento] ([IdEvento], [Login], [Criticidad], [Fecha], [Hora], [NombreEvento], [Modulo], [DNI], [DVH]) VALUES (679, N'vicky', 1, CAST(N'2026-10-24' AS Date), CAST(N'22:34:35.4347558' AS Time), N'Login', N'Usuario', 12345678, N'7Ul2InTFvcmMlOZxUxPs28YAZvrODBmHhkizQ6/nemY=')
INSERT [dbo].[Evento] ([IdEvento], [Login], [Criticidad], [Fecha], [Hora], [NombreEvento], [Modulo], [DNI], [DVH]) VALUES (680, N'vicky', 2, CAST(N'2026-10-24' AS Date), CAST(N'22:34:54.5547718' AS Time), N'Modificar Libro', N'Libro', 12345678, N'yG0qliBKyJbSL9i/MjWTwYOpOx/eTVLuYeki0Rac3qg=')
INSERT [dbo].[Evento] ([IdEvento], [Login], [Criticidad], [Fecha], [Hora], [NombreEvento], [Modulo], [DNI], [DVH]) VALUES (681, N'vicky', 2, CAST(N'2026-10-24' AS Date), CAST(N'22:35:14.3045677' AS Time), N'Modificar Libro', N'Libro', 12345678, N'zxdsK5C3ZKZn5w7aWyb2J8H8PoM1eIhWsv8INOmsYTo=')
INSERT [dbo].[Evento] ([IdEvento], [Login], [Criticidad], [Fecha], [Hora], [NombreEvento], [Modulo], [DNI], [DVH]) VALUES (682, N'vicky', 2, CAST(N'2026-10-24' AS Date), CAST(N'22:35:58.7439490' AS Time), N'Modificar Libro', N'Libro', 12345678, N'ZkIHOqJTuS8NqZSwDvh4M4opgGcH+CAQXupkTSAMQOE=')
INSERT [dbo].[Evento] ([IdEvento], [Login], [Criticidad], [Fecha], [Hora], [NombreEvento], [Modulo], [DNI], [DVH]) VALUES (683, N'vicky', 2, CAST(N'2026-10-24' AS Date), CAST(N'22:37:14.5220786' AS Time), N'Modificar Libro', N'Libro', 12345678, N'orzaEMM0lFU3b6oFH/KejJlx2UymkeEjNWO739Wp5Rk=')
INSERT [dbo].[Evento] ([IdEvento], [Login], [Criticidad], [Fecha], [Hora], [NombreEvento], [Modulo], [DNI], [DVH]) VALUES (684, N'vicky', 2, CAST(N'2026-10-24' AS Date), CAST(N'22:37:20.6029436' AS Time), N'Modificar Libro', N'Libro', 12345678, N'uUveZW+fwHPbX8mNhDsAJL4C9XLx8KEIgUwesLB/ZuI=')
INSERT [dbo].[Evento] ([IdEvento], [Login], [Criticidad], [Fecha], [Hora], [NombreEvento], [Modulo], [DNI], [DVH]) VALUES (685, N'vicky', 2, CAST(N'2026-10-24' AS Date), CAST(N'22:38:15.0676213' AS Time), N'Modificar Libro', N'Libro', 12345678, N'OTsPeqO+yPugj5uM8OZbKIWQWa6cMt2OvI8gsXQP8fg=')
INSERT [dbo].[Evento] ([IdEvento], [Login], [Criticidad], [Fecha], [Hora], [NombreEvento], [Modulo], [DNI], [DVH]) VALUES (686, N'vicky', 1, CAST(N'2026-10-24' AS Date), CAST(N'22:38:15.0794550' AS Time), N'Préstamo cobrado y activado. ID: 2, Factura: FC-P-', N'Préstamo', 12345678, N'MORX+MK2rrdfdwXJ7TfxDyO/3lvPkC1oERT38wBnQ9M=')
INSERT [dbo].[Evento] ([IdEvento], [Login], [Criticidad], [Fecha], [Hora], [NombreEvento], [Modulo], [DNI], [DVH]) VALUES (687, N'vicky', 1, CAST(N'2026-10-24' AS Date), CAST(N'22:38:20.6828229' AS Time), N'Logout', N'Usuario', 12345678, N'/yH4GP92e4+qB3m4nJLOnD5r4UZ3n7Idv3ohdkf7lFw=')
INSERT [dbo].[Evento] ([IdEvento], [Login], [Criticidad], [Fecha], [Hora], [NombreEvento], [Modulo], [DNI], [DVH]) VALUES (688, N'sofigesualdo', 1, CAST(N'2026-10-24' AS Date), CAST(N'22:40:55.4095392' AS Time), N'Login', N'Usuario', 46956657, N'XosSVY+xxgLBQC8oZXdAWcsCNa7ZnnERpYT9NQPb1dQ=')
INSERT [dbo].[Evento] ([IdEvento], [Login], [Criticidad], [Fecha], [Hora], [NombreEvento], [Modulo], [DNI], [DVH]) VALUES (689, N'sofigesualdo', 1, CAST(N'2026-10-24' AS Date), CAST(N'22:43:21.2172810' AS Time), N'Login', N'Usuario', 46956657, N'3Cs7o4+CV56gifIVU6gVL3bY2k7mgU3arHNUXbY2QhE=')
INSERT [dbo].[Evento] ([IdEvento], [Login], [Criticidad], [Fecha], [Hora], [NombreEvento], [Modulo], [DNI], [DVH]) VALUES (690, N'sofigesualdo', 2, CAST(N'2026-10-24' AS Date), CAST(N'22:43:52.6377435' AS Time), N'Modificar Libro', N'Libro', 46956657, N'PSdVY92J1q+dZSL5UKCakcl35Vhlow9+PLNtk7LbOts=')
INSERT [dbo].[Evento] ([IdEvento], [Login], [Criticidad], [Fecha], [Hora], [NombreEvento], [Modulo], [DNI], [DVH]) VALUES (691, N'sofigesualdo', 1, CAST(N'2026-10-24' AS Date), CAST(N'22:43:52.6822920' AS Time), N'Venta realizada. Factura: FC-B-2026-8303', N'Venta', 46956657, N'xdNOKtrcS7fz7GxGBiw5dgonik3JxLqKqQtUN3EbsTI=')
INSERT [dbo].[Evento] ([IdEvento], [Login], [Criticidad], [Fecha], [Hora], [NombreEvento], [Modulo], [DNI], [DVH]) VALUES (693, N'vicky', 2, CAST(N'2026-10-24' AS Date), CAST(N'22:50:50.2934311' AS Time), N'Modificar Libro', N'Libro', 12345678, N'WevwtOEIIXpkUV2xcIi+cVvrZp0heE9XSMCCDR5t2uQ=')
INSERT [dbo].[Evento] ([IdEvento], [Login], [Criticidad], [Fecha], [Hora], [NombreEvento], [Modulo], [DNI], [DVH]) VALUES (694, N'vicky', 2, CAST(N'2026-10-24' AS Date), CAST(N'22:50:50.3853006' AS Time), N'Modificar Libro', N'Libro', 12345678, N'XEWMIVzb8ap3Y8SPsh6C+dXiq4aGKUsw/FWc+2rJtRo=')
INSERT [dbo].[Evento] ([IdEvento], [Login], [Criticidad], [Fecha], [Hora], [NombreEvento], [Modulo], [DNI], [DVH]) VALUES (695, N'vicky', 1, CAST(N'2026-10-24' AS Date), CAST(N'22:50:50.4016630' AS Time), N'Devolución de préstamo registrada. ID: 3, Estado: ', N'Préstamo', 12345678, N'RpxW2MmWovXniS6E7OhozZIlYqTkTpj9mERx3ME5PRE=')
INSERT [dbo].[Evento] ([IdEvento], [Login], [Criticidad], [Fecha], [Hora], [NombreEvento], [Modulo], [DNI], [DVH]) VALUES (696, N'vicky', 2, CAST(N'2026-10-24' AS Date), CAST(N'22:50:50.4986877' AS Time), N'Modificar Libro', N'Libro', 12345678, N'DHVMPrqUvnKrCIFRkVZ2rsK3nY3sVLLrA4ovwHQ1Iqo=')
INSERT [dbo].[Evento] ([IdEvento], [Login], [Criticidad], [Fecha], [Hora], [NombreEvento], [Modulo], [DNI], [DVH]) VALUES (697, N'vicky', 1, CAST(N'2026-10-24' AS Date), CAST(N'22:50:50.5395503' AS Time), N'Préstamo cobrado y activado. ID: 4, Factura: FC-P-', N'Préstamo', 12345678, N'xA4b1iMsEnP0ulJG7dSrjRLzjsLxLomwrvojBN9sZAs=')
INSERT [dbo].[Evento] ([IdEvento], [Login], [Criticidad], [Fecha], [Hora], [NombreEvento], [Modulo], [DNI], [DVH]) VALUES (698, N'vicky', 2, CAST(N'2026-10-24' AS Date), CAST(N'23:00:01.8221232' AS Time), N'Modificar Libro', N'Libro', 12345678, N'xDgFga4o7x5lbO4C8Gv5dob9vcYkpR/TQEP1NZVAF2o=')
INSERT [dbo].[Evento] ([IdEvento], [Login], [Criticidad], [Fecha], [Hora], [NombreEvento], [Modulo], [DNI], [DVH]) VALUES (699, N'vicky', 2, CAST(N'2026-10-24' AS Date), CAST(N'23:00:01.9465120' AS Time), N'Modificar Libro', N'Libro', 12345678, N'D30Mh+U2VDzv8WuZb3DPp7euLLxPgmi05igBgSwwGmM=')
INSERT [dbo].[Evento] ([IdEvento], [Login], [Criticidad], [Fecha], [Hora], [NombreEvento], [Modulo], [DNI], [DVH]) VALUES (700, N'vicky', 1, CAST(N'2026-10-24' AS Date), CAST(N'23:00:01.9707333' AS Time), N'Devolución Préstamo ID:4', N'Préstamo', 12345678, N'x3P0ACvKSjs0eTUb8pK/l78NeE3i3b84qX1Cjdm5B6I=')
INSERT [dbo].[Evento] ([IdEvento], [Login], [Criticidad], [Fecha], [Hora], [NombreEvento], [Modulo], [DNI], [DVH]) VALUES (701, N'vicky', 2, CAST(N'2026-10-24' AS Date), CAST(N'23:00:03.6144383' AS Time), N'Modificar Libro', N'Libro', 12345678, N'eEh/hq9PdNmnyZzZIejxsc08n8I8hGQfz6k53lQDbiU=')
INSERT [dbo].[Evento] ([IdEvento], [Login], [Criticidad], [Fecha], [Hora], [NombreEvento], [Modulo], [DNI], [DVH]) VALUES (702, N'vicky', 1, CAST(N'2026-10-24' AS Date), CAST(N'23:00:03.6712440' AS Time), N'Cobro Préstamo ID:5 FC:FC-P-2026-1641', N'Préstamo', 12345678, N'DJi387heRwrumTvuFsacENyKTbrQ+IPKYacLfD2UQwM=')
INSERT [dbo].[Evento] ([IdEvento], [Login], [Criticidad], [Fecha], [Hora], [NombreEvento], [Modulo], [DNI], [DVH]) VALUES (703, N'vicky', 2, CAST(N'2026-10-24' AS Date), CAST(N'23:00:04.1030201' AS Time), N'Modificar Libro', N'Libro', 12345678, N'homO9f/IR/p+8pgpxfu5I0QFz68aI5LiStF+H5Sljbg=')
GO
INSERT [dbo].[Evento] ([IdEvento], [Login], [Criticidad], [Fecha], [Hora], [NombreEvento], [Modulo], [DNI], [DVH]) VALUES (704, N'vicky', 1, CAST(N'2026-10-24' AS Date), CAST(N'23:00:04.1321836' AS Time), N'Devolución Préstamo ID:5', N'Préstamo', 12345678, N'iK466YArIBI7yWXarjUho1wr6w+vaDAF1iUg+A0d3PM=')
INSERT [dbo].[Evento] ([IdEvento], [Login], [Criticidad], [Fecha], [Hora], [NombreEvento], [Modulo], [DNI], [DVH]) VALUES (705, N'sofigesualdo', 1, CAST(N'2026-10-24' AS Date), CAST(N'23:01:47.9188516' AS Time), N'Login', N'Usuario', 46956657, N'8IyH20sKQDRfsWIrFvRwsKlcix/hbvP5aBdoYHQRD3k=')
INSERT [dbo].[Evento] ([IdEvento], [Login], [Criticidad], [Fecha], [Hora], [NombreEvento], [Modulo], [DNI], [DVH]) VALUES (706, N'sofigesualdo', 1, CAST(N'2026-10-24' AS Date), CAST(N'23:03:01.1987032' AS Time), N'Login', N'Usuario', 46956657, N'/kMvoND6il5s+Ik7+DHbOVKBIuGTaACiDhGSA20o6Rg=')
INSERT [dbo].[Evento] ([IdEvento], [Login], [Criticidad], [Fecha], [Hora], [NombreEvento], [Modulo], [DNI], [DVH]) VALUES (707, N'sofigesualdo', 2, CAST(N'2026-10-24' AS Date), CAST(N'23:04:20.5765514' AS Time), N'Modificar Libro', N'Libro', 46956657, N'RQjDP15xhV6LLXReBwMJVfzYV6xz1ZwbFhiDkXnp+SM=')
INSERT [dbo].[Evento] ([IdEvento], [Login], [Criticidad], [Fecha], [Hora], [NombreEvento], [Modulo], [DNI], [DVH]) VALUES (708, N'sofigesualdo', 1, CAST(N'2026-10-24' AS Date), CAST(N'23:04:20.5864542' AS Time), N'Cobro Préstamo ID:6 FC:FC-P-2026-3905', N'Préstamo', 46956657, N'02MF69FrPAJg9NuL2VIH1E7i26Gjwx9DuKD6/teU3N4=')
INSERT [dbo].[Evento] ([IdEvento], [Login], [Criticidad], [Fecha], [Hora], [NombreEvento], [Modulo], [DNI], [DVH]) VALUES (709, N'sofigesualdo', 1, CAST(N'2026-10-24' AS Date), CAST(N'23:04:31.3130986' AS Time), N'Logout', N'Usuario', 46956657, N'KRZWRsLIrXzR4pp7s97h7P/Iw8pvyNWVfpBtnTC77ro=')
INSERT [dbo].[Evento] ([IdEvento], [Login], [Criticidad], [Fecha], [Hora], [NombreEvento], [Modulo], [DNI], [DVH]) VALUES (710, N'vicky', 1, CAST(N'2026-10-24' AS Date), CAST(N'23:04:34.9957379' AS Time), N'Login', N'Usuario', 12345678, N'pu6rbLjrn+7f2flq///pjPYGnpMK8Hjrc3j+TNQcWQI=')
INSERT [dbo].[Evento] ([IdEvento], [Login], [Criticidad], [Fecha], [Hora], [NombreEvento], [Modulo], [DNI], [DVH]) VALUES (711, N'pruebaAdmin', 1, CAST(N'2026-10-24' AS Date), CAST(N'23:05:14.5907970' AS Time), N'Login', N'Usuario', 98765432, N'PsgSNDjSEGAyK4m/gHEShTEPt4PMpYK7ByLZI5tli9E=')
INSERT [dbo].[Evento] ([IdEvento], [Login], [Criticidad], [Fecha], [Hora], [NombreEvento], [Modulo], [DNI], [DVH]) VALUES (712, N'pruebaAdmin', 1, CAST(N'2026-10-24' AS Date), CAST(N'23:05:18.6121786' AS Time), N'Logout', N'Usuario', 98765432, N'SKjIeoTqqknhnjVAzS76WURa8ayyq5cngRerQ06AQFc=')
INSERT [dbo].[Evento] ([IdEvento], [Login], [Criticidad], [Fecha], [Hora], [NombreEvento], [Modulo], [DNI], [DVH]) VALUES (713, N'vicky', 1, CAST(N'2026-10-24' AS Date), CAST(N'23:05:22.4857033' AS Time), N'Login', N'Usuario', 12345678, N'l8rHdBYfWRReLW/qGROZ/MWSPl3stXrM5+a5+SpzkPc=')
INSERT [dbo].[Evento] ([IdEvento], [Login], [Criticidad], [Fecha], [Hora], [NombreEvento], [Modulo], [DNI], [DVH]) VALUES (714, N'vicky', 1, CAST(N'2026-10-24' AS Date), CAST(N'23:05:27.5071944' AS Time), N'Cambio de Idioma', N'Idioma cambiado con éxito', 12345678, N'ViT7JFcFLEoTFTlTFP14lgO95BhccN2TwAIvLBEU/Is=')
INSERT [dbo].[Evento] ([IdEvento], [Login], [Criticidad], [Fecha], [Hora], [NombreEvento], [Modulo], [DNI], [DVH]) VALUES (715, N'vicky', 2, CAST(N'2026-10-24' AS Date), CAST(N'23:06:55.1268549' AS Time), N'Modificar Libro', N'Libro', 12345678, N'AN2FXoBxuh9N7a63sapxgODm3ZVOf+HWkRer9LXwTAc=')
INSERT [dbo].[Evento] ([IdEvento], [Login], [Criticidad], [Fecha], [Hora], [NombreEvento], [Modulo], [DNI], [DVH]) VALUES (716, N'vicky', 1, CAST(N'2026-10-24' AS Date), CAST(N'23:13:00.0033771' AS Time), N'Login', N'Usuario', 12345678, N'kNe4kCo+42VaIWvuyUPnBlFGp33r62lQ4DNW3c7dFBw=')
INSERT [dbo].[Evento] ([IdEvento], [Login], [Criticidad], [Fecha], [Hora], [NombreEvento], [Modulo], [DNI], [DVH]) VALUES (717, N'vicky', 2, CAST(N'2026-10-24' AS Date), CAST(N'23:16:50.1372741' AS Time), N'Modificar Libro', N'Libro', 12345678, N'AY3myVGJiVZknj6D5CONuF9wEIIbniq8pMvwNWlmpNY=')
INSERT [dbo].[Evento] ([IdEvento], [Login], [Criticidad], [Fecha], [Hora], [NombreEvento], [Modulo], [DNI], [DVH]) VALUES (718, N'vicky', 2, CAST(N'2026-10-24' AS Date), CAST(N'23:24:31.0123701' AS Time), N'Modificar Libro', N'Libro', 12345678, N'bkxUPjiHF/jskCapv7Zi08tqibO60UL37VTNM69ALYM=')
INSERT [dbo].[Evento] ([IdEvento], [Login], [Criticidad], [Fecha], [Hora], [NombreEvento], [Modulo], [DNI], [DVH]) VALUES (719, N'vicky', 1, CAST(N'2026-10-24' AS Date), CAST(N'23:37:54.6507727' AS Time), N'Login', N'Usuario', 12345678, N'w7PG0q6lpGNl/OsN/3sN55fh6vPAe0byVBpcu66YPTs=')
INSERT [dbo].[Evento] ([IdEvento], [Login], [Criticidad], [Fecha], [Hora], [NombreEvento], [Modulo], [DNI], [DVH]) VALUES (720, N'vicky', 1, CAST(N'2026-10-24' AS Date), CAST(N'23:46:07.2746773' AS Time), N'Login', N'Usuario', 12345678, N'VltTrE0Kk5mRM8f8LLnf4FOBwpsCg/CaK+HvpVZggdA=')
INSERT [dbo].[Evento] ([IdEvento], [Login], [Criticidad], [Fecha], [Hora], [NombreEvento], [Modulo], [DNI], [DVH]) VALUES (721, N'vicky', 2, CAST(N'2026-10-24' AS Date), CAST(N'23:50:45.1884683' AS Time), N'Modificar Libro', N'Libro', 12345678, N'BcOy7Z0xjO6s7oDPrWlQKmdmcb0+kqa7cgBJo5svQ8Q=')
INSERT [dbo].[Evento] ([IdEvento], [Login], [Criticidad], [Fecha], [Hora], [NombreEvento], [Modulo], [DNI], [DVH]) VALUES (722, N'vicky', 1, CAST(N'2026-10-24' AS Date), CAST(N'23:50:45.2150601' AS Time), N'Cobro Préstamo ID:7 FC:FC-P-2026-5634', N'Préstamo', 12345678, N'oaFbbYg2C9vHxa286nlvxTL3V2bKDRnQkqX/5uliseg=')
INSERT [dbo].[Evento] ([IdEvento], [Login], [Criticidad], [Fecha], [Hora], [NombreEvento], [Modulo], [DNI], [DVH]) VALUES (723, N'vicky', 1, CAST(N'2026-10-25' AS Date), CAST(N'00:31:07.4630562' AS Time), N'Login', N'Usuario', 12345678, N'prmEC/n6sokrYQjCg9/6RcIbe9TabHADe/4av7Rh7NM=')
INSERT [dbo].[Evento] ([IdEvento], [Login], [Criticidad], [Fecha], [Hora], [NombreEvento], [Modulo], [DNI], [DVH]) VALUES (724, N'vicky', 1, CAST(N'2026-10-25' AS Date), CAST(N'00:31:32.3176466' AS Time), N'Creación de backup', N'Respaldos', 12345678, N'k6NKvpmkDGNcYvuCNWxmBvh0MpauWBGZTi/0pCcJRWg=')
INSERT [dbo].[Evento] ([IdEvento], [Login], [Criticidad], [Fecha], [Hora], [NombreEvento], [Modulo], [DNI], [DVH]) VALUES (725, N'vicky', 2, CAST(N'2026-10-25' AS Date), CAST(N'21:07:41.1894029' AS Time), N'Modificar Libro', N'Libro', 12345678, N'3qYIPEJ76vYp10l+NTsoLFn8Nmn8ImC1yTh/Htp318Y=')
INSERT [dbo].[Evento] ([IdEvento], [Login], [Criticidad], [Fecha], [Hora], [NombreEvento], [Modulo], [DNI], [DVH]) VALUES (726, N'vicky', 1, CAST(N'2026-10-25' AS Date), CAST(N'21:07:41.6286007' AS Time), N'Devolución Préstamo ID:7', N'Préstamo', 12345678, N'qVT1+uhsXzzIULb4KK8X7I8095zmn9UPRunLs2PfA30=')
INSERT [dbo].[Evento] ([IdEvento], [Login], [Criticidad], [Fecha], [Hora], [NombreEvento], [Modulo], [DNI], [DVH]) VALUES (727, N'vicky', 1, CAST(N'2026-10-25' AS Date), CAST(N'21:26:11.3170439' AS Time), N'Login', N'Usuario', 12345678, N'nd5hl9Jg6O/9BuO+MbEv1nXXO8PXai31IWx+eZX/Y6s=')
INSERT [dbo].[Evento] ([IdEvento], [Login], [Criticidad], [Fecha], [Hora], [NombreEvento], [Modulo], [DNI], [DVH]) VALUES (728, N'vicky', 2, CAST(N'2026-10-25' AS Date), CAST(N'21:26:32.9815858' AS Time), N'Modificar Libro', N'Libro', 12345678, N'WiIDIk0hf8YxaLS3LeLjMrUKRKqgzOQaMhsPSGBVyRE=')
INSERT [dbo].[Evento] ([IdEvento], [Login], [Criticidad], [Fecha], [Hora], [NombreEvento], [Modulo], [DNI], [DVH]) VALUES (729, N'vicky', 1, CAST(N'2026-10-25' AS Date), CAST(N'21:26:33.3560206' AS Time), N'Devolución Préstamo ID:1', N'Préstamo', 12345678, N'lSZn/KvEtj4TI2hZgyJaSeNcdzh+lQnJvzDWhlbhUXc=')
INSERT [dbo].[Evento] ([IdEvento], [Login], [Criticidad], [Fecha], [Hora], [NombreEvento], [Modulo], [DNI], [DVH]) VALUES (730, N'vicky', 2, CAST(N'2026-10-25' AS Date), CAST(N'21:27:47.6162684' AS Time), N'Modificar Libro', N'Libro', 12345678, N'Wr0oL3osSsqCJXTtwIetZ2M/UMd70bQXq2dsU0P8Jxo=')
INSERT [dbo].[Evento] ([IdEvento], [Login], [Criticidad], [Fecha], [Hora], [NombreEvento], [Modulo], [DNI], [DVH]) VALUES (731, N'vicky', 1, CAST(N'2026-10-25' AS Date), CAST(N'21:27:47.6255872' AS Time), N'Cobro Préstamo ID:8 FC:FC-P-2026-6737', N'Préstamo', 12345678, N'VRqGebti5Ob/Bg9Fpqc6LAK8+U/MKbZMuc71GvTB6zk=')
INSERT [dbo].[Evento] ([IdEvento], [Login], [Criticidad], [Fecha], [Hora], [NombreEvento], [Modulo], [DNI], [DVH]) VALUES (732, N'vicky', 2, CAST(N'2026-10-25' AS Date), CAST(N'23:08:15.7243361' AS Time), N'Modificar Libro', N'Libro', 12345678, N'Ix76MJUlnN7jyLZo8Up+OzRg3OoosDZEC2sMpjpnrOc=')
INSERT [dbo].[Evento] ([IdEvento], [Login], [Criticidad], [Fecha], [Hora], [NombreEvento], [Modulo], [DNI], [DVH]) VALUES (733, N'vicky', 1, CAST(N'2026-10-25' AS Date), CAST(N'23:08:15.7519248' AS Time), N'Devolución Préstamo ID:2', N'Préstamo', 12345678, N'yOp+f6g+rconSDarkEFfrMH6bL6x5c/2ObVMHBFsSe0=')
INSERT [dbo].[Evento] ([IdEvento], [Login], [Criticidad], [Fecha], [Hora], [NombreEvento], [Modulo], [DNI], [DVH]) VALUES (734, N'vicky', 1, CAST(N'2026-10-25' AS Date), CAST(N'23:09:02.9024633' AS Time), N'Cambio de Idioma', N'Idioma cambiado con éxito', 12345678, N'j3pRc8xQA96jTCjP4PJPmRhvpkcHKCWNhA7RwoAQUAI=')
INSERT [dbo].[Evento] ([IdEvento], [Login], [Criticidad], [Fecha], [Hora], [NombreEvento], [Modulo], [DNI], [DVH]) VALUES (735, N'vicky', 1, CAST(N'2026-10-25' AS Date), CAST(N'23:13:40.8310106' AS Time), N'Login', N'Usuario', 12345678, N'8Hp1jAnwp+vVzNfMR+S7XWdv2gudr3fvcg+9OSAZM1o=')
INSERT [dbo].[Evento] ([IdEvento], [Login], [Criticidad], [Fecha], [Hora], [NombreEvento], [Modulo], [DNI], [DVH]) VALUES (736, N'vicky', 1, CAST(N'2026-10-25' AS Date), CAST(N'23:15:36.3781867' AS Time), N'Cambio de Idioma', N'Idioma cambiado con éxito', 12345678, N'mQ9bP07OHl3xq34DKqySrkDQ8+GUYdqZKRBvXRncsJA=')
INSERT [dbo].[Evento] ([IdEvento], [Login], [Criticidad], [Fecha], [Hora], [NombreEvento], [Modulo], [DNI], [DVH]) VALUES (737, N'vicky', 1, CAST(N'2026-10-25' AS Date), CAST(N'23:15:55.9235106' AS Time), N'Cambio de Idioma', N'Idioma cambiado con éxito', 12345678, N'eyiu1V/ljFlWC5WXmqrVJG3Ym8MjKpJi50bBVBwDiW0=')
INSERT [dbo].[Evento] ([IdEvento], [Login], [Criticidad], [Fecha], [Hora], [NombreEvento], [Modulo], [DNI], [DVH]) VALUES (738, N'vicky', 1, CAST(N'2026-10-25' AS Date), CAST(N'23:17:37.8328845' AS Time), N'Login', N'Usuario', 12345678, N'qvbxKv0UsYTPmuxKGUSot67pTFqUMcO3o4DXM3B6sBw=')
INSERT [dbo].[Evento] ([IdEvento], [Login], [Criticidad], [Fecha], [Hora], [NombreEvento], [Modulo], [DNI], [DVH]) VALUES (739, N'vicky', 1, CAST(N'2026-10-25' AS Date), CAST(N'23:32:45.6461971' AS Time), N'Login', N'Usuario', 12345678, N'FQ9WcDsVb+j6merbRg7SJoliohYAh1bdfh8DdokdBxo=')
INSERT [dbo].[Evento] ([IdEvento], [Login], [Criticidad], [Fecha], [Hora], [NombreEvento], [Modulo], [DNI], [DVH]) VALUES (740, N'vicky', 1, CAST(N'2026-10-25' AS Date), CAST(N'23:44:12.2641593' AS Time), N'Login', N'Usuario', 12345678, N'7W6gDKagN7ylZDlzBeiPNQ8xXoc9iofo4xyWZfx4ets=')
INSERT [dbo].[Evento] ([IdEvento], [Login], [Criticidad], [Fecha], [Hora], [NombreEvento], [Modulo], [DNI], [DVH]) VALUES (741, N'vicky', 1, CAST(N'2026-10-25' AS Date), CAST(N'23:45:04.1689087' AS Time), N'Cambio de Idioma', N'Idioma cambiado con éxito', 12345678, N'f6x7Ma9f6gtoojp2SThXKAAAlNBnFergHRVvimF/0qM=')
INSERT [dbo].[Evento] ([IdEvento], [Login], [Criticidad], [Fecha], [Hora], [NombreEvento], [Modulo], [DNI], [DVH]) VALUES (742, N'vicky', 1, CAST(N'2026-10-25' AS Date), CAST(N'23:50:04.7700650' AS Time), N'Login', N'Usuario', 12345678, N'I2UomTd4lsYeWM4SDcMytcl3FzrS+Dc2jLSZtM3LhOs=')
INSERT [dbo].[Evento] ([IdEvento], [Login], [Criticidad], [Fecha], [Hora], [NombreEvento], [Modulo], [DNI], [DVH]) VALUES (743, N'vicky', 1, CAST(N'2026-10-25' AS Date), CAST(N'23:50:17.4823006' AS Time), N'Creación de backup', N'Respaldos', 12345678, N'81cJwXrDgL2VTxjqkGXteTRj+pxNp8w17x92YfYikqU=')
INSERT [dbo].[Evento] ([IdEvento], [Login], [Criticidad], [Fecha], [Hora], [NombreEvento], [Modulo], [DNI], [DVH]) VALUES (745, N'vicky', 2, CAST(N'2026-10-27' AS Date), CAST(N'17:23:35.9829540' AS Time), N'Modificar Libro', N'Libro', 12345678, N'WFi88+GR1jHB6AmN1bVWnlpcAp2J9LG8iKxvaO20Q5M=')
INSERT [dbo].[Evento] ([IdEvento], [Login], [Criticidad], [Fecha], [Hora], [NombreEvento], [Modulo], [DNI], [DVH]) VALUES (746, N'vicky', 2, CAST(N'2026-10-27' AS Date), CAST(N'17:26:35.3516269' AS Time), N'Modificar Libro', N'Libro', 12345678, N'aqKWYpLzxZWMrrpWO78YKOGn52Cr3kSDVdugI26Dh9g=')
INSERT [dbo].[Evento] ([IdEvento], [Login], [Criticidad], [Fecha], [Hora], [NombreEvento], [Modulo], [DNI], [DVH]) VALUES (747, N'vicky', 2, CAST(N'2026-10-27' AS Date), CAST(N'17:26:35.4176703' AS Time), N'Rollback de versión de libro - ISBN: 9879867543298', N'Libro', 12345678, N'TBxAS9k2YkGmoz0PvtX/YAJXzJul+ITuVpQYT/1u8qA=')
INSERT [dbo].[Evento] ([IdEvento], [Login], [Criticidad], [Fecha], [Hora], [NombreEvento], [Modulo], [DNI], [DVH]) VALUES (748, N'vicky', 1, CAST(N'2026-10-27' AS Date), CAST(N'18:41:30.3585098' AS Time), N'Login', N'Usuario', 12345678, N'4ZB2uyhsuu9MOibdGY3UymwSA0COSDRzdVMLfJ91IXQ=')
INSERT [dbo].[Evento] ([IdEvento], [Login], [Criticidad], [Fecha], [Hora], [NombreEvento], [Modulo], [DNI], [DVH]) VALUES (749, N'vicky', 2, CAST(N'2026-10-27' AS Date), CAST(N'18:45:48.3165547' AS Time), N'Modificar Libro', N'Libro', 12345678, N'BHCql+G7CzKPrLQdGSWQPWhRQmE3u+1mULAKeyTMUzg=')
INSERT [dbo].[Evento] ([IdEvento], [Login], [Criticidad], [Fecha], [Hora], [NombreEvento], [Modulo], [DNI], [DVH]) VALUES (750, N'vicky', 1, CAST(N'2026-10-27' AS Date), CAST(N'18:47:33.2822589' AS Time), N'Login', N'Usuario', 12345678, N'el3LNKvJ7IqQhvmEfPaJnSQ4uXamo2WyY8GtnCZxJ64=')
INSERT [dbo].[Evento] ([IdEvento], [Login], [Criticidad], [Fecha], [Hora], [NombreEvento], [Modulo], [DNI], [DVH]) VALUES (751, N'pruebaAdmin', 1, CAST(N'2026-10-27' AS Date), CAST(N'19:17:13.0361776' AS Time), N'Login', N'Usuario', 98765432, N'NllSZdFgBcHxAc0kU2b6PAg2E1OfsIbAmXxeuGcyP+o=')
INSERT [dbo].[Evento] ([IdEvento], [Login], [Criticidad], [Fecha], [Hora], [NombreEvento], [Modulo], [DNI], [DVH]) VALUES (752, N'pruebaAdmin', 1, CAST(N'2026-10-27' AS Date), CAST(N'19:17:20.1079035' AS Time), N'Logout', N'Usuario', 98765432, N'V4Lea53MWEqLI8gbZ2NKXrfV2IFexq3WeDu814QzK7Y=')
INSERT [dbo].[Evento] ([IdEvento], [Login], [Criticidad], [Fecha], [Hora], [NombreEvento], [Modulo], [DNI], [DVH]) VALUES (753, N'vicky', 1, CAST(N'2026-10-27' AS Date), CAST(N'19:17:24.7054339' AS Time), N'Login', N'Usuario', 12345678, N'dr3dOpMyjGi5bow5EBY/6YyKPL2UULvMaTYmsXbpzNU=')
INSERT [dbo].[Evento] ([IdEvento], [Login], [Criticidad], [Fecha], [Hora], [NombreEvento], [Modulo], [DNI], [DVH]) VALUES (754, N'vicky', 2, CAST(N'2026-10-27' AS Date), CAST(N'19:17:33.6542301' AS Time), N'Rollback de versión de libro - ISBN: 9784587653215', N'Libro', 12345678, N'9cC7xhMqhLII1d0hmIR5CDuvQZ+av/TN8t5lEmQ2iyE=')
INSERT [dbo].[Evento] ([IdEvento], [Login], [Criticidad], [Fecha], [Hora], [NombreEvento], [Modulo], [DNI], [DVH]) VALUES (755, N'vicky', 1, CAST(N'2026-10-29' AS Date), CAST(N'18:17:56.2616802' AS Time), N'Login', N'Usuario', 12345678, N'5tsvLEh2DwQr+WIjs1O1w035HhNd6chpo+jEKavqosk=')
INSERT [dbo].[Evento] ([IdEvento], [Login], [Criticidad], [Fecha], [Hora], [NombreEvento], [Modulo], [DNI], [DVH]) VALUES (756, N'vicky', 1, CAST(N'2026-10-29' AS Date), CAST(N'18:18:00.2412085' AS Time), N'Logout', N'Usuario', 12345678, N'7CN7uwulK/hd9qkjtKkCY9/2WBtkw3BzNXgphFuQRMc=')
INSERT [dbo].[Evento] ([IdEvento], [Login], [Criticidad], [Fecha], [Hora], [NombreEvento], [Modulo], [DNI], [DVH]) VALUES (757, N'pruebaAdmin', 1, CAST(N'2026-10-29' AS Date), CAST(N'18:18:05.3099221' AS Time), N'Login', N'Usuario', 98765432, N'VSxfrxk/6d0Opuec6Oants96m0+xkVKbS4x6do8qWiU=')
INSERT [dbo].[Evento] ([IdEvento], [Login], [Criticidad], [Fecha], [Hora], [NombreEvento], [Modulo], [DNI], [DVH]) VALUES (758, N'pruebaAdmin', 1, CAST(N'2026-10-29' AS Date), CAST(N'18:18:08.9456443' AS Time), N'Logout', N'Usuario', 98765432, N'TpePWBcyl94X+h8hNH1o2LjrIDAsnZuuVx4j+k6gKEg=')
INSERT [dbo].[Evento] ([IdEvento], [Login], [Criticidad], [Fecha], [Hora], [NombreEvento], [Modulo], [DNI], [DVH]) VALUES (759, N'vicky', 1, CAST(N'2026-10-29' AS Date), CAST(N'18:18:12.9479190' AS Time), N'Login', N'Usuario', 12345678, N'n76Mm2mWsXsBjCHJzHeOSy+HVFZbOupQBRj52guTwyw=')
INSERT [dbo].[Evento] ([IdEvento], [Login], [Criticidad], [Fecha], [Hora], [NombreEvento], [Modulo], [DNI], [DVH]) VALUES (760, N'vicky', 1, CAST(N'2026-10-29' AS Date), CAST(N'18:49:43.7323359' AS Time), N'Logout', N'Usuario', 12345678, N'5SJ2O9jq8XRn2LBd2VJFd7zcvSaPqSFavTt1kDZI7HM=')
INSERT [dbo].[Evento] ([IdEvento], [Login], [Criticidad], [Fecha], [Hora], [NombreEvento], [Modulo], [DNI], [DVH]) VALUES (761, N'vicky', 1, CAST(N'2026-10-29' AS Date), CAST(N'18:51:30.0081787' AS Time), N'Login', N'Usuario', 12345678, N'dVKCHP+ipAdoBzBzsmHoLmdvDzTfhwMmYIZq9tjL2G0=')
INSERT [dbo].[Evento] ([IdEvento], [Login], [Criticidad], [Fecha], [Hora], [NombreEvento], [Modulo], [DNI], [DVH]) VALUES (762, N'vicky', 1, CAST(N'2026-10-29' AS Date), CAST(N'18:55:08.1355689' AS Time), N'Login', N'Usuario', 12345678, N'xiRGZStSBH9wn343c9zc+OUfcGfXia+J65MZjgtuc68=')
INSERT [dbo].[Evento] ([IdEvento], [Login], [Criticidad], [Fecha], [Hora], [NombreEvento], [Modulo], [DNI], [DVH]) VALUES (763, N'vicky', 1, CAST(N'2026-10-29' AS Date), CAST(N'19:29:21.2868410' AS Time), N'Login', N'Usuario', 12345678, N'ln/n7NYBGp6i1xWqTn/YybkXLjPxyf22uTG2zlHWW/4=')
INSERT [dbo].[Evento] ([IdEvento], [Login], [Criticidad], [Fecha], [Hora], [NombreEvento], [Modulo], [DNI], [DVH]) VALUES (764, N'vicky', 1, CAST(N'2026-10-29' AS Date), CAST(N'19:34:25.6056235' AS Time), N'Login', N'Usuario', 12345678, N'Dpfwphd/IzDhpCqXD3zLCyhZiXX/K5yx+Wc/pfat4OE=')
INSERT [dbo].[Evento] ([IdEvento], [Login], [Criticidad], [Fecha], [Hora], [NombreEvento], [Modulo], [DNI], [DVH]) VALUES (765, N'vicky', 1, CAST(N'2026-10-29' AS Date), CAST(N'19:34:40.1620518' AS Time), N'Creación de backup', N'Respaldos', 12345678, N'F6L8jDAa3sQ/bc5VDkF+/1klzcEsCQUVIHKA2xjScuY=')
INSERT [dbo].[Evento] ([IdEvento], [Login], [Criticidad], [Fecha], [Hora], [NombreEvento], [Modulo], [DNI], [DVH]) VALUES (766, N'vicky', 1, CAST(N'2026-10-29' AS Date), CAST(N'19:35:50.0026900' AS Time), N'Login', N'Usuario', 12345678, N'DlVQgsYRQPKU9IXhyRkxTgvLW3ZaGhWo7/EjGZ45W1o=')
INSERT [dbo].[Evento] ([IdEvento], [Login], [Criticidad], [Fecha], [Hora], [NombreEvento], [Modulo], [DNI], [DVH]) VALUES (767, N'vicky', 1, CAST(N'2026-10-29' AS Date), CAST(N'19:35:55.1772671' AS Time), N'Cambio de Idioma', N'Idioma cambiado con éxito', 12345678, N'Cw3rcCA9D2rrT9y7rX/vYQm9PTQ3WXMdSgndZS4BTd4=')
INSERT [dbo].[Evento] ([IdEvento], [Login], [Criticidad], [Fecha], [Hora], [NombreEvento], [Modulo], [DNI], [DVH]) VALUES (768, N'vicky', 1, CAST(N'2026-10-29' AS Date), CAST(N'22:07:21.1085146' AS Time), N'Login', N'Usuario', 12345678, N'xCOQV0+aZqn1vbkwk4g00859uR4NxxIKIPUOu6/u2XY=')
INSERT [dbo].[Evento] ([IdEvento], [Login], [Criticidad], [Fecha], [Hora], [NombreEvento], [Modulo], [DNI], [DVH]) VALUES (769, N'vicky', 2, CAST(N'2026-10-29' AS Date), CAST(N'22:08:22.8326326' AS Time), N'Modificar Libro', N'Libro', 12345678, N'jwS8agnGu8e4GIvFXPi9ngismmAisllTkrJQL1w5h/0=')
INSERT [dbo].[Evento] ([IdEvento], [Login], [Criticidad], [Fecha], [Hora], [NombreEvento], [Modulo], [DNI], [DVH]) VALUES (770, N'vicky', 1, CAST(N'2026-10-29' AS Date), CAST(N'22:08:23.9879798' AS Time), N'Venta realizada. Factura: FC-V-2026-8647', N'Venta', 12345678, N'YPfmTLblB8LuNWyuJz7agVJB2naBGNiXeaRQRAiikpU=')
INSERT [dbo].[Evento] ([IdEvento], [Login], [Criticidad], [Fecha], [Hora], [NombreEvento], [Modulo], [DNI], [DVH]) VALUES (771, N'vicky', 2, CAST(N'2026-10-29' AS Date), CAST(N'22:10:44.7456405' AS Time), N'Modificar Libro', N'Libro', 12345678, N'i5p4NjnTJJ5rGK7unD260/jQuV300oNU779V/+PIVRg=')
INSERT [dbo].[Evento] ([IdEvento], [Login], [Criticidad], [Fecha], [Hora], [NombreEvento], [Modulo], [DNI], [DVH]) VALUES (772, N'vicky', 1, CAST(N'2026-10-29' AS Date), CAST(N'22:10:44.7960891' AS Time), N'Devolución Préstamo ID:6', N'Préstamo', 12345678, N's0mBUFutB5u+i30VCSCNDof+UUMxiukjuwZDgQXC4hY=')
INSERT [dbo].[Evento] ([IdEvento], [Login], [Criticidad], [Fecha], [Hora], [NombreEvento], [Modulo], [DNI], [DVH]) VALUES (773, N'vicky', 2, CAST(N'2026-10-29' AS Date), CAST(N'22:12:12.6870878' AS Time), N'Modificar Libro', N'Libro', 12345678, N'dm4eP1JmohCE1iC9GbfDGu2mw56ahKkoXoyOAozrPv4=')
INSERT [dbo].[Evento] ([IdEvento], [Login], [Criticidad], [Fecha], [Hora], [NombreEvento], [Modulo], [DNI], [DVH]) VALUES (774, N'vicky', 2, CAST(N'2026-10-29' AS Date), CAST(N'22:12:19.4495838' AS Time), N'Modificar Libro', N'Libro', 12345678, N'/GiV55FwIZZz3iFswp7qC8NCziZ8F8njrm1caypEdlY=')
INSERT [dbo].[Evento] ([IdEvento], [Login], [Criticidad], [Fecha], [Hora], [NombreEvento], [Modulo], [DNI], [DVH]) VALUES (775, N'vicky', 2, CAST(N'2026-10-29' AS Date), CAST(N'22:12:25.1968022' AS Time), N'Modificar Libro', N'Libro', 12345678, N'C1w8w3WPxZvIkAVGNov7T9Dyy8xXJWKtQuVFCjuUqt8=')
INSERT [dbo].[Evento] ([IdEvento], [Login], [Criticidad], [Fecha], [Hora], [NombreEvento], [Modulo], [DNI], [DVH]) VALUES (776, N'vicky', 1, CAST(N'2026-10-29' AS Date), CAST(N'22:14:14.5388010' AS Time), N'Cobro Mora ID:8 FC:FC-R-2026-9874', N'Préstamo', 12345678, N'vURiVXTbJJT94fDh94N3OfU6Ve7ef+HFit7fCNKwqYg=')
INSERT [dbo].[Evento] ([IdEvento], [Login], [Criticidad], [Fecha], [Hora], [NombreEvento], [Modulo], [DNI], [DVH]) VALUES (777, N'vicky', 2, CAST(N'2026-10-29' AS Date), CAST(N'22:14:24.8941654' AS Time), N'Modificar Libro', N'Libro', 12345678, N'8Xa2PRbykcIS3IXDRIowDTXCq3a5aO2SII+gXWwkmP8=')
INSERT [dbo].[Evento] ([IdEvento], [Login], [Criticidad], [Fecha], [Hora], [NombreEvento], [Modulo], [DNI], [DVH]) VALUES (778, N'vicky', 1, CAST(N'2026-10-29' AS Date), CAST(N'22:14:24.9301824' AS Time), N'Devolución Préstamo ID:8', N'Préstamo', 12345678, N'qn0+MQ5SRbrZQEwl/NBT7UQHqOKdMGKAn9KwnllUViU=')
INSERT [dbo].[Evento] ([IdEvento], [Login], [Criticidad], [Fecha], [Hora], [NombreEvento], [Modulo], [DNI], [DVH]) VALUES (779, N'vicky', 1, CAST(N'2026-11-02' AS Date), CAST(N'14:41:02.3354312' AS Time), N'Login', N'Usuario', 12345678, N'/nzR9rr2Yw9hF6/QjFW/ntLYjB31shl4c5Bdjwcz97I=')
INSERT [dbo].[Evento] ([IdEvento], [Login], [Criticidad], [Fecha], [Hora], [NombreEvento], [Modulo], [DNI], [DVH]) VALUES (780, N'vicky', 1, CAST(N'2026-11-02' AS Date), CAST(N'14:42:51.9608193' AS Time), N'Login', N'Usuario', 12345678, N'UD30lWpUyiOa+kSfzf7/xLHqx/B40rcSPzDJ2D7vNNQ=')
INSERT [dbo].[Evento] ([IdEvento], [Login], [Criticidad], [Fecha], [Hora], [NombreEvento], [Modulo], [DNI], [DVH]) VALUES (781, N'vicky', 1, CAST(N'2026-11-13' AS Date), CAST(N'17:01:21.7228027' AS Time), N'Login', N'Usuario', 12345678, N'6aZftCeDcAS8Hzj2xW7Wgwq7qnTPLJVH60fQ2fm8zIQ=')
INSERT [dbo].[Evento] ([IdEvento], [Login], [Criticidad], [Fecha], [Hora], [NombreEvento], [Modulo], [DNI], [DVH]) VALUES (782, N'sofigesualdo', 1, CAST(N'2026-11-13' AS Date), CAST(N'17:19:33.3986858' AS Time), N'Login', N'Usuario', 46956657, N'7GLwpVOa/ne2vox1iS0pLhiMnK3K3TkW/5iu7AdU+Pg=')
INSERT [dbo].[Evento] ([IdEvento], [Login], [Criticidad], [Fecha], [Hora], [NombreEvento], [Modulo], [DNI], [DVH]) VALUES (783, N'sofigesualdo', 1, CAST(N'2026-11-13' AS Date), CAST(N'17:19:52.7913321' AS Time), N'Logout', N'Usuario', 46956657, N'gINbAbAiHPCbPjrzOXcRKYFhCxhd8nRN4dljp0wNsYU=')
INSERT [dbo].[Evento] ([IdEvento], [Login], [Criticidad], [Fecha], [Hora], [NombreEvento], [Modulo], [DNI], [DVH]) VALUES (784, N'vicky', 1, CAST(N'2026-11-13' AS Date), CAST(N'17:19:55.7955619' AS Time), N'Login', N'Usuario', 12345678, N'vERgnmHJfXkLos9fiXfRxYbot3Si9do7AUMvKdXQA8s=')
INSERT [dbo].[Evento] ([IdEvento], [Login], [Criticidad], [Fecha], [Hora], [NombreEvento], [Modulo], [DNI], [DVH]) VALUES (785, N'vicky', 1, CAST(N'2026-11-13' AS Date), CAST(N'17:42:54.2264866' AS Time), N'Login', N'Usuario', 12345678, N'Ou7g4hjkZkOmOl2Zb78Hc2SLCBC7sG/AP/kniDv0/RU=')
INSERT [dbo].[Evento] ([IdEvento], [Login], [Criticidad], [Fecha], [Hora], [NombreEvento], [Modulo], [DNI], [DVH]) VALUES (786, N'vicky', 1, CAST(N'2026-11-13' AS Date), CAST(N'21:13:07.4055255' AS Time), N'Login', N'Usuario', 12345678, N'ggbgArJFnBI/tz/pqAUzwMaT+aBOZEUQZzEt/h7VA3Q=')
INSERT [dbo].[Evento] ([IdEvento], [Login], [Criticidad], [Fecha], [Hora], [NombreEvento], [Modulo], [DNI], [DVH]) VALUES (787, N'vicky', 1, CAST(N'2026-11-13' AS Date), CAST(N'22:04:28.4603342' AS Time), N'Login', N'Usuario', 12345678, N'NRRBJkNobd+HlaNmwAsHHqSry3WvUBxIQvMltQU7l0Q=')
INSERT [dbo].[Evento] ([IdEvento], [Login], [Criticidad], [Fecha], [Hora], [NombreEvento], [Modulo], [DNI], [DVH]) VALUES (788, N'vicky', 1, CAST(N'2026-11-13' AS Date), CAST(N'22:07:26.6368508' AS Time), N'Logout', N'Usuario', 12345678, N'rv4TZLUp4+f9kKm4HHLnXmup8pkYEd3gphBQsM7OAN8=')
SET IDENTITY_INSERT [dbo].[Evento] OFF
GO
SET IDENTITY_INSERT [dbo].[Factura] ON 

INSERT [dbo].[Factura] ([IdFactura], [NumeroFactura], [Fecha], [Hora], [Total], [DNICliente], [DVH]) VALUES (3, N'FC-V-2026-8307', CAST(N'2026-09-11' AS Date), CAST(N'19:50:28.3642685' AS Time), CAST(25000.00 AS Decimal(18, 2)), 46956657, N'tnw6eUpZiEclxqmh3L54fm2o4IfZltqVkPBJ8vZ12zk=')
INSERT [dbo].[Factura] ([IdFactura], [NumeroFactura], [Fecha], [Hora], [Total], [DNICliente], [DVH]) VALUES (4, N'FC-V-2026-7593', CAST(N'2026-09-12' AS Date), CAST(N'14:50:44.6231863' AS Time), CAST(20000.00 AS Decimal(18, 2)), 18118401, N'mHB6ZSeTqrtlCVGI38Pdxms4/Ho9tf5wY2PmlA2uqrA=')
INSERT [dbo].[Factura] ([IdFactura], [NumeroFactura], [Fecha], [Hora], [Total], [DNICliente], [DVH]) VALUES (5, N'FC-P-2026-2339', CAST(N'2026-10-24' AS Date), CAST(N'21:43:06.7687487' AS Time), CAST(2000.00 AS Decimal(18, 2)), 46956657, N'f3stl8x5PwrEUX2Y0KpnaSegc0bZVJ2oOdP4QOCfSHI=')
INSERT [dbo].[Factura] ([IdFactura], [NumeroFactura], [Fecha], [Hora], [Total], [DNICliente], [DVH]) VALUES (6, N'FC-P-2026-8668', CAST(N'2026-10-24' AS Date), CAST(N'22:38:14.9907956' AS Time), CAST(2800.00 AS Decimal(18, 2)), 18118401, N'MWSbftulWA9LVBjFXFG/YtGNKC6t3oHZg/VPA8Ts38M=')
INSERT [dbo].[Factura] ([IdFactura], [NumeroFactura], [Fecha], [Hora], [Total], [DNICliente], [DVH]) VALUES (7, N'FC-V-2026-8303', CAST(N'2026-10-24' AS Date), CAST(N'22:43:52.6551474' AS Time), CAST(20000.00 AS Decimal(18, 2)), 46956657, N'dHsZxjb/mO1sp26FgSZGdNqsjBa4VR6XZ/WNRo5j5fA=')
INSERT [dbo].[Factura] ([IdFactura], [NumeroFactura], [Fecha], [Hora], [Total], [DNICliente], [DVH]) VALUES (8, N'FC-P-2026-6194', CAST(N'2026-10-24' AS Date), CAST(N'22:49:42.3754021' AS Time), CAST(2000.00 AS Decimal(18, 2)), 1234567, N'vmEODYP/orda70Suo/uGt0/vRbUVCNBh5YRpkKAjTaE=')
INSERT [dbo].[Factura] ([IdFactura], [NumeroFactura], [Fecha], [Hora], [Total], [DNICliente], [DVH]) VALUES (9, N'FC-P-2026-3930', CAST(N'2026-10-24' AS Date), CAST(N'22:50:50.4495558' AS Time), CAST(2000.00 AS Decimal(18, 2)), 1234567, N'jBf+/Bxwwmghm3lFwBmnv3kQmPf2xAey7pmCLNhrxp4=')
INSERT [dbo].[Factura] ([IdFactura], [NumeroFactura], [Fecha], [Hora], [Total], [DNICliente], [DVH]) VALUES (10, N'FC-P-2026-1641', CAST(N'2026-10-24' AS Date), CAST(N'23:00:03.2652808' AS Time), CAST(2000.00 AS Decimal(18, 2)), 1234567, N'WCSmlt1O6T/PZL2ci7VOofPodWhVX3LX3fVVuMMq3V0=')
INSERT [dbo].[Factura] ([IdFactura], [NumeroFactura], [Fecha], [Hora], [Total], [DNICliente], [DVH]) VALUES (11, N'FC-P-2026-3905', CAST(N'2026-10-24' AS Date), CAST(N'23:04:20.4692236' AS Time), CAST(7000.00 AS Decimal(18, 2)), 1234567, N'DhqDw7DOgmV5K507yznZYCvilBj3viRC5e/yjUkVG4E=')
INSERT [dbo].[Factura] ([IdFactura], [NumeroFactura], [Fecha], [Hora], [Total], [DNICliente], [DVH]) VALUES (12, N'FC-P-2026-5634', CAST(N'2026-10-24' AS Date), CAST(N'23:50:45.0514222' AS Time), CAST(2000.00 AS Decimal(18, 2)), 11223344, N'BjyZW9bdKWR5z8ZC3+RVxY0+kIa+NSl8wgeLaDHny8c=')
INSERT [dbo].[Factura] ([IdFactura], [NumeroFactura], [Fecha], [Hora], [Total], [DNICliente], [DVH]) VALUES (13, N'FC-P-2026-6737', CAST(N'2026-10-25' AS Date), CAST(N'21:27:47.5461413' AS Time), CAST(400.00 AS Decimal(18, 2)), 46956657, N'A/SqVDmSeaz6gGfiBKrBp6K57O5Hphrpt5aakd/8/1w=')
INSERT [dbo].[Factura] ([IdFactura], [NumeroFactura], [Fecha], [Hora], [Total], [DNICliente], [DVH]) VALUES (14, N'FC-V-2026-8647', CAST(N'2026-10-29' AS Date), CAST(N'22:08:23.3312807' AS Time), CAST(20000.00 AS Decimal(18, 2)), 46956657, N'cEetFUN1c+vSdVlW0sCf7capYwaVa8iDyRQbTwQq7z4=')
INSERT [dbo].[Factura] ([IdFactura], [NumeroFactura], [Fecha], [Hora], [Total], [DNICliente], [DVH]) VALUES (15, N'FC-R-2026-9874', CAST(N'2026-10-29' AS Date), CAST(N'22:14:14.4752716' AS Time), CAST(3000.00 AS Decimal(18, 2)), 46956657, N'dxUMP3mFjARfeQ+H8N6NzozOHVhs/8x3ag446YnIeK8=')
SET IDENTITY_INSERT [dbo].[Factura] OFF
GO
SET IDENTITY_INSERT [dbo].[Familia] ON 

INSERT [dbo].[Familia] ([IdFamilia], [Nombre], [DVH]) VALUES (4, N'FamiliaPrueba4', N'0O32AIqjqNf16dyy4kUlK6spunJ/rXR5VUoWjU90b6A=')
INSERT [dbo].[Familia] ([IdFamilia], [Nombre], [DVH]) VALUES (5, N'fam5', N'CfkWfM2U0cHUDvT5f36QFDfcDzutTXpT+Nf6J6XkEsU=')
INSERT [dbo].[Familia] ([IdFamilia], [Nombre], [DVH]) VALUES (7, N'FAMILAAAAA', N'7fRs9LQiU30+Y8ibssdaLau36uz66yYGhec+Dl2gCqk=')
SET IDENTITY_INSERT [dbo].[Familia] OFF
GO
INSERT [dbo].[Familia_x_Familia] ([IdFamiliaPadre], [IdFamiliaHijo], [DVH]) VALUES (5, 4, N'SsXjjq7L5/SF/zIEXVTXjIfxUS5VIwHMhH0jloE4nVU=')
GO
SET IDENTITY_INSERT [dbo].[Idioma] ON 

INSERT [dbo].[Idioma] ([IdIdioma], [Nombre], [Codigo], [DVH]) VALUES (1, N'Español', N'es', N'iaEI7AjBrLw0habLBGd0kJGLh9uKoApiVbaVkRoF/70=')
INSERT [dbo].[Idioma] ([IdIdioma], [Nombre], [Codigo], [DVH]) VALUES (2, N'English', N'en', N'/mBYCtt8Tp2umViquZ4EjzmbjXb0QzaV5zGr36/xORs=')
SET IDENTITY_INSERT [dbo].[Idioma] OFF
GO
INSERT [dbo].[Libro] ([Título_657SGA], [ISBN_657SGA], [Precio_657SGA], [Existencias_657SGA], [Editorial_657SGA], [Autor_657SGA], [Activo_657SGA], [DVH], [EsParaPrestamo], [ExistenciasPrestamo]) VALUES (N'El lobo estepario', N'9781526369874', CAST(20000 AS Decimal(18, 0)), 13, N'Editorial Bookly', N'Herman Hesse', 1, N'8wYPQLOGr/7KNEj3QMeLSOAOXCjFRqXtw0fujMNy9Tg=', 1, 1)
INSERT [dbo].[Libro] ([Título_657SGA], [ISBN_657SGA], [Precio_657SGA], [Existencias_657SGA], [Editorial_657SGA], [Autor_657SGA], [Activo_657SGA], [DVH], [EsParaPrestamo], [ExistenciasPrestamo]) VALUES (N'La campana de cristal', N'9784587653215', CAST(17000 AS Decimal(18, 0)), 5, N'VR', N'Sylvia Plath', 1, N'ICF3pge/kHrRQ4ar7JGDCmPuGNDfM3z21cMVzpeNOkI=', 1, 1)
INSERT [dbo].[Libro] ([Título_657SGA], [ISBN_657SGA], [Precio_657SGA], [Existencias_657SGA], [Editorial_657SGA], [Autor_657SGA], [Activo_657SGA], [DVH], [EsParaPrestamo], [ExistenciasPrestamo]) VALUES (N'x', N'9789456123789', CAST(0 AS Decimal(18, 0)), 0, N'a', N'a', 0, N'ST8VxZsxyr+1LDEwxAHxNQeGguWM9YmPPmntmP2SMb0=', 1, 1)
INSERT [dbo].[Libro] ([Título_657SGA], [ISBN_657SGA], [Precio_657SGA], [Existencias_657SGA], [Editorial_657SGA], [Autor_657SGA], [Activo_657SGA], [DVH], [EsParaPrestamo], [ExistenciasPrestamo]) VALUES (N'Rebelión en la Granja', N'9789878591341', CAST(25000 AS Decimal(18, 0)), 13, N'Almar', N'George Orwell', 1, N'AXrNjs1Q/MUxQxStRgbXDKEh9K1H/IzI+4caJYyKGt8=', 1, 1)
INSERT [dbo].[Libro] ([Título_657SGA], [ISBN_657SGA], [Precio_657SGA], [Existencias_657SGA], [Editorial_657SGA], [Autor_657SGA], [Activo_657SGA], [DVH], [EsParaPrestamo], [ExistenciasPrestamo]) VALUES (N'1984', N'9789878950341', CAST(20000 AS Decimal(18, 0)), 19, N'Almar', N'George Orwell', 1, N'GUHZ0BqlWDVCiMINRyCTqCYWD32SDZz33WBQlQ9bx6Q=', 1, 1)
INSERT [dbo].[Libro] ([Título_657SGA], [ISBN_657SGA], [Precio_657SGA], [Existencias_657SGA], [Editorial_657SGA], [Autor_657SGA], [Activo_657SGA], [DVH], [EsParaPrestamo], [ExistenciasPrestamo]) VALUES (N'Nosotros en la Luna', N'9879867543298', CAST(35000 AS Decimal(18, 0)), 18, N'Planeta', N'Alice Kellen', 1, N'DjK77i1pmLuirh4Pfv/KwBqVGmVju/aQjC/PUrX76Ng=', 1, 1)
GO
SET IDENTITY_INSERT [dbo].[Libro_C] ON 

INSERT [dbo].[Libro_C] ([IdLibroC], [ISBN], [Titulo], [Precio], [Existencias], [ExistenciasPrestamo], [Editorial], [Autor], [EsParaPrestamo], [Activo], [DVH], [Fecha], [Hora], [Act]) VALUES (1, N'9781526369874', N'El lobo estepario', CAST(20000.00 AS Decimal(18, 2)), 14, 1, N'Editorial Bookly', N'Herman Hesse', 1, 1, N'2uPUuYiDIOpmuW8rGDF/cXN3m9vgy+KvTWmhpA+1nk8=', CAST(N'2026-10-27' AS Date), CAST(N'15:46:55.0533333' AS Time), 0)
INSERT [dbo].[Libro_C] ([IdLibroC], [ISBN], [Titulo], [Precio], [Existencias], [ExistenciasPrestamo], [Editorial], [Autor], [EsParaPrestamo], [Activo], [DVH], [Fecha], [Hora], [Act]) VALUES (2, N'9784587653215', N'La campana de cristal', CAST(17000.00 AS Decimal(18, 2)), 5, 1, N'VR', N'Sylvia Plath', 1, 1, N'ICF3pge/kHrRQ4ar7JGDCmPuGNDfM3z21cMVzpeNOkI=', CAST(N'2026-10-27' AS Date), CAST(N'15:46:55.0533333' AS Time), 0)
INSERT [dbo].[Libro_C] ([IdLibroC], [ISBN], [Titulo], [Precio], [Existencias], [ExistenciasPrestamo], [Editorial], [Autor], [EsParaPrestamo], [Activo], [DVH], [Fecha], [Hora], [Act]) VALUES (3, N'9789456123789', N'x', CAST(0.00 AS Decimal(18, 2)), 0, 1, N'a', N'a', 1, 0, N'ST8VxZsxyr+1LDEwxAHxNQeGguWM9YmPPmntmP2SMb0=', CAST(N'2026-10-27' AS Date), CAST(N'15:46:55.0533333' AS Time), 0)
INSERT [dbo].[Libro_C] ([IdLibroC], [ISBN], [Titulo], [Precio], [Existencias], [ExistenciasPrestamo], [Editorial], [Autor], [EsParaPrestamo], [Activo], [DVH], [Fecha], [Hora], [Act]) VALUES (4, N'9789878591341', N'Rebelión en la Granja', CAST(25000.00 AS Decimal(18, 2)), 13, 0, N'Almar', N'George Orwell', 0, 1, N'TTdrlOZGG17WfnYmUDQ5EgWC05efjOp9kHcgmfbp+/s=', CAST(N'2026-10-27' AS Date), CAST(N'15:46:55.0533333' AS Time), 0)
INSERT [dbo].[Libro_C] ([IdLibroC], [ISBN], [Titulo], [Precio], [Existencias], [ExistenciasPrestamo], [Editorial], [Autor], [EsParaPrestamo], [Activo], [DVH], [Fecha], [Hora], [Act]) VALUES (5, N'9789878950341', N'1984', CAST(20000.00 AS Decimal(18, 2)), 19, 0, N'Almar', N'George Orwell', 0, 1, N'ua44x/oCxFGh/YQM800YQmHyynvOL0jLV8XbMtp0ChI=', CAST(N'2026-10-27' AS Date), CAST(N'15:46:55.0533333' AS Time), 0)
INSERT [dbo].[Libro_C] ([IdLibroC], [ISBN], [Titulo], [Precio], [Existencias], [ExistenciasPrestamo], [Editorial], [Autor], [EsParaPrestamo], [Activo], [DVH], [Fecha], [Hora], [Act]) VALUES (6, N'9879867543298', N'Nosotros en la Luna', CAST(35000.00 AS Decimal(18, 2)), 18, 0, N'Planeta', N'Alice Kellen', 0, 1, N'tSco9AfuKcdUBWdY9y3ZtSaH3xZVGsh8Gehovta4R44=', CAST(N'2026-10-27' AS Date), CAST(N'15:46:55.0533333' AS Time), 0)
INSERT [dbo].[Libro_C] ([IdLibroC], [ISBN], [Titulo], [Precio], [Existencias], [ExistenciasPrestamo], [Editorial], [Autor], [EsParaPrestamo], [Activo], [DVH], [Fecha], [Hora], [Act]) VALUES (18, N'9781526369874', N'El lobo estepario', CAST(20000.00 AS Decimal(18, 2)), 14, 1, N'Editorial Bookly', N'Herman Hesse', 1, 1, N'2uPUuYiDIOpmuW8rGDF/cXN3m9vgy+KvTWmhpA+1nk8=', CAST(N'2026-10-27' AS Date), CAST(N'17:42:35.1300000' AS Time), 0)
INSERT [dbo].[Libro_C] ([IdLibroC], [ISBN], [Titulo], [Precio], [Existencias], [ExistenciasPrestamo], [Editorial], [Autor], [EsParaPrestamo], [Activo], [DVH], [Fecha], [Hora], [Act]) VALUES (19, N'9784587653215', N'La campana de cristal', CAST(17000.00 AS Decimal(18, 2)), 5, 1, N'VR', N'Sylvia Plath', 1, 1, N'ICF3pge/kHrRQ4ar7JGDCmPuGNDfM3z21cMVzpeNOkI=', CAST(N'2026-10-27' AS Date), CAST(N'17:42:35.1300000' AS Time), 0)
INSERT [dbo].[Libro_C] ([IdLibroC], [ISBN], [Titulo], [Precio], [Existencias], [ExistenciasPrestamo], [Editorial], [Autor], [EsParaPrestamo], [Activo], [DVH], [Fecha], [Hora], [Act]) VALUES (20, N'9789456123789', N'x', CAST(0.00 AS Decimal(18, 2)), 0, 1, N'a', N'a', 1, 0, N'ST8VxZsxyr+1LDEwxAHxNQeGguWM9YmPPmntmP2SMb0=', CAST(N'2026-10-27' AS Date), CAST(N'17:42:35.1333333' AS Time), 0)
INSERT [dbo].[Libro_C] ([IdLibroC], [ISBN], [Titulo], [Precio], [Existencias], [ExistenciasPrestamo], [Editorial], [Autor], [EsParaPrestamo], [Activo], [DVH], [Fecha], [Hora], [Act]) VALUES (21, N'9789878591341', N'Rebelión en la Granja', CAST(25000.00 AS Decimal(18, 2)), 13, 0, N'Almar', N'George Orwell', 0, 1, N'TTdrlOZGG17WfnYmUDQ5EgWC05efjOp9kHcgmfbp+/s=', CAST(N'2026-10-27' AS Date), CAST(N'17:42:35.1333333' AS Time), 0)
INSERT [dbo].[Libro_C] ([IdLibroC], [ISBN], [Titulo], [Precio], [Existencias], [ExistenciasPrestamo], [Editorial], [Autor], [EsParaPrestamo], [Activo], [DVH], [Fecha], [Hora], [Act]) VALUES (22, N'9789878950341', N'1984', CAST(20000.00 AS Decimal(18, 2)), 19, 0, N'Almar', N'George Orwell', 0, 1, N'ua44x/oCxFGh/YQM800YQmHyynvOL0jLV8XbMtp0ChI=', CAST(N'2026-10-27' AS Date), CAST(N'17:42:35.1333333' AS Time), 0)
INSERT [dbo].[Libro_C] ([IdLibroC], [ISBN], [Titulo], [Precio], [Existencias], [ExistenciasPrestamo], [Editorial], [Autor], [EsParaPrestamo], [Activo], [DVH], [Fecha], [Hora], [Act]) VALUES (23, N'9879867543298', N'Nosotros en la Luna', CAST(35000.00 AS Decimal(18, 2)), 18, 0, N'Planeta', N'Alice Kellen', 0, 1, N'tSco9AfuKcdUBWdY9y3ZtSaH3xZVGsh8Gehovta4R44=', CAST(N'2026-10-27' AS Date), CAST(N'17:42:35.1366667' AS Time), 0)
INSERT [dbo].[Libro_C] ([IdLibroC], [ISBN], [Titulo], [Precio], [Existencias], [ExistenciasPrestamo], [Editorial], [Autor], [EsParaPrestamo], [Activo], [DVH], [Fecha], [Hora], [Act]) VALUES (24, N'9784587653215', N'La campana de cristal', CAST(24000.00 AS Decimal(18, 2)), 5, 1, N'VR', N'Sylvia Plath', 1, 1, N'Itro/FvhRTKl7zcR7KsKWfORUVinx6VB5acBwFs3TFY=', CAST(N'2026-10-27' AS Date), CAST(N'18:45:48.3100000' AS Time), 0)
INSERT [dbo].[Libro_C] ([IdLibroC], [ISBN], [Titulo], [Precio], [Existencias], [ExistenciasPrestamo], [Editorial], [Autor], [EsParaPrestamo], [Activo], [DVH], [Fecha], [Hora], [Act]) VALUES (25, N'9781526369874', N'El lobo estepario', CAST(20000.00 AS Decimal(18, 2)), 14, 1, N'Editorial Bookly', N'Herman Hesse', 1, 1, N'2uPUuYiDIOpmuW8rGDF/cXN3m9vgy+KvTWmhpA+1nk8=', CAST(N'2026-10-27' AS Date), CAST(N'19:17:33.6400000' AS Time), 0)
INSERT [dbo].[Libro_C] ([IdLibroC], [ISBN], [Titulo], [Precio], [Existencias], [ExistenciasPrestamo], [Editorial], [Autor], [EsParaPrestamo], [Activo], [DVH], [Fecha], [Hora], [Act]) VALUES (26, N'9784587653215', N'La campana de cristal', CAST(17000.00 AS Decimal(18, 2)), 5, 1, N'VR', N'Sylvia Plath', 1, 1, N'ICF3pge/kHrRQ4ar7JGDCmPuGNDfM3z21cMVzpeNOkI=', CAST(N'2026-10-27' AS Date), CAST(N'19:17:33.6466667' AS Time), 0)
INSERT [dbo].[Libro_C] ([IdLibroC], [ISBN], [Titulo], [Precio], [Existencias], [ExistenciasPrestamo], [Editorial], [Autor], [EsParaPrestamo], [Activo], [DVH], [Fecha], [Hora], [Act]) VALUES (27, N'9789456123789', N'x', CAST(0.00 AS Decimal(18, 2)), 0, 1, N'a', N'a', 1, 0, N'ST8VxZsxyr+1LDEwxAHxNQeGguWM9YmPPmntmP2SMb0=', CAST(N'2026-10-27' AS Date), CAST(N'19:17:33.6466667' AS Time), 0)
INSERT [dbo].[Libro_C] ([IdLibroC], [ISBN], [Titulo], [Precio], [Existencias], [ExistenciasPrestamo], [Editorial], [Autor], [EsParaPrestamo], [Activo], [DVH], [Fecha], [Hora], [Act]) VALUES (28, N'9789878591341', N'Rebelión en la Granja', CAST(25000.00 AS Decimal(18, 2)), 13, 0, N'Almar', N'George Orwell', 0, 1, N'TTdrlOZGG17WfnYmUDQ5EgWC05efjOp9kHcgmfbp+/s=', CAST(N'2026-10-27' AS Date), CAST(N'19:17:33.6500000' AS Time), 0)
INSERT [dbo].[Libro_C] ([IdLibroC], [ISBN], [Titulo], [Precio], [Existencias], [ExistenciasPrestamo], [Editorial], [Autor], [EsParaPrestamo], [Activo], [DVH], [Fecha], [Hora], [Act]) VALUES (29, N'9789878950341', N'1984', CAST(20000.00 AS Decimal(18, 2)), 19, 0, N'Almar', N'George Orwell', 0, 1, N'ua44x/oCxFGh/YQM800YQmHyynvOL0jLV8XbMtp0ChI=', CAST(N'2026-10-27' AS Date), CAST(N'19:17:33.6500000' AS Time), 0)
INSERT [dbo].[Libro_C] ([IdLibroC], [ISBN], [Titulo], [Precio], [Existencias], [ExistenciasPrestamo], [Editorial], [Autor], [EsParaPrestamo], [Activo], [DVH], [Fecha], [Hora], [Act]) VALUES (30, N'9879867543298', N'Nosotros en la Luna', CAST(35000.00 AS Decimal(18, 2)), 18, 0, N'Planeta', N'Alice Kellen', 0, 1, N'tSco9AfuKcdUBWdY9y3ZtSaH3xZVGsh8Gehovta4R44=', CAST(N'2026-10-27' AS Date), CAST(N'19:17:33.6500000' AS Time), 0)
INSERT [dbo].[Libro_C] ([IdLibroC], [ISBN], [Titulo], [Precio], [Existencias], [ExistenciasPrestamo], [Editorial], [Autor], [EsParaPrestamo], [Activo], [DVH], [Fecha], [Hora], [Act]) VALUES (31, N'9781526369874', N'El lobo estepario', CAST(20000.00 AS Decimal(18, 2)), 13, 1, N'Editorial Bookly', N'Herman Hesse', 1, 1, N'8wYPQLOGr/7KNEj3QMeLSOAOXCjFRqXtw0fujMNy9Tg=', CAST(N'2026-10-29' AS Date), CAST(N'22:08:22.6966667' AS Time), 0)
INSERT [dbo].[Libro_C] ([IdLibroC], [ISBN], [Titulo], [Precio], [Existencias], [ExistenciasPrestamo], [Editorial], [Autor], [EsParaPrestamo], [Activo], [DVH], [Fecha], [Hora], [Act]) VALUES (32, N'9781526369874', N'El lobo estepario', CAST(20000.00 AS Decimal(18, 2)), 13, 1, N'Editorial Bookly', N'Herman Hesse', 1, 1, N'8wYPQLOGr/7KNEj3QMeLSOAOXCjFRqXtw0fujMNy9Tg=', CAST(N'2026-10-29' AS Date), CAST(N'22:10:44.7333333' AS Time), 0)
INSERT [dbo].[Libro_C] ([IdLibroC], [ISBN], [Titulo], [Precio], [Existencias], [ExistenciasPrestamo], [Editorial], [Autor], [EsParaPrestamo], [Activo], [DVH], [Fecha], [Hora], [Act]) VALUES (33, N'9789878591341', N'Rebelión en la Granja', CAST(25000.00 AS Decimal(18, 2)), 13, 1, N'Almar', N'George Orwell', 1, 1, N'AXrNjs1Q/MUxQxStRgbXDKEh9K1H/IzI+4caJYyKGt8=', CAST(N'2026-10-29' AS Date), CAST(N'22:12:12.6800000' AS Time), 0)
INSERT [dbo].[Libro_C] ([IdLibroC], [ISBN], [Titulo], [Precio], [Existencias], [ExistenciasPrestamo], [Editorial], [Autor], [EsParaPrestamo], [Activo], [DVH], [Fecha], [Hora], [Act]) VALUES (34, N'9789878950341', N'1984', CAST(20000.00 AS Decimal(18, 2)), 19, 1, N'Almar', N'George Orwell', 1, 1, N'GUHZ0BqlWDVCiMINRyCTqCYWD32SDZz33WBQlQ9bx6Q=', CAST(N'2026-10-29' AS Date), CAST(N'22:12:19.4433333' AS Time), 0)
INSERT [dbo].[Libro_C] ([IdLibroC], [ISBN], [Titulo], [Precio], [Existencias], [ExistenciasPrestamo], [Editorial], [Autor], [EsParaPrestamo], [Activo], [DVH], [Fecha], [Hora], [Act]) VALUES (35, N'9879867543298', N'Nosotros en la Luna', CAST(35000.00 AS Decimal(18, 2)), 18, 1, N'Planeta', N'Alice Kellen', 1, 1, N'DjK77i1pmLuirh4Pfv/KwBqVGmVju/aQjC/PUrX76Ng=', CAST(N'2026-10-29' AS Date), CAST(N'22:12:25.1933333' AS Time), 0)
INSERT [dbo].[Libro_C] ([IdLibroC], [ISBN], [Titulo], [Precio], [Existencias], [ExistenciasPrestamo], [Editorial], [Autor], [EsParaPrestamo], [Activo], [DVH], [Fecha], [Hora], [Act]) VALUES (36, N'9784587653215', N'La campana de cristal', CAST(17000.00 AS Decimal(18, 2)), 5, 1, N'VR', N'Sylvia Plath', 1, 1, N'ICF3pge/kHrRQ4ar7JGDCmPuGNDfM3z21cMVzpeNOkI=', CAST(N'2026-10-29' AS Date), CAST(N'22:14:24.8800000' AS Time), 0)
INSERT [dbo].[Libro_C] ([IdLibroC], [ISBN], [Titulo], [Precio], [Existencias], [ExistenciasPrestamo], [Editorial], [Autor], [EsParaPrestamo], [Activo], [DVH], [Fecha], [Hora], [Act]) VALUES (37, N'9781526369874', N'El lobo estepario', CAST(20000.00 AS Decimal(18, 2)), 13, 1, N'Editorial Bookly', N'Herman Hesse', 1, 1, N'8wYPQLOGr/7KNEj3QMeLSOAOXCjFRqXtw0fujMNy9Tg=', CAST(N'2026-11-02' AS Date), CAST(N'14:10:16.3700000' AS Time), 1)
INSERT [dbo].[Libro_C] ([IdLibroC], [ISBN], [Titulo], [Precio], [Existencias], [ExistenciasPrestamo], [Editorial], [Autor], [EsParaPrestamo], [Activo], [DVH], [Fecha], [Hora], [Act]) VALUES (38, N'9784587653215', N'La campana de cristal', CAST(17000.00 AS Decimal(18, 2)), 5, 1, N'VR', N'Sylvia Plath', 1, 1, N'ICF3pge/kHrRQ4ar7JGDCmPuGNDfM3z21cMVzpeNOkI=', CAST(N'2026-11-02' AS Date), CAST(N'14:10:16.3866667' AS Time), 1)
INSERT [dbo].[Libro_C] ([IdLibroC], [ISBN], [Titulo], [Precio], [Existencias], [ExistenciasPrestamo], [Editorial], [Autor], [EsParaPrestamo], [Activo], [DVH], [Fecha], [Hora], [Act]) VALUES (39, N'9789456123789', N'x', CAST(0.00 AS Decimal(18, 2)), 0, 1, N'a', N'a', 1, 0, N'ST8VxZsxyr+1LDEwxAHxNQeGguWM9YmPPmntmP2SMb0=', CAST(N'2026-11-02' AS Date), CAST(N'14:10:16.3866667' AS Time), 1)
INSERT [dbo].[Libro_C] ([IdLibroC], [ISBN], [Titulo], [Precio], [Existencias], [ExistenciasPrestamo], [Editorial], [Autor], [EsParaPrestamo], [Activo], [DVH], [Fecha], [Hora], [Act]) VALUES (40, N'9789878591341', N'Rebelión en la Granja', CAST(25000.00 AS Decimal(18, 2)), 13, 1, N'Almar', N'George Orwell', 1, 1, N'AXrNjs1Q/MUxQxStRgbXDKEh9K1H/IzI+4caJYyKGt8=', CAST(N'2026-11-02' AS Date), CAST(N'14:10:16.3900000' AS Time), 1)
INSERT [dbo].[Libro_C] ([IdLibroC], [ISBN], [Titulo], [Precio], [Existencias], [ExistenciasPrestamo], [Editorial], [Autor], [EsParaPrestamo], [Activo], [DVH], [Fecha], [Hora], [Act]) VALUES (41, N'9789878950341', N'1984', CAST(20000.00 AS Decimal(18, 2)), 19, 1, N'Almar', N'George Orwell', 1, 1, N'GUHZ0BqlWDVCiMINRyCTqCYWD32SDZz33WBQlQ9bx6Q=', CAST(N'2026-11-02' AS Date), CAST(N'14:10:16.3900000' AS Time), 1)
INSERT [dbo].[Libro_C] ([IdLibroC], [ISBN], [Titulo], [Precio], [Existencias], [ExistenciasPrestamo], [Editorial], [Autor], [EsParaPrestamo], [Activo], [DVH], [Fecha], [Hora], [Act]) VALUES (42, N'9879867543298', N'Nosotros en la Luna', CAST(35000.00 AS Decimal(18, 2)), 18, 1, N'Planeta', N'Alice Kellen', 1, 1, N'DjK77i1pmLuirh4Pfv/KwBqVGmVju/aQjC/PUrX76Ng=', CAST(N'2026-11-02' AS Date), CAST(N'14:10:16.3900000' AS Time), 1)
SET IDENTITY_INSERT [dbo].[Libro_C] OFF
GO
SET IDENTITY_INSERT [dbo].[Perfil] ON 

INSERT [dbo].[Perfil] ([IdPerfil], [Nombre], [DVH]) VALUES (1, N'Administrador', N'48oig9IhENybhwmPkw7x/aSx8f1mVnQfvUb41JpxzKE=')
INSERT [dbo].[Perfil] ([IdPerfil], [Nombre], [DVH]) VALUES (2, N'Vendedor', N'YJ0lBotY4ZiotsY4ulzKYS2JA0XNtgGmmBqT9GOnIPk=')
INSERT [dbo].[Perfil] ([IdPerfil], [Nombre], [DVH]) VALUES (8, N'Gerente', N'2jT+XVuRhTL1gnzqGQD+9i2RaQAFRtN156s/vNksdng=')
SET IDENTITY_INSERT [dbo].[Perfil] OFF
GO
INSERT [dbo].[Perfil_x_Permiso] ([IdPerfil], [IdPermiso], [DVH]) VALUES (1, 1, N'8B+J3CmdHyW+/7eDpoxfBBxae593iSxaVKGzzTZM34Q=')
INSERT [dbo].[Perfil_x_Permiso] ([IdPerfil], [IdPermiso], [DVH]) VALUES (1, 2, N'iy/0PaQ/OdCCP4kYnPZduo3DcB2uldpKZdZMdt8ro1U=')
INSERT [dbo].[Perfil_x_Permiso] ([IdPerfil], [IdPermiso], [DVH]) VALUES (1, 3, N'kyM8OUVPjA4i95b0KyfU8chs30FUTXdPruiVEoGYWb8=')
INSERT [dbo].[Perfil_x_Permiso] ([IdPerfil], [IdPermiso], [DVH]) VALUES (1, 4, N'plrDGT3pxwdQaWVt2wodBIJJJKFzXO4D2kPGoBeC9Y0=')
INSERT [dbo].[Perfil_x_Permiso] ([IdPerfil], [IdPermiso], [DVH]) VALUES (1, 5, N'xodXhoKfKrKLRfwscHLF/D17e0MATGBQb7u0xY0FLsU=')
INSERT [dbo].[Perfil_x_Permiso] ([IdPerfil], [IdPermiso], [DVH]) VALUES (1, 6, N'I1plczftS2XN5zLntw90RIFbx8CJotAnG4mW0eMA/K8=')
INSERT [dbo].[Perfil_x_Permiso] ([IdPerfil], [IdPermiso], [DVH]) VALUES (1, 7, N'VpGteh1kckDMG7CdLM13Ac9AYDFUCK4Meyh9jZj53nE=')
INSERT [dbo].[Perfil_x_Permiso] ([IdPerfil], [IdPermiso], [DVH]) VALUES (1, 8, N'LhFzAtaXOgXowA/fzudwC2r0jDMRPBJ1h9HDT1eFWRo=')
INSERT [dbo].[Perfil_x_Permiso] ([IdPerfil], [IdPermiso], [DVH]) VALUES (1, 17, N'BO3vG1q9TiwR4GohzzDYxRRSUFkbDRHoW7y5rxEtmrY=')
INSERT [dbo].[Perfil_x_Permiso] ([IdPerfil], [IdPermiso], [DVH]) VALUES (1, 18, N'+6gqPiOM8f4jFJbKZE0NPx2JGVrH49aEbo9j6w4gknY=')
INSERT [dbo].[Perfil_x_Permiso] ([IdPerfil], [IdPermiso], [DVH]) VALUES (1, 19, N'x9Rqw/zuGaIab1wMINoSKTuf1eO3qvi5WYZKHODzxUk=')
INSERT [dbo].[Perfil_x_Permiso] ([IdPerfil], [IdPermiso], [DVH]) VALUES (1, 20, N'/8gsz8S0XSbsE3k/YCAmHcbSPOYaZpHhNJMuFGZ9jt4=')
INSERT [dbo].[Perfil_x_Permiso] ([IdPerfil], [IdPermiso], [DVH]) VALUES (2, 1, N'hzvD6hX8a+bLheZ9vzjrA/eSY1nzU3gz2KAlYlqrk8M=')
INSERT [dbo].[Perfil_x_Permiso] ([IdPerfil], [IdPermiso], [DVH]) VALUES (2, 2, N'tYrVnUijEeZ5Z/ukrogEIBc8+k8gM8C+pQbb2LFGVyE=')
INSERT [dbo].[Perfil_x_Permiso] ([IdPerfil], [IdPermiso], [DVH]) VALUES (2, 3, N'xRgWMyM8XVOKRfjXEIF8su3Hsx5pICIEiCibm/C5uMg=')
INSERT [dbo].[Perfil_x_Permiso] ([IdPerfil], [IdPermiso], [DVH]) VALUES (2, 9, N'b7KTsCZ3/SLREdhnRVonV56o9igK6a76iIDPw8pSe4c=')
INSERT [dbo].[Perfil_x_Permiso] ([IdPerfil], [IdPermiso], [DVH]) VALUES (2, 10, N'nSdi0TyD/7TczLghLpC88u9DCsIv9qVJTSBxd0brCO8=')
INSERT [dbo].[Perfil_x_Permiso] ([IdPerfil], [IdPermiso], [DVH]) VALUES (2, 11, N'O2+Fi7sgbhYP7Z4QapK6a+Pz0NWt+PlPgsgKU5AmiUE=')
INSERT [dbo].[Perfil_x_Permiso] ([IdPerfil], [IdPermiso], [DVH]) VALUES (2, 12, N'eT1oQBv+CDYC1BbUM/9SbMGsEZvGCL+rM3xlgywVBPE=')
INSERT [dbo].[Perfil_x_Permiso] ([IdPerfil], [IdPermiso], [DVH]) VALUES (2, 17, N'FvlvL1KIJvbxnYw6HyK+XAXM4MCHOxj0zRs8fa1f4RE=')
INSERT [dbo].[Perfil_x_Permiso] ([IdPerfil], [IdPermiso], [DVH]) VALUES (2, 18, N'WNp4WFncrGtdGifSk8Jrp/QNCybTCqUcj/2ajxo+RVE=')
INSERT [dbo].[Perfil_x_Permiso] ([IdPerfil], [IdPermiso], [DVH]) VALUES (2, 19, N'6oXsvX6OoGLa4O6waLQsR3kLnR3virHwy8pJWrAc25E=')
INSERT [dbo].[Perfil_x_Permiso] ([IdPerfil], [IdPermiso], [DVH]) VALUES (2, 21, N'jXsyH1VDjq7fkMFKKwvp7tqEka5SKSSYVI3TlG5vusA=')
INSERT [dbo].[Perfil_x_Permiso] ([IdPerfil], [IdPermiso], [DVH]) VALUES (2, 22, N'+arlyb7tKfDXxw3jGKTzTtTw6xlXnU1gQvmEhbpwFbc=')
INSERT [dbo].[Perfil_x_Permiso] ([IdPerfil], [IdPermiso], [DVH]) VALUES (8, 1, N'Ays2H6UmjkqKUqreA4zHZIJdE6woRGxKi8KNzBLHq9Y=')
INSERT [dbo].[Perfil_x_Permiso] ([IdPerfil], [IdPermiso], [DVH]) VALUES (8, 2, N'Iq9EExFm463MLfh4D5KRHK65seyH3TNIvJt38BybtYs=')
INSERT [dbo].[Perfil_x_Permiso] ([IdPerfil], [IdPermiso], [DVH]) VALUES (8, 3, N'lI9uhCq8SJx2AKNJfamB8N9hmFgQMah8LtJCACGSXjk=')
INSERT [dbo].[Perfil_x_Permiso] ([IdPerfil], [IdPermiso], [DVH]) VALUES (8, 4, N'y91JHSmH96M6NFyRf8wL5Tr6GPsCqOAYl7iiMA94vBM=')
INSERT [dbo].[Perfil_x_Permiso] ([IdPerfil], [IdPermiso], [DVH]) VALUES (8, 5, N'oPyNiQ7EU4moya1ns/qu9FLk/w3dLt/usaQBQGVOpm4=')
INSERT [dbo].[Perfil_x_Permiso] ([IdPerfil], [IdPermiso], [DVH]) VALUES (8, 6, N'MWABiG90Vw0ah/1Dy5Uq9O6bOhxMJ45f98tOJ/kUpOY=')
INSERT [dbo].[Perfil_x_Permiso] ([IdPerfil], [IdPermiso], [DVH]) VALUES (8, 7, N'kK9XY4JnIr8/aUBtUOL9H3IrVB2K0kjbFMb2MOXfRdE=')
INSERT [dbo].[Perfil_x_Permiso] ([IdPerfil], [IdPermiso], [DVH]) VALUES (8, 8, N'WPouC7luyJ6A8WouNBUX/Kgn5O44T5KQRmrXcSEcftY=')
INSERT [dbo].[Perfil_x_Permiso] ([IdPerfil], [IdPermiso], [DVH]) VALUES (8, 9, N'1gu7+J+BuF06vf0fs0ZmmE0BD6A27Pr3apGHveJ4+NA=')
INSERT [dbo].[Perfil_x_Permiso] ([IdPerfil], [IdPermiso], [DVH]) VALUES (8, 10, N'cquWaGyFVUNIVKaJqXhkNGvY2LlcHsjBwVNGmcZ1ivs=')
INSERT [dbo].[Perfil_x_Permiso] ([IdPerfil], [IdPermiso], [DVH]) VALUES (8, 11, N'rCt80nhTc542b5hI0+zyht2UyhUJI7U+3PwA1261Vns=')
INSERT [dbo].[Perfil_x_Permiso] ([IdPerfil], [IdPermiso], [DVH]) VALUES (8, 12, N'VtX+d536tUKL4xSdfFoqkO9nU1yvtSWJ7tHm74haKLU=')
INSERT [dbo].[Perfil_x_Permiso] ([IdPerfil], [IdPermiso], [DVH]) VALUES (8, 17, N'OCwLuWh3DmtdLSOm1rNDhuOVY8L+7J9YbD7px53pl3s=')
INSERT [dbo].[Perfil_x_Permiso] ([IdPerfil], [IdPermiso], [DVH]) VALUES (8, 18, N'81wJUr8iWMp/6c5UcrwGR7QbRD53+7XE7+1Nw081w5M=')
INSERT [dbo].[Perfil_x_Permiso] ([IdPerfil], [IdPermiso], [DVH]) VALUES (8, 19, N'1XF/IrBOiphpK+DL5d36FLPKIoFxRN1Xhe1zR26G+EA=')
INSERT [dbo].[Perfil_x_Permiso] ([IdPerfil], [IdPermiso], [DVH]) VALUES (8, 20, N'0z8kCKEYwAim5hG0pgkvwYQhZcQECcONZK+rH97RnMc=')
INSERT [dbo].[Perfil_x_Permiso] ([IdPerfil], [IdPermiso], [DVH]) VALUES (8, 21, N'KMw/zJPm8OPRCJBYPKor1sLKshBJ1sDMlPnt4xy34mc=')
INSERT [dbo].[Perfil_x_Permiso] ([IdPerfil], [IdPermiso], [DVH]) VALUES (8, 22, N'BslSYQvBTgKlFQ+5ayI+kuRgTQzKTbDdGyzbpZcM+6I=')
INSERT [dbo].[Perfil_x_Permiso] ([IdPerfil], [IdPermiso], [DVH]) VALUES (8, 23, N'JetF/ulwXuufGcYsSiAwMJzIv1gSTtER5loSPcf7SzM=')
INSERT [dbo].[Perfil_x_Permiso] ([IdPerfil], [IdPermiso], [DVH]) VALUES (8, 26, N'zTAVpQUmKN+FfbONn77kLJ4c3AhgH7w2ModkQobR4AU=')
GO
SET IDENTITY_INSERT [dbo].[Permiso] ON 

INSERT [dbo].[Permiso] ([IdPermiso], [Nombre], [DVH]) VALUES (1, N'ReLogin', N'irBxNNspRrkbvEB6EMYF2wqkmeIFtslQdl7nNlDYBUI=')
INSERT [dbo].[Permiso] ([IdPermiso], [Nombre], [DVH]) VALUES (2, N'Cambiar Idioma', N'BIow0XNd76dN2er62e+Jv70bMHnqPlqUdkHBy6yZ0Mc=')
INSERT [dbo].[Permiso] ([IdPermiso], [Nombre], [DVH]) VALUES (3, N'Cambiar Clave', N'bYPRwlr6JtcQLx+Y/5KRN0Zg7HhRBbnXUrXMvvrkgCw=')
INSERT [dbo].[Permiso] ([IdPermiso], [Nombre], [DVH]) VALUES (4, N'Gestionar Usuarios', N'fwix8ZTG84g1sRyqNevrTeDs/PJPKmKXcEWAc3RQoa8=')
INSERT [dbo].[Permiso] ([IdPermiso], [Nombre], [DVH]) VALUES (5, N'Gestionar Perfiles', N'PkfLR9IKrGVAEDdZn0EC3IB4OZSMD8puWY5i9SoZFCY=')
INSERT [dbo].[Permiso] ([IdPermiso], [Nombre], [DVH]) VALUES (6, N'Auditar Bitacora', N'6UOIX3biVLFShSHvQnK6UjymUR6fUy7jYhAY0LStBlw=')
INSERT [dbo].[Permiso] ([IdPermiso], [Nombre], [DVH]) VALUES (7, N'Gestionar Backup', N'AnzboE8G1jytIdNfLjD6sgINwebYf6XsCiUSg4+WC4o=')
INSERT [dbo].[Permiso] ([IdPermiso], [Nombre], [DVH]) VALUES (8, N'Gestionar Restore', N'iAsj3o2HaGwr04IyOGtE1neUAcmTFzmtLnSgNUY7pPg=')
INSERT [dbo].[Permiso] ([IdPermiso], [Nombre], [DVH]) VALUES (9, N'Ver Historial Ventas', N'Mdrq0DVI36VhH1Jc82w5hSqdI1JL0XXiSjLb+Jl6KMQ=')
INSERT [dbo].[Permiso] ([IdPermiso], [Nombre], [DVH]) VALUES (10, N'Registrar Venta', N'+Yw4yCQrGDZwC2czcDHOKyjJyGcswveXVSkOxNpLblk=')
INSERT [dbo].[Permiso] ([IdPermiso], [Nombre], [DVH]) VALUES (11, N'Gestionar Libros', N'4CQWaOHx2N2mCFF4MNxArPAqPpZpEuwDIKx5/sGSXSQ=')
INSERT [dbo].[Permiso] ([IdPermiso], [Nombre], [DVH]) VALUES (12, N'Gestionar Clientes', N'1wLSs7hvNCUh0b9nHjjEiRF5gH7hngfkq/zPZWL6o8I=')
INSERT [dbo].[Permiso] ([IdPermiso], [Nombre], [DVH]) VALUES (17, N'Ver Manual Usuario', N'BWKxaSkjA9W5wmUffTuBNAzjhlW/EIlWybAFJTBidHE=')
INSERT [dbo].[Permiso] ([IdPermiso], [Nombre], [DVH]) VALUES (18, N'Ver Guia Instalacion', N'jND95Cw6d2wQfqPyIgGgwVceX6p6ah/MOCmO06n+HfU=')
INSERT [dbo].[Permiso] ([IdPermiso], [Nombre], [DVH]) VALUES (19, N'Cerrar Sesion', N'cXmLelsuquJYU5smtq80aRH2BChNiEsmjzQXZrce93c=')
INSERT [dbo].[Permiso] ([IdPermiso], [Nombre], [DVH]) VALUES (20, N'Administrar Error', N'jiq/il9siuhQ5w0hcRjSmXNVZ2BML8xw822j/FLzUKg=')
INSERT [dbo].[Permiso] ([IdPermiso], [Nombre], [DVH]) VALUES (21, N'Ver Historial Préstamos', N'3ZayRqPzzyrj3RoAl0nTCUe8h0Cegu5v/qbtpGBNYvM=')
INSERT [dbo].[Permiso] ([IdPermiso], [Nombre], [DVH]) VALUES (22, N'Registrar Préstamo', N'zr4h8wTYc87oYJ8q6f7paP2hpJo31PNS2ExNMmS3iiw=')
INSERT [dbo].[Permiso] ([IdPermiso], [Nombre], [DVH]) VALUES (23, N'Gestionar Libros C', N'l1H3wB4jCWwLHJz86oiPdIaA2F4ZQKVfZ5U5BeKrrl0=')
INSERT [dbo].[Permiso] ([IdPermiso], [Nombre], [DVH]) VALUES (26, N'Reporte Inteligente', N'zTYUaazS3fFDZo7EhiziVx6tuPaqMrnNA1eku/p3p3Q=')
SET IDENTITY_INSERT [dbo].[Permiso] OFF
GO
INSERT [dbo].[Permiso_x_Familia] ([IdFamilia], [IdPermiso], [DVH]) VALUES (4, 2, N'/KYECHwMDzqES59zxY8DdDYhtWN/3q2+Osdlz6aWi/k=')
INSERT [dbo].[Permiso_x_Familia] ([IdFamilia], [IdPermiso], [DVH]) VALUES (4, 3, N'OuzT3oj8Hg9uU7pn/Yt5+svESv8MeaG4yjFAEzwInCU=')
INSERT [dbo].[Permiso_x_Familia] ([IdFamilia], [IdPermiso], [DVH]) VALUES (5, 6, N'u5SSUOh3NYqA4TdrHYhoQp82/jg5fKXmb+AJF/2Crrc=')
INSERT [dbo].[Permiso_x_Familia] ([IdFamilia], [IdPermiso], [DVH]) VALUES (7, 12, N'cTRRJm+lvENxYlddfwPEuCpEcqf6fW6me68EOA1e+dk=')
GO
SET IDENTITY_INSERT [dbo].[Prestamo] ON 

INSERT [dbo].[Prestamo] ([IdPrestamo], [DNI], [ISBN], [IdFactura], [FechaInicio], [FechaDevolucion], [FechaRealDevolucion], [Estado], [MontoPrestamo], [MontoRecargo], [DVH]) VALUES (1, 46956657, N'9784587653215', 5, CAST(N'2026-10-24' AS Date), CAST(N'2026-10-31' AS Date), CAST(N'2026-10-25' AS Date), N'Finalizado', CAST(2000 AS Decimal(18, 0)), CAST(0 AS Decimal(18, 0)), N'fsf4/3YFT4jwEphAkEIdMB91cqCpobZ/+1T9yjeTGag=')
INSERT [dbo].[Prestamo] ([IdPrestamo], [DNI], [ISBN], [IdFactura], [FechaInicio], [FechaDevolucion], [FechaRealDevolucion], [Estado], [MontoPrestamo], [MontoRecargo], [DVH]) VALUES (2, 18118401, N'9784587653215', 6, CAST(N'2026-10-24' AS Date), CAST(N'2026-11-02' AS Date), CAST(N'2026-10-25' AS Date), N'Finalizado', CAST(2800 AS Decimal(18, 0)), CAST(0 AS Decimal(18, 0)), N'PRRX6dHfuxqlTsRO1AvhMd/2r9f1OMTgYQ/iPkvBZtE=')
INSERT [dbo].[Prestamo] ([IdPrestamo], [DNI], [ISBN], [IdFactura], [FechaInicio], [FechaDevolucion], [FechaRealDevolucion], [Estado], [MontoPrestamo], [MontoRecargo], [DVH]) VALUES (3, 1234567, N'9781526369874', 8, CAST(N'2026-10-24' AS Date), CAST(N'2026-10-31' AS Date), CAST(N'2026-10-24' AS Date), N'Finalizado', CAST(2000 AS Decimal(18, 0)), CAST(0 AS Decimal(18, 0)), N'V2JnbL9CJVF7Je0Zni4socvNTL+PGCaNx2Ha2So8FXY=')
INSERT [dbo].[Prestamo] ([IdPrestamo], [DNI], [ISBN], [IdFactura], [FechaInicio], [FechaDevolucion], [FechaRealDevolucion], [Estado], [MontoPrestamo], [MontoRecargo], [DVH]) VALUES (4, 1234567, N'9781526369874', 9, CAST(N'2026-10-24' AS Date), CAST(N'2026-10-31' AS Date), CAST(N'2026-10-24' AS Date), N'Finalizado', CAST(2000 AS Decimal(18, 0)), CAST(0 AS Decimal(18, 0)), N'GognF/uAkaaFApIoTvtrhEln6tMtCHMstrSLvbkiguQ=')
INSERT [dbo].[Prestamo] ([IdPrestamo], [DNI], [ISBN], [IdFactura], [FechaInicio], [FechaDevolucion], [FechaRealDevolucion], [Estado], [MontoPrestamo], [MontoRecargo], [DVH]) VALUES (5, 1234567, N'9781526369874', 10, CAST(N'2026-10-24' AS Date), CAST(N'2026-10-31' AS Date), CAST(N'2026-10-24' AS Date), N'Finalizado', CAST(2000 AS Decimal(18, 0)), CAST(0 AS Decimal(18, 0)), N'GLVO9MhoPmV9G5VxbbzttONWd05848EVKO67vB0NZq0=')
INSERT [dbo].[Prestamo] ([IdPrestamo], [DNI], [ISBN], [IdFactura], [FechaInicio], [FechaDevolucion], [FechaRealDevolucion], [Estado], [MontoPrestamo], [MontoRecargo], [DVH]) VALUES (6, 1234567, N'9781526369874', 11, CAST(N'2026-10-24' AS Date), CAST(N'2026-11-23' AS Date), CAST(N'2026-10-29' AS Date), N'Finalizado', CAST(7000 AS Decimal(18, 0)), CAST(0 AS Decimal(18, 0)), N'B+1+mhKWhlZbV+8Smu+h7+K2K1jWYYZterEUH2VRTRQ=')
INSERT [dbo].[Prestamo] ([IdPrestamo], [DNI], [ISBN], [IdFactura], [FechaInicio], [FechaDevolucion], [FechaRealDevolucion], [Estado], [MontoPrestamo], [MontoRecargo], [DVH]) VALUES (7, 11223344, N'9781526369874', 12, CAST(N'2026-10-24' AS Date), CAST(N'2026-10-31' AS Date), CAST(N'2026-10-25' AS Date), N'Finalizado', CAST(2000 AS Decimal(18, 0)), CAST(0 AS Decimal(18, 0)), N'YDfxgO5gSrQIz/Y16GNZvP3qa/C2sSBg53RaDjenVDg=')
INSERT [dbo].[Prestamo] ([IdPrestamo], [DNI], [ISBN], [IdFactura], [FechaInicio], [FechaDevolucion], [FechaRealDevolucion], [Estado], [MontoPrestamo], [MontoRecargo], [DVH]) VALUES (8, 46956657, N'9784587653215', 13, CAST(N'2026-10-25' AS Date), CAST(N'2026-10-26' AS Date), CAST(N'2026-10-29' AS Date), N'Finalizado con Mora', CAST(400 AS Decimal(18, 0)), CAST(3000 AS Decimal(18, 0)), N'8YUwp7I73lZ1ILNfnPPaYSEbmFCCP/VXIVL2UsztGME=')
SET IDENTITY_INSERT [dbo].[Prestamo] OFF
GO
INSERT [dbo].[Usuario] ([DNI], [Nombre], [Apellido], [NombreUsuario], [Bloqueado], [Activo], [Contraseña], [IntentosInicio], [Email], [IdPerfil], [IdIdioma], [DVH]) VALUES (12345678, N'Victoria', N'Fernandez', N'vicky', 0, 1, N'A665A45920422F9D417E4867EFDC4FB8A04A1F3FFF1FA07E998E86F7F7A27AE3', 0, N'vickyfs@gmail.com', 8, 1, N'YtkXh6i/csbeTyvv9cauB7zciY7yFsXpu6RCLAnPZ3g=')
INSERT [dbo].[Usuario] ([DNI], [Nombre], [Apellido], [NombreUsuario], [Bloqueado], [Activo], [Contraseña], [IntentosInicio], [Email], [IdPerfil], [IdIdioma], [DVH]) VALUES (46956657, N'Sofi', N'Gesualdo', N'sofigesualdo', 0, 1, N'03AC674216F3E15C761EE1A5E255F067953623C8B388B4459E13F978D7C846F4', 0, N'sofigesualdo@hotmail.com', 2, 1, N'Vdz/3EGCqB6x7bMZi3112aMqIq0AH2N1uHOXA6qwz8Y=')
INSERT [dbo].[Usuario] ([DNI], [Nombre], [Apellido], [NombreUsuario], [Bloqueado], [Activo], [Contraseña], [IntentosInicio], [Email], [IdPerfil], [IdIdioma], [DVH]) VALUES (87654321, N'Pepe', N'Argento', N'pepe', 0, 0, N'72B302BF297A228A75730123EFEF7C4140D2BF16CE9FBE7D187515CAD068BBCE', 0, N'pepe@gmail.com', 1, 1, N'M/x23BWTBeQJA+aKbBe2k3kVcB1Td/RJL2jT9ucPAmw=')
INSERT [dbo].[Usuario] ([DNI], [Nombre], [Apellido], [NombreUsuario], [Bloqueado], [Activo], [Contraseña], [IntentosInicio], [Email], [IdPerfil], [IdIdioma], [DVH]) VALUES (98765432, N'Prueba', N'Admin', N'pruebaAdmin', 0, 1, N'5994471ABB01112AFCC18159F6CC74B4F511B99806DA59B3CAF5A9C173CACFC5', 0, N'pa@gmail.com', 1, 2, N'pul0dPNgHSDoE+hYvHNBEpggLSBqe/jveB7aNyQdgGM=')
GO
ALTER TABLE [dbo].[Cliente] ADD  CONSTRAINT [DF_Cliente_Activo]  DEFAULT ((1)) FOR [Activo_657SGA]
GO
ALTER TABLE [dbo].[Libro] ADD  CONSTRAINT [DF_Libro_Activo]  DEFAULT ((1)) FOR [Activo_657SGA]
GO
ALTER TABLE [dbo].[Libro] ADD  CONSTRAINT [DF_Libro_EsParaPrestamo]  DEFAULT ((0)) FOR [EsParaPrestamo]
GO
ALTER TABLE [dbo].[Libro] ADD  DEFAULT ((0)) FOR [ExistenciasPrestamo]
GO
ALTER TABLE [dbo].[Libro_C] ADD  DEFAULT (CONVERT([date],getdate())) FOR [Fecha]
GO
ALTER TABLE [dbo].[Libro_C] ADD  DEFAULT (CONVERT([time],getdate())) FOR [Hora]
GO
ALTER TABLE [dbo].[Libro_C] ADD  DEFAULT ((1)) FOR [Act]
GO
ALTER TABLE [dbo].[Prestamo] ADD  CONSTRAINT [DF_Prestamo_MontoRecargo]  DEFAULT ((0)) FOR [MontoRecargo]
GO
ALTER TABLE [dbo].[DetalleFactura]  WITH CHECK ADD  CONSTRAINT [FK_DetalleFactura_Factura] FOREIGN KEY([IdFactura])
REFERENCES [dbo].[Factura] ([IdFactura])
GO
ALTER TABLE [dbo].[DetalleFactura] CHECK CONSTRAINT [FK_DetalleFactura_Factura]
GO
ALTER TABLE [dbo].[DetalleFactura]  WITH CHECK ADD  CONSTRAINT [FK_DetalleFactura_Libro] FOREIGN KEY([ISBN_657SGA])
REFERENCES [dbo].[Libro] ([ISBN_657SGA])
GO
ALTER TABLE [dbo].[DetalleFactura] CHECK CONSTRAINT [FK_DetalleFactura_Libro]
GO
ALTER TABLE [dbo].[Evento]  WITH CHECK ADD  CONSTRAINT [FK_Evento_Usuario] FOREIGN KEY([DNI])
REFERENCES [dbo].[Usuario] ([DNI])
GO
ALTER TABLE [dbo].[Evento] CHECK CONSTRAINT [FK_Evento_Usuario]
GO
ALTER TABLE [dbo].[Factura]  WITH CHECK ADD  CONSTRAINT [FK_Factura_Cliente] FOREIGN KEY([DNICliente])
REFERENCES [dbo].[Cliente] ([DNI_657SGA])
GO
ALTER TABLE [dbo].[Factura] CHECK CONSTRAINT [FK_Factura_Cliente]
GO
ALTER TABLE [dbo].[Familia_x_Familia]  WITH CHECK ADD  CONSTRAINT [FK_FamiliaFamilia_Hijo] FOREIGN KEY([IdFamiliaHijo])
REFERENCES [dbo].[Familia] ([IdFamilia])
GO
ALTER TABLE [dbo].[Familia_x_Familia] CHECK CONSTRAINT [FK_FamiliaFamilia_Hijo]
GO
ALTER TABLE [dbo].[Familia_x_Familia]  WITH CHECK ADD  CONSTRAINT [FK_FamiliaFamilia_Padre] FOREIGN KEY([IdFamiliaPadre])
REFERENCES [dbo].[Familia] ([IdFamilia])
GO
ALTER TABLE [dbo].[Familia_x_Familia] CHECK CONSTRAINT [FK_FamiliaFamilia_Padre]
GO
ALTER TABLE [dbo].[Libro_C]  WITH CHECK ADD  CONSTRAINT [FK_Libro_C_Libro] FOREIGN KEY([ISBN])
REFERENCES [dbo].[Libro] ([ISBN_657SGA])
GO
ALTER TABLE [dbo].[Libro_C] CHECK CONSTRAINT [FK_Libro_C_Libro]
GO
ALTER TABLE [dbo].[Perfil_x_Familia]  WITH CHECK ADD  CONSTRAINT [FK_PerfilFamilia_Familia] FOREIGN KEY([IdFamilia])
REFERENCES [dbo].[Familia] ([IdFamilia])
GO
ALTER TABLE [dbo].[Perfil_x_Familia] CHECK CONSTRAINT [FK_PerfilFamilia_Familia]
GO
ALTER TABLE [dbo].[Perfil_x_Familia]  WITH CHECK ADD  CONSTRAINT [FK_PerfilFamilia_Perfil] FOREIGN KEY([IdPerfil])
REFERENCES [dbo].[Perfil] ([IdPerfil])
GO
ALTER TABLE [dbo].[Perfil_x_Familia] CHECK CONSTRAINT [FK_PerfilFamilia_Perfil]
GO
ALTER TABLE [dbo].[Perfil_x_Permiso]  WITH CHECK ADD  CONSTRAINT [FK_PerfilPermiso_Perfil] FOREIGN KEY([IdPerfil])
REFERENCES [dbo].[Perfil] ([IdPerfil])
GO
ALTER TABLE [dbo].[Perfil_x_Permiso] CHECK CONSTRAINT [FK_PerfilPermiso_Perfil]
GO
ALTER TABLE [dbo].[Perfil_x_Permiso]  WITH CHECK ADD  CONSTRAINT [FK_PerfilPermiso_Permiso] FOREIGN KEY([IdPermiso])
REFERENCES [dbo].[Permiso] ([IdPermiso])
GO
ALTER TABLE [dbo].[Perfil_x_Permiso] CHECK CONSTRAINT [FK_PerfilPermiso_Permiso]
GO
ALTER TABLE [dbo].[Permiso_x_Familia]  WITH CHECK ADD  CONSTRAINT [FK_PermisoFamilia_Familia] FOREIGN KEY([IdFamilia])
REFERENCES [dbo].[Familia] ([IdFamilia])
GO
ALTER TABLE [dbo].[Permiso_x_Familia] CHECK CONSTRAINT [FK_PermisoFamilia_Familia]
GO
ALTER TABLE [dbo].[Permiso_x_Familia]  WITH CHECK ADD  CONSTRAINT [FK_PermisoFamilia_Permiso] FOREIGN KEY([IdPermiso])
REFERENCES [dbo].[Permiso] ([IdPermiso])
GO
ALTER TABLE [dbo].[Permiso_x_Familia] CHECK CONSTRAINT [FK_PermisoFamilia_Permiso]
GO
ALTER TABLE [dbo].[Prestamo]  WITH CHECK ADD  CONSTRAINT [FK_Prestamo_Cliente] FOREIGN KEY([DNI])
REFERENCES [dbo].[Cliente] ([DNI_657SGA])
GO
ALTER TABLE [dbo].[Prestamo] CHECK CONSTRAINT [FK_Prestamo_Cliente]
GO
ALTER TABLE [dbo].[Prestamo]  WITH CHECK ADD  CONSTRAINT [FK_Prestamo_Factura] FOREIGN KEY([IdFactura])
REFERENCES [dbo].[Factura] ([IdFactura])
GO
ALTER TABLE [dbo].[Prestamo] CHECK CONSTRAINT [FK_Prestamo_Factura]
GO
ALTER TABLE [dbo].[Prestamo]  WITH CHECK ADD  CONSTRAINT [FK_Prestamo_Libro] FOREIGN KEY([ISBN])
REFERENCES [dbo].[Libro] ([ISBN_657SGA])
GO
ALTER TABLE [dbo].[Prestamo] CHECK CONSTRAINT [FK_Prestamo_Libro]
GO
ALTER TABLE [dbo].[Usuario]  WITH CHECK ADD  CONSTRAINT [FK_Usuario_Idioma] FOREIGN KEY([IdIdioma])
REFERENCES [dbo].[Idioma] ([IdIdioma])
GO
ALTER TABLE [dbo].[Usuario] CHECK CONSTRAINT [FK_Usuario_Idioma]
GO
ALTER TABLE [dbo].[Usuario]  WITH CHECK ADD  CONSTRAINT [FK_Usuario_Perfil] FOREIGN KEY([IdPerfil])
REFERENCES [dbo].[Perfil] ([IdPerfil])
GO
ALTER TABLE [dbo].[Usuario] CHECK CONSTRAINT [FK_Usuario_Perfil]
GO
/****** Objeto: Trigger [dbo].[TR_Libro_Actualizado] Fecha de script: 13/11/2026 23:28:01 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- 3. Trigger TR_Libro_Actualizado (AFTER INSERT, UPDATE en Libro)
CREATE   TRIGGER [dbo].[TR_Libro_Actualizado]
ON [dbo].[Libro]
AFTER INSERT, UPDATE
AS
BEGIN
    SET NOCOUNT ON;

    -- Si la actualización provino de la sincronización de rollback en Libro_C, no duplicar versión
    IF TRIGGER_NESTLEVEL(OBJECT_ID('TR_Libro_C_Actualizado')) > 0
        RETURN;

    -- 1. Desactivar versiones previas de los libros modificados/insertados
    UPDATE lc
    SET lc.Act = 0
    FROM Libro_C lc
    INNER JOIN inserted i ON lc.ISBN = i.ISBN_657SGA
    WHERE lc.Act = 1;

    -- 2. Insertar la nueva versión activa
    INSERT INTO Libro_C (
        ISBN,
        Titulo,
        Precio,
        Existencias,
        ExistenciasPrestamo,
        Editorial,
        Autor,
        EsParaPrestamo,
        Activo,
        DVH,
        Fecha,
        Hora,
        Act
    )
    SELECT 
        i.ISBN_657SGA,
        i.[Título_657SGA],
        i.Precio_657SGA,
        i.Existencias_657SGA,
        i.ExistenciasPrestamo,
        i.Editorial_657SGA,
        i.Autor_657SGA,
        i.EsParaPrestamo,
        i.Activo_657SGA,
        i.DVH,
        CAST(GETDATE() AS DATE),
        CAST(GETDATE() AS TIME),
        1
    FROM inserted i;
END;
GO
ALTER TABLE [dbo].[Libro] ENABLE TRIGGER [TR_Libro_Actualizado]
GO
/****** Objeto: Trigger [dbo].[TR_Libro_Eliminado] Fecha de script: 13/11/2026 23:28:01 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- 4. Trigger TR_Libro_Eliminado (AFTER DELETE en Libro)
CREATE   TRIGGER [dbo].[TR_Libro_Eliminado]
ON [dbo].[Libro]
AFTER DELETE
AS
BEGIN
    SET NOCOUNT ON;

    -- Desactivar cualquier versión activa previa en Libro_C
    UPDATE lc
    SET lc.Act = 0
    FROM Libro_C lc
    INNER JOIN deleted d ON lc.ISBN = d.ISBN_657SGA
    WHERE lc.Act = 1;
END;
GO
ALTER TABLE [dbo].[Libro] ENABLE TRIGGER [TR_Libro_Eliminado]
GO
/****** Objeto: Trigger [dbo].[TR_Libro_C_Actualizado] Fecha de script: 13/11/2026 23:28:01 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- 5. Trigger TR_Libro_C_Actualizado (AFTER UPDATE en Libro_C)
CREATE   TRIGGER [dbo].[TR_Libro_C_Actualizado]
ON [dbo].[Libro_C]
AFTER UPDATE
AS
BEGIN
    SET NOCOUNT ON;

    -- Verificar si se activó una versión que estaba inactiva (Rollback)
    IF EXISTS (
        SELECT 1 
        FROM inserted i
        INNER JOIN deleted d ON i.IdLibroC = d.IdLibroC
        WHERE i.Act = 1 AND d.Act = 0
    )
    BEGIN
        -- Desactivar todas las demás versiones del mismo libro
        UPDATE lc
        SET lc.Act = 0
        FROM Libro_C lc
        INNER JOIN inserted i ON lc.ISBN = i.ISBN
        INNER JOIN deleted d ON i.IdLibroC = d.IdLibroC
        WHERE lc.IdLibroC <> i.IdLibroC 
          AND lc.Act = 1 
          AND i.Act = 1 
          AND d.Act = 0;

        -- Sincronizar la tabla operacional Libro con los valores de la versión restaurada
        UPDATE l
        SET 
            l.[Título_657SGA] = i.Titulo,
            l.Precio_657SGA = i.Precio,
            l.Existencias_657SGA = i.Existencias,
            l.ExistenciasPrestamo = i.ExistenciasPrestamo,
            l.Editorial_657SGA = i.Editorial,
            l.Autor_657SGA = i.Autor,
            l.EsParaPrestamo = i.EsParaPrestamo,
            l.Activo_657SGA = i.Activo
        FROM Libro l
        INNER JOIN inserted i ON l.ISBN_657SGA = i.ISBN
        INNER JOIN deleted d ON i.IdLibroC = d.IdLibroC
        WHERE i.Act = 1 AND d.Act = 0;
    END
END;
GO
ALTER TABLE [dbo].[Libro_C] ENABLE TRIGGER [TR_Libro_C_Actualizado]
GO
USE [master]
GO
ALTER DATABASE [EverGlow] SET  READ_WRITE 
GO
