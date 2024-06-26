create database telomandofinal
go
USE [telomandofinal]
GO
/****** Object:  Table [bodega_producto]    Script Date: 13/5/2024 15:39:03 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [bodega_producto](
	[idbodegaproducto] [int] IDENTITY(1,1) NOT NULL,
	[idbodega] [int] NOT NULL,
	[idproducto] [int] NOT NULL,
	[stock] [int] NOT NULL,
	[fecha_registro] [date] NOT NULL,
	[activo] [bit] NOT NULL,
	[eliminado][bit] NOT NULL,
 CONSTRAINT [PK_bodega_producto_idbodegaproducto] PRIMARY KEY CLUSTERED 
(
	[idbodegaproducto] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [bodegas]    Script Date: 13/5/2024 15:39:03 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [bodegas](
	[idbodega] [int] IDENTITY(1,1) NOT NULL,
	[idtipobodega] [int] NOT NULL,
	[idsucursal] [int] NOT NULL,
	[fecha_registro] [date] NOT NULL,
	[activo] [bit] NOT NULL,
	[eliminado][bit] NOT NULL,
 CONSTRAINT [PK_bodegas_idbodega] PRIMARY KEY CLUSTERED 
(
	[idbodega] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [categorias]    Script Date: 13/5/2024 15:39:03 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [categorias](
	[idcategoria] [int] IDENTITY(1,1) NOT NULL,
	[nombre] [varchar](255) NOT NULL,
	[fecha_registro] [date] NOT NULL,
	[activo] [bit] NOT NULL,
	[eliminado][bit] NOT NULL,
 CONSTRAINT [PK_categorias_idcategoria] PRIMARY KEY CLUSTERED 
(
	[idcategoria] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [ciudades]    Script Date: 13/5/2024 15:39:03 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [ciudades](
	[idciudad] [int] IDENTITY(1,1) NOT NULL,
	[idmunicipio] [int] NOT NULL,
	[nombre] [varchar](255) NOT NULL,
	[fecha_registro] [date] NOT NULL,
	[activo] [bit] NOT NULL,
	[eliminado][bit] NOT NULL,
 CONSTRAINT [PK_ciudades_idciudad] PRIMARY KEY CLUSTERED 
(
	[idciudad] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [clientes]    Script Date: 13/5/2024 15:39:03 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [clientes](
	[idcliente] [int] IDENTITY(1,1) NOT NULL,
	[idusuario] [int] NOT NULL,
	[idtipocliente] [int] NOT NULL,
	[fecha_registro] [date] NOT NULL,
	[activo] [bit] NOT NULL,
	[eliminado][bit] NOT NULL,
 CONSTRAINT [PK_clientes_idcliente] PRIMARY KEY CLUSTERED 
(
	[idcliente] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [contactos]    Script Date: 13/5/2024 15:39:03 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [contactos](
	[idcontacto] [int] IDENTITY(1,1) NOT NULL,
	[idusuario] [int] NOT NULL,
	[contacto1] [varchar](30) NOT NULL,
	[contacto2] [varchar](30) NOT NULL,
	[fecha_registro] [date] NOT NULL,
	[activo] [bit] NOT NULL,
	[eliminado][bit] NOT NULL,
 CONSTRAINT [PK_contactos_idcontacto] PRIMARY KEY CLUSTERED 
(
	[idcontacto] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [departamentos]    Script Date: 13/5/2024 15:39:03 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [departamentos](
	[iddepartamento] [int] IDENTITY(1,1) NOT NULL,
	[idpaises] [int] NOT NULL,
	[nombre] [varchar](255) NOT NULL,
	[fecha_registro] [date] NOT NULL,
	[activo] [bit] NOT NULL,
	[eliminado][bit] NOT NULL,
 CONSTRAINT [PK_departamentos_iddepartamento] PRIMARY KEY CLUSTERED 
(
	[iddepartamento] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [direcciones]    Script Date: 13/5/2024 15:39:03 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [direcciones](
	[iddireccion] [int] IDENTITY(1,1) NOT NULL,
	[idusuario] [int] NULL,
	[idsucursal] [int] NULL,
	[idciudad] [int] NOT NULL,
	[direccion1] [varchar](255) NULL,
	[direccion2] [varchar](255) NULL,
	[direccion3] [varchar](255) NULL,
	[fecha_registro] [date] NOT NULL,
	[activo] [bit] NOT NULL,
	[eliminado][bit] NOT NULL,
 CONSTRAINT [PK_direcciones_iddireccion] PRIMARY KEY CLUSTERED 
(
	[iddireccion] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [emails]    Script Date: 13/5/2024 15:39:03 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [emails](
	[idemail] [int] IDENTITY(1,1) NOT NULL,
	[idusuario] [int] NOT NULL,
	[email1] [varchar](100) NOT NULL,
	[email2] [varchar](100) NOT NULL,
	[fecha_registro] [date] NOT NULL,
	[activo] [bit] NOT NULL,
	[eliminado][bit] NOT NULL,
 CONSTRAINT [PK_emails_idemail] PRIMARY KEY CLUSTERED 
(
	[idemail] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [entregas]    Script Date: 13/5/2024 15:39:03 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [entregas](
	[identrega] [int] IDENTITY(1,1) NOT NULL,
	[codigo] [varchar](255) NOT NULL,
	[idcliente] [int] NOT NULL,
	[iddireccion] [int] NOT NULL,
	[informacion_adicional] [varchar](max) NULL,
	[idtipopago] [int] NOT NULL,
	[idtransporte] [int] NOT NULL,
	[idtarifa] [int] NOT NULL,
	[idbodega] [int] NOT NULL,
	[fecha_registro] [date] NOT NULL,
	[activo] [bit] NOT NULL,
	[eliminado][bit] NOT NULL,
 CONSTRAINT [PK_entregas_identrega] PRIMARY KEY CLUSTERED 
(
	[identrega] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [estado_entrega]    Script Date: 13/5/2024 15:39:03 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [estado_entrega](
	[idestadoentrega] [int] IDENTITY(1,1) NOT NULL,
	[idtipoestadoentrega] [int] NOT NULL,
	[informacion_adicional] [varchar](max) NULL,
	[fecha_registro] [date] NOT NULL,
	[activo] [bit] NOT NULL,
	[eliminado][bit] NOT NULL,
 CONSTRAINT [PK_estado_entrega_idestadoentrega] PRIMARY KEY CLUSTERED 
(
	[idestadoentrega] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [marca_transporte]    Script Date: 13/5/2024 15:39:03 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [marca_transporte](
	[idmarcatransporte] [int] IDENTITY(1,1) NOT NULL,
	[idmodelotransporte] [int] NOT NULL,
	[nombre] [varchar](100) NOT NULL,
	[fecha_registro] [date] NOT NULL,
	[activo] [bit] NOT NULL,
	[eliminado][bit] NOT NULL,
 CONSTRAINT [PK_marca_transporte_idmarcatransporte] PRIMARY KEY CLUSTERED 
(
	[idmarcatransporte] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [marcas]    Script Date: 13/5/2024 15:39:03 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [marcas](
	[idmarca] [int] IDENTITY(1,1) NOT NULL,
	[nombre] [varchar](255) NOT NULL,
	[fecha_registro] [date] NOT NULL,
	[activo] [bit] NOT NULL,
	[eliminado][bit] NOT NULL,
 CONSTRAINT [PK_marcas_idmarca] PRIMARY KEY CLUSTERED 
(
	[idmarca] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [modelo_transporte]    Script Date: 13/5/2024 15:39:03 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [modelo_transporte](
	[idmodelotransporte] [int] IDENTITY(1,1) NOT NULL,
	[nombre] [varchar](100) NOT NULL,
	[anio] [smallint] NOT NULL,
	[fecha_registro] [date] NOT NULL,
	[activo] [bit] NOT NULL,
	[eliminado][bit] NOT NULL,
 CONSTRAINT [PK_modelo_transporte_idmodelotransporte] PRIMARY KEY CLUSTERED 
(
	[idmodelotransporte] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [monedas]    Script Date: 13/5/2024 15:39:03 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [monedas](
	[idmoneda] [int] IDENTITY(1,1) NOT NULL,
	[nombre] [varchar](100) NOT NULL,
	[fecha_registro] [date] NOT NULL,
	[activo] [bit] NOT NULL,
	[eliminado][bit] NOT NULL,
 CONSTRAINT [PK_monedas_idmoneda] PRIMARY KEY CLUSTERED 
(
	[idmoneda] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [municipios]    Script Date: 13/5/2024 15:39:03 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [municipios](
	[idmunicipio] [int] IDENTITY(1,1) NOT NULL,
	[iddepartamento] [int] NULL,
	[nombre] [varchar](255) NOT NULL,
	[fecha_registro] [date] NOT NULL,
	[activo] [bit] NOT NULL,
	[eliminado][bit] NOT NULL,
 CONSTRAINT [PK_municipios_idmunicipio] PRIMARY KEY CLUSTERED 
(
	[idmunicipio] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [paises]    Script Date: 13/5/2024 15:39:03 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [paises](
	[idpaises] [int] IDENTITY(1,1) NOT NULL,
	[nombre] [varchar](255) NOT NULL,
	[fecha_registro] [date] NOT NULL,
	[activo] [bit] NOT NULL,
	[eliminado][bit] NOT NULL,
 CONSTRAINT [PK_paises_idpaises] PRIMARY KEY CLUSTERED 
(
	[idpaises] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [productos]    Script Date: 13/5/2024 15:39:03 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [productos](
	[idproducto] [int] IDENTITY(1,1) NOT NULL,
	[nombre] [varchar](32) NOT NULL,
	[idmarca] [int] NOT NULL,
	[precio] [decimal](16, 2) NOT NULL,
	[descripcion] [varchar](max) NULL,
	[fecha_registro] [date] NOT NULL,
	[activo] [bit] NOT NULL,
	[eliminado][bit] NOT NULL,
 CONSTRAINT [PK_productos_idproducto] PRIMARY KEY CLUSTERED 
(
	[idproducto] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [productos_detalles]    Script Date: 13/5/2024 15:39:03 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [productos_detalles](
	[idproductosdetalles] [int] IDENTITY(1,1) NOT NULL,
	[idproducto] [int] NOT NULL,
	[atributo] [varchar](150) NOT NULL,
	[valor] [varchar](255) NOT NULL,
	[fecha_registro] [date] NOT NULL,
	[activo] [bit] NOT NULL,
	[eliminado][bit] NOT NULL,
 CONSTRAINT [PK_productos_detalles_idproductosdetalles] PRIMARY KEY CLUSTERED 
(
	[idproductosdetalles] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [sub_categorias]    Script Date: 13/5/2024 15:39:03 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [sub_categorias](
	[idsubcategoria] [int] IDENTITY(1,1) NOT NULL,
	[idcategoria] [int] NOT NULL,
	[nombre] [varchar](255) NOT NULL,
	[fecha_registro] [date] NOT NULL,
	[activo] [bit] NOT NULL,
	[eliminado][bit] NOT NULL,
 CONSTRAINT [PK_sub_categorias_idsubcategoria] PRIMARY KEY CLUSTERED 
(
	[idsubcategoria] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [sucursal_personal]    Script Date: 13/5/2024 15:39:03 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [sucursal_personal](
	[idsucursalpersonal] [int] IDENTITY(1,1) NOT NULL,
	[idsucursal] [int] NOT NULL,
	[idusuario] [int] NOT NULL,
	[fecha_registro] [date] NOT NULL,
	[activo] [bit] NOT NULL,
	[eliminado][bit] NOT NULL,
 CONSTRAINT [PK_sucursal_personal_idsucursalpersonal] PRIMARY KEY CLUSTERED 
(
	[idsucursalpersonal] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [sucursales]    Script Date: 13/5/2024 15:39:03 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [sucursales](
	[idsucursal] [int] IDENTITY(1,1) NOT NULL,
	[nombre] [varchar](255) NOT NULL,
	[telefono] [varchar](30) NOT NULL,
	[celular] [varchar](30) NOT NULL,
	[email] [varchar](100) NOT NULL,
	[fecha_registro] [date] NOT NULL,
	[activo] [bit] NOT NULL,
	[eliminado][bit] NOT NULL,
 CONSTRAINT [PK_sucursales_idsucursal] PRIMARY KEY CLUSTERED 
(
	[idsucursal] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [tarifas]    Script Date: 13/5/2024 15:39:03 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [tarifas](
	[idtarifa] [int] IDENTITY(1,1) NOT NULL,
	[idmoneda] [int] NOT NULL,
	[valor] [decimal](16, 2) NOT NULL,
	[porcentaje_extra] [decimal](16, 2) NULL,
	[fecha_registro] [date] NOT NULL,
	[activo] [bit] NOT NULL,
	[eliminado][bit] NOT NULL,
 CONSTRAINT [PK_tarifas_idtarifa] PRIMARY KEY CLUSTERED 
(
	[idtarifa] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [tipo_bodega]    Script Date: 13/5/2024 15:39:03 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [tipo_bodega](
	[idtipobodega] [int] IDENTITY(1,1) NOT NULL,
	[nombre] [varchar](255) NOT NULL,
	[fecha_registro] [date] NOT NULL,
	[activo] [bit] NOT NULL,
	[eliminado][bit] NOT NULL,
 CONSTRAINT [PK_tipo_bodega_idtipobodega] PRIMARY KEY CLUSTERED 
(
	[idtipobodega] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [tipo_cliente]    Script Date: 13/5/2024 15:39:03 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [tipo_cliente](
	[idtipocliente] [int] IDENTITY(1,1) NOT NULL,
	[nombre] [varchar](255) NOT NULL,
	[fecha_registro] [date] NOT NULL,
	[activo] [bit] NOT NULL,
	[eliminado][bit] NOT NULL,
 CONSTRAINT [PK_tipo_cliente_idtipocliente] PRIMARY KEY CLUSTERED 
(
	[idtipocliente] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [tipo_estado_entrega]    Script Date: 13/5/2024 15:39:03 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [tipo_estado_entrega](
	[idtipoestadoentrega] [int] IDENTITY(1,1) NOT NULL,
	[nombre] [varchar](255) NOT NULL,
	[fecha_registro] [date] NOT NULL,
	[activo] [bit] NOT NULL,
	[eliminado][bit] NOT NULL,
 CONSTRAINT [PK_tipo_estado_entrega_idtipoestadoentrega] PRIMARY KEY CLUSTERED 
(
	[idtipoestadoentrega] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [tipo_pago]    Script Date: 13/5/2024 15:39:03 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [tipo_pago](
	[idtipopago] [int] IDENTITY(1,1) NOT NULL,
	[nombre] [varchar](255) NOT NULL,
	[fecha_registro] [date] NOT NULL,
	[activo] [bit] NOT NULL,
	[eliminado][bit] NOT NULL,
 CONSTRAINT [PK_tipo_pago_idtipopago] PRIMARY KEY CLUSTERED 
(
	[idtipopago] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [tipo_transporte]    Script Date: 13/5/2024 15:39:03 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [tipo_transporte](
	[idtipotransporte] [int] IDENTITY(1,1) NOT NULL,
	[nombre] [varchar](100) NOT NULL,
	[fecha_registro] [date] NOT NULL,
	[activo] [bit] NOT NULL,
	[eliminado][bit] NOT NULL,
 CONSTRAINT [PK_tipo_transporte_idtipotransporte] PRIMARY KEY CLUSTERED 
(
	[idtipotransporte] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [tipo_usuario]    Script Date: 13/5/2024 15:39:03 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [tipo_usuario](
	[idtipousuario] [int] IDENTITY(1,1) NOT NULL,
	[nombre] [varchar](255) NOT NULL,
	[fecha_registro] [date] NOT NULL,
	[activo] [bit] NOT NULL,
	[eliminado][bit] NOT NULL,
 CONSTRAINT [PK_tipo_usuario_idtipousuario] PRIMARY KEY CLUSTERED 
(
	[idtipousuario] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [transporte]    Script Date: 13/5/2024 15:39:03 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [transporte](
	[idtransporte] [int] IDENTITY(1,1) NOT NULL,
	[idmarcatransporte] [int] NOT NULL,
	[idtipotransporte] [int] NOT NULL,
	[placa] [varchar](16) NOT NULL,
	[fecha_registro] [date] NOT NULL,
	[activo] [bit] NOT NULL,
	[eliminado][bit] NOT NULL,
 CONSTRAINT [PK_transporte_idtransporte] PRIMARY KEY CLUSTERED 
(
	[idtransporte] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [transporte_sucursal]    Script Date: 13/5/2024 15:39:03 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [transporte_sucursal](
	[idtransporteusuario] [int] IDENTITY(1,1) NOT NULL,
	[idtransporte] [int] NOT NULL,
	[idsucursal] [int] NOT NULL,
	[fecha_registro] [date] NOT NULL,
	[activo] [bit] NOT NULL,
	[eliminado][bit] NOT NULL,
 CONSTRAINT [PK_transporte_sucursal_idtransporteusuario] PRIMARY KEY CLUSTERED 
(
	[idtransporteusuario] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [transporte_usuario]    Script Date: 13/5/2024 15:39:03 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [transporte_usuario](
	[idtransporteusuario] [int] IDENTITY(1,1) NOT NULL,
	[idtransporte] [int] NOT NULL,
	[idusuario] [int] NOT NULL,
	[fecha_registro] [date] NOT NULL,
	[activo] [bit] NOT NULL,
	[eliminado][bit] NOT NULL,
 CONSTRAINT [PK_transporte_usuario_idtransporteusuario] PRIMARY KEY CLUSTERED 
(
	[idtransporteusuario] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [usuario_password]    Script Date: 13/5/2024 15:39:03 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [usuario_password](
	[idusuariopassword] [int] IDENTITY(1,1) NOT NULL,
	[idusuario] [int] NOT NULL,
	[pwd] [varbinary](255) NOT NULL,
	[fecha_creacion] [date] NOT NULL,
	[fecha_vencimiento] [date] NULL,
	[fecha_registro] [date] NOT NULL,
	[activo] [bit] NOT NULL,
	[eliminado][bit] NOT NULL,
 CONSTRAINT [PK_usuario_password_idusuariopassword] PRIMARY KEY CLUSTERED 
(
	[idusuariopassword] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [usuarios]    Script Date: 13/5/2024 15:39:03 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [usuarios](
	[idusuario] [int] IDENTITY(1,1) NOT NULL,
	[nombres] [varchar](255) NOT NULL,
	[apellidos] [varchar](255) NOT NULL,
	[idtipousuario] [int] NOT NULL,
	[logueado] [varchar](2) NULL,
	[bloqueado] [varchar](2) NOT NULL,
	[intentos_login] [int] NOT NULL,
	[fecha_registro] [date] NOT NULL,
	[activo] [bit] NOT NULL,
	[eliminado][bit] NOT NULL,
 CONSTRAINT [PK_usuarios_idusuario] PRIMARY KEY CLUSTERED 
(
	[idusuario] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [bodega_producto]  WITH CHECK ADD  CONSTRAINT [bodega_producto$bodega_producto_ibfk_1] FOREIGN KEY([idbodega])
REFERENCES [bodegas] ([idbodega])
GO
ALTER TABLE [bodega_producto] CHECK CONSTRAINT [bodega_producto$bodega_producto_ibfk_1]
GO
ALTER TABLE [bodega_producto]  WITH CHECK ADD  CONSTRAINT [bodega_producto$bodega_producto_ibfk_2] FOREIGN KEY([idproducto])
REFERENCES [productos] ([idproducto])
GO
ALTER TABLE [bodega_producto] CHECK CONSTRAINT [bodega_producto$bodega_producto_ibfk_2]
GO
ALTER TABLE [bodegas]  WITH CHECK ADD  CONSTRAINT [bodegas$bodegas_ibfk_1] FOREIGN KEY([idtipobodega])
REFERENCES [tipo_bodega] ([idtipobodega])
GO
ALTER TABLE [bodegas] CHECK CONSTRAINT [bodegas$bodegas_ibfk_1]
GO
ALTER TABLE [bodegas]  WITH CHECK ADD  CONSTRAINT [bodegas$bodegas_ibfk_2] FOREIGN KEY([idsucursal])
REFERENCES [sucursales] ([idsucursal])
GO
ALTER TABLE [bodegas] CHECK CONSTRAINT [bodegas$bodegas_ibfk_2]
GO
ALTER TABLE [ciudades]  WITH CHECK ADD  CONSTRAINT [ciudades$ciudades_ibfk_1] FOREIGN KEY([idmunicipio])
REFERENCES [municipios] ([idmunicipio])
GO
ALTER TABLE [ciudades] CHECK CONSTRAINT [ciudades$ciudades_ibfk_1]
GO
ALTER TABLE [clientes]  WITH CHECK ADD  CONSTRAINT [clientes$clientes_ibfk_1] FOREIGN KEY([idusuario])
REFERENCES [usuarios] ([idusuario])
GO
ALTER TABLE [clientes] CHECK CONSTRAINT [clientes$clientes_ibfk_1]
GO
ALTER TABLE [clientes]  WITH CHECK ADD  CONSTRAINT [clientes$clientes_ibfk_2] FOREIGN KEY([idtipocliente])
REFERENCES [tipo_cliente] ([idtipocliente])
GO
ALTER TABLE [clientes] CHECK CONSTRAINT [clientes$clientes_ibfk_2]
GO
ALTER TABLE [contactos]  WITH CHECK ADD  CONSTRAINT [contactos$contactos_ibfk_1] FOREIGN KEY([idusuario])
REFERENCES [usuarios] ([idusuario])
GO
ALTER TABLE [contactos] CHECK CONSTRAINT [contactos$contactos_ibfk_1]
GO
ALTER TABLE [departamentos]  WITH CHECK ADD  CONSTRAINT [departamentos$departamentos_ibfk_1] FOREIGN KEY([idpaises])
REFERENCES [paises] ([idpaises])
GO
ALTER TABLE [departamentos] CHECK CONSTRAINT [departamentos$departamentos_ibfk_1]
GO
ALTER TABLE [direcciones]  WITH CHECK ADD  CONSTRAINT [direcciones$direcciones_ibfk_1] FOREIGN KEY([idusuario])
REFERENCES [usuarios] ([idusuario])
GO
ALTER TABLE [direcciones] CHECK CONSTRAINT [direcciones$direcciones_ibfk_1]
GO
ALTER TABLE [direcciones]  WITH CHECK ADD  CONSTRAINT [direcciones$direcciones_ibfk_2] FOREIGN KEY([idsucursal])
REFERENCES [sucursales] ([idsucursal])
GO
ALTER TABLE [direcciones] CHECK CONSTRAINT [direcciones$direcciones_ibfk_2]
GO
ALTER TABLE [direcciones]  WITH CHECK ADD  CONSTRAINT [direcciones$direcciones_ibfk_3] FOREIGN KEY([idciudad])
REFERENCES [ciudades] ([idciudad])
GO
ALTER TABLE [direcciones] CHECK CONSTRAINT [direcciones$direcciones_ibfk_3]
GO
ALTER TABLE [emails]  WITH CHECK ADD  CONSTRAINT [emails$emails_ibfk_1] FOREIGN KEY([idusuario])
REFERENCES [usuarios] ([idusuario])
GO
ALTER TABLE [emails] CHECK CONSTRAINT [emails$emails_ibfk_1]
GO
ALTER TABLE [entregas]  WITH CHECK ADD  CONSTRAINT [entregas$entregas_ibfk_1] FOREIGN KEY([idcliente])
REFERENCES [clientes] ([idcliente])
GO
ALTER TABLE [entregas] CHECK CONSTRAINT [entregas$entregas_ibfk_1]
GO
ALTER TABLE [entregas]  WITH CHECK ADD  CONSTRAINT [entregas$entregas_ibfk_2] FOREIGN KEY([iddireccion])
REFERENCES [direcciones] ([iddireccion])
GO
ALTER TABLE [entregas] CHECK CONSTRAINT [entregas$entregas_ibfk_2]
GO
ALTER TABLE [entregas]  WITH CHECK ADD  CONSTRAINT [entregas$entregas_ibfk_3] FOREIGN KEY([idtipopago])
REFERENCES [tipo_pago] ([idtipopago])
GO
ALTER TABLE [entregas] CHECK CONSTRAINT [entregas$entregas_ibfk_3]
GO
ALTER TABLE [entregas]  WITH CHECK ADD  CONSTRAINT [entregas$entregas_ibfk_4] FOREIGN KEY([idtransporte])
REFERENCES [transporte] ([idtransporte])
GO
ALTER TABLE [entregas] CHECK CONSTRAINT [entregas$entregas_ibfk_4]
GO
ALTER TABLE [entregas]  WITH CHECK ADD  CONSTRAINT [entregas$entregas_ibfk_5] FOREIGN KEY([idtarifa])
REFERENCES [tarifas] ([idtarifa])
GO
ALTER TABLE [entregas] CHECK CONSTRAINT [entregas$entregas_ibfk_5]
GO
ALTER TABLE [entregas]  WITH CHECK ADD  CONSTRAINT [entregas$entregas_ibfk_6] FOREIGN KEY([idbodega])
REFERENCES [bodegas] ([idbodega])
GO
ALTER TABLE [entregas] CHECK CONSTRAINT [entregas$entregas_ibfk_6]
GO
ALTER TABLE [estado_entrega]  WITH CHECK ADD  CONSTRAINT [estado_entrega$estado_entrega_ibfk_1] FOREIGN KEY([idtipoestadoentrega])
REFERENCES [tipo_estado_entrega] ([idtipoestadoentrega])
GO
ALTER TABLE [estado_entrega] CHECK CONSTRAINT [estado_entrega$estado_entrega_ibfk_1]
GO
ALTER TABLE [marca_transporte]  WITH CHECK ADD  CONSTRAINT [marca_transporte$marca_transporte_ibfk_1] FOREIGN KEY([idmodelotransporte])
REFERENCES [modelo_transporte] ([idmodelotransporte])
GO
ALTER TABLE [marca_transporte] CHECK CONSTRAINT [marca_transporte$marca_transporte_ibfk_1]
GO
ALTER TABLE [municipios]  WITH CHECK ADD  CONSTRAINT [municipios$municipios_ibfk_1] FOREIGN KEY([iddepartamento])
REFERENCES [departamentos] ([iddepartamento])
GO
ALTER TABLE [municipios] CHECK CONSTRAINT [municipios$municipios_ibfk_1]
GO
ALTER TABLE [productos]  WITH CHECK ADD  CONSTRAINT [productos$productos_ibfk_1] FOREIGN KEY([idmarca])
REFERENCES [marcas] ([idmarca])
GO
ALTER TABLE [productos] CHECK CONSTRAINT [productos$productos_ibfk_1]
GO
ALTER TABLE [productos_detalles]  WITH CHECK ADD  CONSTRAINT [productos_detalles$productos_detalles_ibfk_1] FOREIGN KEY([idproducto])
REFERENCES [productos] ([idproducto])
GO
ALTER TABLE [productos_detalles] CHECK CONSTRAINT [productos_detalles$productos_detalles_ibfk_1]
GO
ALTER TABLE [sub_categorias]  WITH CHECK ADD  CONSTRAINT [sub_categorias$sub_categorias_ibfk_1] FOREIGN KEY([idcategoria])
REFERENCES [categorias] ([idcategoria])
GO
ALTER TABLE [sub_categorias] CHECK CONSTRAINT [sub_categorias$sub_categorias_ibfk_1]
GO
ALTER TABLE [sucursal_personal]  WITH CHECK ADD  CONSTRAINT [sucursal_personal$sucursal_personal_ibfk_1] FOREIGN KEY([idusuario])
REFERENCES [usuarios] ([idusuario])
GO
ALTER TABLE [sucursal_personal] CHECK CONSTRAINT [sucursal_personal$sucursal_personal_ibfk_1]
GO
ALTER TABLE [sucursal_personal]  WITH CHECK ADD  CONSTRAINT [sucursal_personal$sucursal_personal_ibfk_2] FOREIGN KEY([idsucursal])
REFERENCES [sucursales] ([idsucursal])
GO
ALTER TABLE [sucursal_personal] CHECK CONSTRAINT [sucursal_personal$sucursal_personal_ibfk_2]
GO
ALTER TABLE [tarifas]  WITH CHECK ADD  CONSTRAINT [tarifas$tarifas_ibfk_1] FOREIGN KEY([idmoneda])
REFERENCES [monedas] ([idmoneda])
GO
ALTER TABLE [tarifas] CHECK CONSTRAINT [tarifas$tarifas_ibfk_1]
GO
ALTER TABLE [transporte_sucursal]  WITH CHECK ADD  CONSTRAINT [transporte_sucursal$transporte_sucursal_ibfk_1] FOREIGN KEY([idsucursal])
REFERENCES [sucursales] ([idsucursal])
GO
ALTER TABLE [transporte_sucursal] CHECK CONSTRAINT [transporte_sucursal$transporte_sucursal_ibfk_1]
GO
ALTER TABLE [transporte_sucursal]  WITH CHECK ADD  CONSTRAINT [transporte_sucursal$transporte_sucursal_ibfk_2] FOREIGN KEY([idtransporte])
REFERENCES [transporte] ([idtransporte])
GO
ALTER TABLE [transporte_sucursal] CHECK CONSTRAINT [transporte_sucursal$transporte_sucursal_ibfk_2]
GO
ALTER TABLE [transporte_usuario]  WITH CHECK ADD  CONSTRAINT [transporte_usuario$transporte_usuario_ibfk_1] FOREIGN KEY([idusuario])
REFERENCES [usuarios] ([idusuario])
GO
ALTER TABLE [transporte_usuario] CHECK CONSTRAINT [transporte_usuario$transporte_usuario_ibfk_1]
GO
ALTER TABLE [transporte_usuario]  WITH CHECK ADD  CONSTRAINT [transporte_usuario$transporte_usuario_ibfk_2] FOREIGN KEY([idtransporte])
REFERENCES [transporte] ([idtransporte])
GO
ALTER TABLE [transporte_usuario] CHECK CONSTRAINT [transporte_usuario$transporte_usuario_ibfk_2]
GO
ALTER TABLE [usuario_password]  WITH CHECK ADD  CONSTRAINT [usuario_password$usuario_password_ibfk_1] FOREIGN KEY([idusuario])
REFERENCES [usuarios] ([idusuario])
GO
ALTER TABLE [usuario_password] CHECK CONSTRAINT [usuario_password$usuario_password_ibfk_1]
GO
ALTER TABLE [usuarios]  WITH CHECK ADD  CONSTRAINT [usuarios$usuarios_ibfk_1] FOREIGN KEY([idtipousuario])
REFERENCES [tipo_usuario] ([idtipousuario])
GO
ALTER TABLE [usuarios] CHECK CONSTRAINT [usuarios$usuarios_ibfk_1]
