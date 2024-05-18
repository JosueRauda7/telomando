using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Telomando.Models;

public partial class TelomandofinalContext : DbContext
{
    /*
    public TelomandofinalContext()
    {
    }
    */

    public TelomandofinalContext(DbContextOptions<TelomandofinalContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Bodega> Bodegas { get; set; }

    public virtual DbSet<BodegaProducto> BodegaProductos { get; set; }

    public virtual DbSet<Categoria> Categorias { get; set; }

    public virtual DbSet<Ciudade> Ciudades { get; set; }

    public virtual DbSet<Cliente> Clientes { get; set; }

    public virtual DbSet<Contacto> Contactos { get; set; }

    public virtual DbSet<Departamento> Departamentos { get; set; }

    public virtual DbSet<Direccione> Direcciones { get; set; }

    public virtual DbSet<Email> Emails { get; set; }

    public virtual DbSet<Entrega> Entregas { get; set; }

    public virtual DbSet<EstadoEntrega> EstadoEntregas { get; set; }

    public virtual DbSet<Marca> Marcas { get; set; }

    public virtual DbSet<MarcaTransporte> MarcaTransportes { get; set; }

    public virtual DbSet<ModeloTransporte> ModeloTransportes { get; set; }

    public virtual DbSet<Moneda> Monedas { get; set; }

    public virtual DbSet<Municipio> Municipios { get; set; }

    public virtual DbSet<Paise> Paises { get; set; }

    public virtual DbSet<Producto> Productos { get; set; }

    public virtual DbSet<ProductosDetalle> ProductosDetalles { get; set; }

    public virtual DbSet<SubCategoria> SubCategorias { get; set; }

    public virtual DbSet<SucursalPersonal> SucursalPersonals { get; set; }

    public virtual DbSet<Sucursale> Sucursales { get; set; }

    public virtual DbSet<Tarifa> Tarifas { get; set; }

    public virtual DbSet<TipoBodega> TipoBodegas { get; set; }

    public virtual DbSet<TipoCliente> TipoClientes { get; set; }

    public virtual DbSet<TipoEstadoEntrega> TipoEstadoEntregas { get; set; }

    public virtual DbSet<TipoPago> TipoPagos { get; set; }

    public virtual DbSet<TipoTransporte> TipoTransportes { get; set; }

    public virtual DbSet<TipoUsuario> TipoUsuarios { get; set; }

    public virtual DbSet<Transporte> Transportes { get; set; }

    public virtual DbSet<TransporteSucursal> TransporteSucursals { get; set; }

    public virtual DbSet<TransporteUsuario> TransporteUsuarios { get; set; }

    public virtual DbSet<Usuario> Usuarios { get; set; }

    public virtual DbSet<UsuarioPassword> UsuarioPasswords { get; set; }

    /*
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("data source=DESKTOP-RAUDA;initial catalog=telomandofinal;integrated security=True;encrypt=False;MultipleActiveResultSets=True;");
    */

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Bodega>(entity =>
        {
            entity.HasKey(e => e.Idbodega).HasName("PK_bodegas_idbodega");

            entity.ToTable("bodegas");

            entity.Property(e => e.Idbodega).HasColumnName("idbodega");
            entity.Property(e => e.Activo).HasColumnName("activo");
            entity.Property(e => e.Eliminado).HasColumnName("eliminado");
            entity.Property(e => e.FechaRegistro).HasColumnName("fecha_registro");
            entity.Property(e => e.Idsucursal).HasColumnName("idsucursal");
            entity.Property(e => e.Idtipobodega).HasColumnName("idtipobodega");

            entity.HasOne(d => d.IdsucursalNavigation).WithMany(p => p.Bodegas)
                .HasForeignKey(d => d.Idsucursal)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("bodegas$bodegas_ibfk_2");

            entity.HasOne(d => d.IdtipobodegaNavigation).WithMany(p => p.Bodegas)
                .HasForeignKey(d => d.Idtipobodega)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("bodegas$bodegas_ibfk_1");
        });

        modelBuilder.Entity<BodegaProducto>(entity =>
        {
            entity.HasKey(e => e.Idbodegaproducto).HasName("PK_bodega_producto_idbodegaproducto");

            entity.ToTable("bodega_producto");

            entity.Property(e => e.Idbodegaproducto).HasColumnName("idbodegaproducto");
            entity.Property(e => e.Activo).HasColumnName("activo");
            entity.Property(e => e.Eliminado).HasColumnName("eliminado");
            entity.Property(e => e.FechaRegistro).HasColumnName("fecha_registro");
            entity.Property(e => e.Idbodega).HasColumnName("idbodega");
            entity.Property(e => e.Idproducto).HasColumnName("idproducto");
            entity.Property(e => e.Stock).HasColumnName("stock");

            entity.HasOne(d => d.IdbodegaNavigation).WithMany(p => p.BodegaProductos)
                .HasForeignKey(d => d.Idbodega)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("bodega_producto$bodega_producto_ibfk_1");

            entity.HasOne(d => d.IdproductoNavigation).WithMany(p => p.BodegaProductos)
                .HasForeignKey(d => d.Idproducto)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("bodega_producto$bodega_producto_ibfk_2");
        });

        modelBuilder.Entity<Categoria>(entity =>
        {
            entity.HasKey(e => e.Idcategoria).HasName("PK_categorias_idcategoria");

            entity.ToTable("categorias");

            entity.Property(e => e.Idcategoria).HasColumnName("idcategoria");
            entity.Property(e => e.Activo).HasColumnName("activo");
            entity.Property(e => e.Eliminado).HasColumnName("eliminado");
            entity.Property(e => e.FechaRegistro).HasColumnName("fecha_registro");
            entity.Property(e => e.Nombre)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("nombre");
        });

        modelBuilder.Entity<Ciudade>(entity =>
        {
            entity.HasKey(e => e.Idciudad).HasName("PK_ciudades_idciudad");

            entity.ToTable("ciudades");

            entity.Property(e => e.Idciudad).HasColumnName("idciudad");
            entity.Property(e => e.Activo).HasColumnName("activo");
            entity.Property(e => e.Eliminado).HasColumnName("eliminado");
            entity.Property(e => e.FechaRegistro).HasColumnName("fecha_registro");
            entity.Property(e => e.Idmunicipio).HasColumnName("idmunicipio");
            entity.Property(e => e.Nombre)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("nombre");

            entity.HasOne(d => d.IdmunicipioNavigation).WithMany(p => p.Ciudades)
                .HasForeignKey(d => d.Idmunicipio)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("ciudades$ciudades_ibfk_1");
        });

        modelBuilder.Entity<Cliente>(entity =>
        {
            entity.HasKey(e => e.Idcliente).HasName("PK_clientes_idcliente");

            entity.ToTable("clientes");

            entity.Property(e => e.Idcliente).HasColumnName("idcliente");
            entity.Property(e => e.Activo).HasColumnName("activo");
            entity.Property(e => e.Eliminado).HasColumnName("eliminado");
            entity.Property(e => e.FechaRegistro).HasColumnName("fecha_registro");
            entity.Property(e => e.Idtipocliente).HasColumnName("idtipocliente");
            entity.Property(e => e.Idusuario).HasColumnName("idusuario");

            entity.HasOne(d => d.IdtipoclienteNavigation).WithMany(p => p.Clientes)
                .HasForeignKey(d => d.Idtipocliente)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("clientes$clientes_ibfk_2");

            entity.HasOne(d => d.IdusuarioNavigation).WithMany(p => p.Clientes)
                .HasForeignKey(d => d.Idusuario)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("clientes$clientes_ibfk_1");
        });

        modelBuilder.Entity<Contacto>(entity =>
        {
            entity.HasKey(e => e.Idcontacto).HasName("PK_contactos_idcontacto");

            entity.ToTable("contactos");

            entity.Property(e => e.Idcontacto).HasColumnName("idcontacto");
            entity.Property(e => e.Activo).HasColumnName("activo");
            entity.Property(e => e.Contacto1)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasColumnName("contacto1");
            entity.Property(e => e.Contacto2)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasColumnName("contacto2");
            entity.Property(e => e.Eliminado).HasColumnName("eliminado");
            entity.Property(e => e.FechaRegistro).HasColumnName("fecha_registro");
            entity.Property(e => e.Idusuario).HasColumnName("idusuario");

            entity.HasOne(d => d.IdusuarioNavigation).WithMany(p => p.Contactos)
                .HasForeignKey(d => d.Idusuario)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("contactos$contactos_ibfk_1");
        });

        modelBuilder.Entity<Departamento>(entity =>
        {
            entity.HasKey(e => e.Iddepartamento).HasName("PK_departamentos_iddepartamento");

            entity.ToTable("departamentos");

            entity.Property(e => e.Iddepartamento).HasColumnName("iddepartamento");
            entity.Property(e => e.Activo).HasColumnName("activo");
            entity.Property(e => e.Eliminado).HasColumnName("eliminado");
            entity.Property(e => e.FechaRegistro).HasColumnName("fecha_registro");
            entity.Property(e => e.Idpaises).HasColumnName("idpaises");
            entity.Property(e => e.Nombre)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("nombre");

            entity.HasOne(d => d.IdpaisesNavigation).WithMany(p => p.Departamentos)
                .HasForeignKey(d => d.Idpaises)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("departamentos$departamentos_ibfk_1");
        });

        modelBuilder.Entity<Direccione>(entity =>
        {
            entity.HasKey(e => e.Iddireccion).HasName("PK_direcciones_iddireccion");

            entity.ToTable("direcciones");

            entity.Property(e => e.Iddireccion).HasColumnName("iddireccion");
            entity.Property(e => e.Activo).HasColumnName("activo");
            entity.Property(e => e.Direccion1)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("direccion1");
            entity.Property(e => e.Direccion2)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("direccion2");
            entity.Property(e => e.Direccion3)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("direccion3");
            entity.Property(e => e.Eliminado).HasColumnName("eliminado");
            entity.Property(e => e.FechaRegistro).HasColumnName("fecha_registro");
            entity.Property(e => e.Idciudad).HasColumnName("idciudad");
            entity.Property(e => e.Idsucursal).HasColumnName("idsucursal");
            entity.Property(e => e.Idusuario).HasColumnName("idusuario");

            entity.HasOne(d => d.IdciudadNavigation).WithMany(p => p.Direcciones)
                .HasForeignKey(d => d.Idciudad)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("direcciones$direcciones_ibfk_3");

            entity.HasOne(d => d.IdsucursalNavigation).WithMany(p => p.Direcciones)
                .HasForeignKey(d => d.Idsucursal)
                .HasConstraintName("direcciones$direcciones_ibfk_2");

            entity.HasOne(d => d.IdusuarioNavigation).WithMany(p => p.Direcciones)
                .HasForeignKey(d => d.Idusuario)
                .HasConstraintName("direcciones$direcciones_ibfk_1");
        });

        modelBuilder.Entity<Email>(entity =>
        {
            entity.HasKey(e => e.Idemail).HasName("PK_emails_idemail");

            entity.ToTable("emails");

            entity.Property(e => e.Idemail).HasColumnName("idemail");
            entity.Property(e => e.Activo).HasColumnName("activo");
            entity.Property(e => e.Eliminado).HasColumnName("eliminado");
            entity.Property(e => e.Email1)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("email1");
            entity.Property(e => e.Email2)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("email2");
            entity.Property(e => e.FechaRegistro).HasColumnName("fecha_registro");
            entity.Property(e => e.Idusuario).HasColumnName("idusuario");

            entity.HasOne(d => d.IdusuarioNavigation).WithMany(p => p.Emails)
                .HasForeignKey(d => d.Idusuario)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("emails$emails_ibfk_1");
        });

        modelBuilder.Entity<Entrega>(entity =>
        {
            entity.HasKey(e => e.Identrega).HasName("PK_entregas_identrega");

            entity.ToTable("entregas");

            entity.Property(e => e.Identrega).HasColumnName("identrega");
            entity.Property(e => e.Activo).HasColumnName("activo");
            entity.Property(e => e.Codigo)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("codigo");
            entity.Property(e => e.Eliminado).HasColumnName("eliminado");
            entity.Property(e => e.FechaRegistro).HasColumnName("fecha_registro");
            entity.Property(e => e.Idbodega).HasColumnName("idbodega");
            entity.Property(e => e.Idcliente).HasColumnName("idcliente");
            entity.Property(e => e.Iddireccion).HasColumnName("iddireccion");
            entity.Property(e => e.Idtarifa).HasColumnName("idtarifa");
            entity.Property(e => e.Idtipopago).HasColumnName("idtipopago");
            entity.Property(e => e.Idtransporte).HasColumnName("idtransporte");
            entity.Property(e => e.InformacionAdicional)
                .IsUnicode(false)
                .HasColumnName("informacion_adicional");

            entity.HasOne(d => d.IdbodegaNavigation).WithMany(p => p.Entregas)
                .HasForeignKey(d => d.Idbodega)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("entregas$entregas_ibfk_6");

            entity.HasOne(d => d.IdclienteNavigation).WithMany(p => p.Entregas)
                .HasForeignKey(d => d.Idcliente)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("entregas$entregas_ibfk_1");

            entity.HasOne(d => d.IddireccionNavigation).WithMany(p => p.Entregas)
                .HasForeignKey(d => d.Iddireccion)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("entregas$entregas_ibfk_2");

            entity.HasOne(d => d.IdtarifaNavigation).WithMany(p => p.Entregas)
                .HasForeignKey(d => d.Idtarifa)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("entregas$entregas_ibfk_5");

            entity.HasOne(d => d.IdtipopagoNavigation).WithMany(p => p.Entregas)
                .HasForeignKey(d => d.Idtipopago)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("entregas$entregas_ibfk_3");

            entity.HasOne(d => d.IdtransporteNavigation).WithMany(p => p.Entregas)
                .HasForeignKey(d => d.Idtransporte)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("entregas$entregas_ibfk_4");
        });

        modelBuilder.Entity<EstadoEntrega>(entity =>
        {
            entity.HasKey(e => e.Idestadoentrega).HasName("PK_estado_entrega_idestadoentrega");

            entity.ToTable("estado_entrega");

            entity.Property(e => e.Idestadoentrega).HasColumnName("idestadoentrega");
            entity.Property(e => e.Activo).HasColumnName("activo");
            entity.Property(e => e.Eliminado).HasColumnName("eliminado");
            entity.Property(e => e.FechaRegistro).HasColumnName("fecha_registro");
            entity.Property(e => e.Idtipoestadoentrega).HasColumnName("idtipoestadoentrega");
            entity.Property(e => e.InformacionAdicional)
                .IsUnicode(false)
                .HasColumnName("informacion_adicional");

            entity.HasOne(d => d.IdtipoestadoentregaNavigation).WithMany(p => p.EstadoEntregas)
                .HasForeignKey(d => d.Idtipoestadoentrega)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("estado_entrega$estado_entrega_ibfk_1");
        });

        modelBuilder.Entity<Marca>(entity =>
        {
            entity.HasKey(e => e.Idmarca).HasName("PK_marcas_idmarca");

            entity.ToTable("marcas");

            entity.Property(e => e.Idmarca).HasColumnName("idmarca");
            entity.Property(e => e.Activo).HasColumnName("activo");
            entity.Property(e => e.Eliminado).HasColumnName("eliminado");
            entity.Property(e => e.FechaRegistro).HasColumnName("fecha_registro");
            entity.Property(e => e.Nombre)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("nombre");
        });

        modelBuilder.Entity<MarcaTransporte>(entity =>
        {
            entity.HasKey(e => e.Idmarcatransporte).HasName("PK_marca_transporte_idmarcatransporte");

            entity.ToTable("marca_transporte");

            entity.Property(e => e.Idmarcatransporte).HasColumnName("idmarcatransporte");
            entity.Property(e => e.Activo).HasColumnName("activo");
            entity.Property(e => e.Eliminado).HasColumnName("eliminado");
            entity.Property(e => e.FechaRegistro).HasColumnName("fecha_registro");
            entity.Property(e => e.Idmodelotransporte).HasColumnName("idmodelotransporte");
            entity.Property(e => e.Nombre)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("nombre");

            entity.HasOne(d => d.IdmodelotransporteNavigation).WithMany(p => p.MarcaTransportes)
                .HasForeignKey(d => d.Idmodelotransporte)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("marca_transporte$marca_transporte_ibfk_1");
        });

        modelBuilder.Entity<ModeloTransporte>(entity =>
        {
            entity.HasKey(e => e.Idmodelotransporte).HasName("PK_modelo_transporte_idmodelotransporte");

            entity.ToTable("modelo_transporte");

            entity.Property(e => e.Idmodelotransporte).HasColumnName("idmodelotransporte");
            entity.Property(e => e.Activo).HasColumnName("activo");
            entity.Property(e => e.Anio).HasColumnName("anio");
            entity.Property(e => e.Eliminado).HasColumnName("eliminado");
            entity.Property(e => e.FechaRegistro).HasColumnName("fecha_registro");
            entity.Property(e => e.Nombre)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("nombre");
        });

        modelBuilder.Entity<Moneda>(entity =>
        {
            entity.HasKey(e => e.Idmoneda).HasName("PK_monedas_idmoneda");

            entity.ToTable("monedas");

            entity.Property(e => e.Idmoneda).HasColumnName("idmoneda");
            entity.Property(e => e.Activo).HasColumnName("activo");
            entity.Property(e => e.Eliminado).HasColumnName("eliminado");
            entity.Property(e => e.FechaRegistro).HasColumnName("fecha_registro");
            entity.Property(e => e.Nombre)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("nombre");
        });

        modelBuilder.Entity<Municipio>(entity =>
        {
            entity.HasKey(e => e.Idmunicipio).HasName("PK_municipios_idmunicipio");

            entity.ToTable("municipios");

            entity.Property(e => e.Idmunicipio).HasColumnName("idmunicipio");
            entity.Property(e => e.Activo).HasColumnName("activo");
            entity.Property(e => e.Eliminado).HasColumnName("eliminado");
            entity.Property(e => e.FechaRegistro).HasColumnName("fecha_registro");
            entity.Property(e => e.Iddepartamento).HasColumnName("iddepartamento");
            entity.Property(e => e.Nombre)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("nombre");

            entity.HasOne(d => d.IddepartamentoNavigation).WithMany(p => p.Municipios)
                .HasForeignKey(d => d.Iddepartamento)
                .HasConstraintName("municipios$municipios_ibfk_1");
        });

        modelBuilder.Entity<Paise>(entity =>
        {
            entity.HasKey(e => e.Idpaises).HasName("PK_paises_idpaises");

            entity.ToTable("paises");

            entity.Property(e => e.Idpaises).HasColumnName("idpaises");
            entity.Property(e => e.Activo).HasColumnName("activo");
            entity.Property(e => e.Eliminado).HasColumnName("eliminado");
            entity.Property(e => e.FechaRegistro).HasColumnName("fecha_registro");
            entity.Property(e => e.Nombre)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("nombre");
        });

        modelBuilder.Entity<Producto>(entity =>
        {
            entity.HasKey(e => e.Idproducto).HasName("PK_productos_idproducto");

            entity.ToTable("productos");

            entity.Property(e => e.Idproducto).HasColumnName("idproducto");
            entity.Property(e => e.Activo).HasColumnName("activo");
            entity.Property(e => e.Descripcion)
                .IsUnicode(false)
                .HasColumnName("descripcion");
            entity.Property(e => e.Eliminado).HasColumnName("eliminado");
            entity.Property(e => e.FechaRegistro).HasColumnName("fecha_registro");
            entity.Property(e => e.Idmarca).HasColumnName("idmarca");
            entity.Property(e => e.Nombre)
                .HasMaxLength(32)
                .IsUnicode(false)
                .HasColumnName("nombre");
            entity.Property(e => e.Precio)
                .HasColumnType("decimal(16, 2)")
                .HasColumnName("precio");

            entity.HasOne(d => d.IdmarcaNavigation).WithMany(p => p.Productos)
                .HasForeignKey(d => d.Idmarca)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("productos$productos_ibfk_1");
        });

        modelBuilder.Entity<ProductosDetalle>(entity =>
        {
            entity.HasKey(e => e.Idproductosdetalles).HasName("PK_productos_detalles_idproductosdetalles");

            entity.ToTable("productos_detalles");

            entity.Property(e => e.Idproductosdetalles).HasColumnName("idproductosdetalles");
            entity.Property(e => e.Activo).HasColumnName("activo");
            entity.Property(e => e.Atributo)
                .HasMaxLength(150)
                .IsUnicode(false)
                .HasColumnName("atributo");
            entity.Property(e => e.Eliminado).HasColumnName("eliminado");
            entity.Property(e => e.FechaRegistro).HasColumnName("fecha_registro");
            entity.Property(e => e.Idproducto).HasColumnName("idproducto");
            entity.Property(e => e.Valor)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("valor");

            entity.HasOne(d => d.IdproductoNavigation).WithMany(p => p.ProductosDetalles)
                .HasForeignKey(d => d.Idproducto)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("productos_detalles$productos_detalles_ibfk_1");
        });

        modelBuilder.Entity<SubCategoria>(entity =>
        {
            entity.HasKey(e => e.Idsubcategoria).HasName("PK_sub_categorias_idsubcategoria");

            entity.ToTable("sub_categorias");

            entity.Property(e => e.Idsubcategoria).HasColumnName("idsubcategoria");
            entity.Property(e => e.Activo).HasColumnName("activo");
            entity.Property(e => e.Eliminado).HasColumnName("eliminado");
            entity.Property(e => e.FechaRegistro).HasColumnName("fecha_registro");
            entity.Property(e => e.Idcategoria).HasColumnName("idcategoria");
            entity.Property(e => e.Nombre)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("nombre");

            entity.HasOne(d => d.IdcategoriaNavigation).WithMany(p => p.SubCategoria)
                .HasForeignKey(d => d.Idcategoria)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("sub_categorias$sub_categorias_ibfk_1");
        });

        modelBuilder.Entity<SucursalPersonal>(entity =>
        {
            entity.HasKey(e => e.Idsucursalpersonal).HasName("PK_sucursal_personal_idsucursalpersonal");

            entity.ToTable("sucursal_personal");

            entity.Property(e => e.Idsucursalpersonal).HasColumnName("idsucursalpersonal");
            entity.Property(e => e.Activo).HasColumnName("activo");
            entity.Property(e => e.Eliminado).HasColumnName("eliminado");
            entity.Property(e => e.FechaRegistro).HasColumnName("fecha_registro");
            entity.Property(e => e.Idsucursal).HasColumnName("idsucursal");
            entity.Property(e => e.Idusuario).HasColumnName("idusuario");

            entity.HasOne(d => d.IdsucursalNavigation).WithMany(p => p.SucursalPersonals)
                .HasForeignKey(d => d.Idsucursal)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("sucursal_personal$sucursal_personal_ibfk_2");

            entity.HasOne(d => d.IdusuarioNavigation).WithMany(p => p.SucursalPersonals)
                .HasForeignKey(d => d.Idusuario)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("sucursal_personal$sucursal_personal_ibfk_1");
        });

        modelBuilder.Entity<Sucursale>(entity =>
        {
            entity.HasKey(e => e.Idsucursal).HasName("PK_sucursales_idsucursal");

            entity.ToTable("sucursales");

            entity.Property(e => e.Idsucursal).HasColumnName("idsucursal");
            entity.Property(e => e.Activo).HasColumnName("activo");
            entity.Property(e => e.Celular)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasColumnName("celular");
            entity.Property(e => e.Eliminado).HasColumnName("eliminado");
            entity.Property(e => e.Email)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("email");
            entity.Property(e => e.FechaRegistro).HasColumnName("fecha_registro");
            entity.Property(e => e.Nombre)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("nombre");
            entity.Property(e => e.Telefono)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasColumnName("telefono");
        });

        modelBuilder.Entity<Tarifa>(entity =>
        {
            entity.HasKey(e => e.Idtarifa).HasName("PK_tarifas_idtarifa");

            entity.ToTable("tarifas");

            entity.Property(e => e.Idtarifa).HasColumnName("idtarifa");
            entity.Property(e => e.Activo).HasColumnName("activo");
            entity.Property(e => e.Eliminado).HasColumnName("eliminado");
            entity.Property(e => e.FechaRegistro).HasColumnName("fecha_registro");
            entity.Property(e => e.Idmoneda).HasColumnName("idmoneda");
            entity.Property(e => e.PorcentajeExtra)
                .HasColumnType("decimal(16, 2)")
                .HasColumnName("porcentaje_extra");
            entity.Property(e => e.Valor)
                .HasColumnType("decimal(16, 2)")
                .HasColumnName("valor");

            entity.HasOne(d => d.IdmonedaNavigation).WithMany(p => p.Tarifas)
                .HasForeignKey(d => d.Idmoneda)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("tarifas$tarifas_ibfk_1");
        });

        modelBuilder.Entity<TipoBodega>(entity =>
        {
            entity.HasKey(e => e.Idtipobodega).HasName("PK_tipo_bodega_idtipobodega");

            entity.ToTable("tipo_bodega");

            entity.Property(e => e.Idtipobodega).HasColumnName("idtipobodega");
            entity.Property(e => e.Activo).HasColumnName("activo");
            entity.Property(e => e.Eliminado).HasColumnName("eliminado");
            entity.Property(e => e.FechaRegistro).HasColumnName("fecha_registro");
            entity.Property(e => e.Nombre)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("nombre");
        });

        modelBuilder.Entity<TipoCliente>(entity =>
        {
            entity.HasKey(e => e.Idtipocliente).HasName("PK_tipo_cliente_idtipocliente");

            entity.ToTable("tipo_cliente");

            entity.Property(e => e.Idtipocliente).HasColumnName("idtipocliente");
            entity.Property(e => e.Activo).HasColumnName("activo");
            entity.Property(e => e.Eliminado).HasColumnName("eliminado");
            entity.Property(e => e.FechaRegistro).HasColumnName("fecha_registro");
            entity.Property(e => e.Nombre)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("nombre");
        });

        modelBuilder.Entity<TipoEstadoEntrega>(entity =>
        {
            entity.HasKey(e => e.Idtipoestadoentrega).HasName("PK_tipo_estado_entrega_idtipoestadoentrega");

            entity.ToTable("tipo_estado_entrega");

            entity.Property(e => e.Idtipoestadoentrega).HasColumnName("idtipoestadoentrega");
            entity.Property(e => e.Activo).HasColumnName("activo");
            entity.Property(e => e.Eliminado).HasColumnName("eliminado");
            entity.Property(e => e.FechaRegistro).HasColumnName("fecha_registro");
            entity.Property(e => e.Nombre)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("nombre");
        });

        modelBuilder.Entity<TipoPago>(entity =>
        {
            entity.HasKey(e => e.Idtipopago).HasName("PK_tipo_pago_idtipopago");

            entity.ToTable("tipo_pago");

            entity.Property(e => e.Idtipopago).HasColumnName("idtipopago");
            entity.Property(e => e.Activo).HasColumnName("activo");
            entity.Property(e => e.Eliminado).HasColumnName("eliminado");
            entity.Property(e => e.FechaRegistro).HasColumnName("fecha_registro");
            entity.Property(e => e.Nombre)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("nombre");
        });

        modelBuilder.Entity<TipoTransporte>(entity =>
        {
            entity.HasKey(e => e.Idtipotransporte).HasName("PK_tipo_transporte_idtipotransporte");

            entity.ToTable("tipo_transporte");

            entity.Property(e => e.Idtipotransporte).HasColumnName("idtipotransporte");
            entity.Property(e => e.Activo).HasColumnName("activo");
            entity.Property(e => e.Eliminado).HasColumnName("eliminado");
            entity.Property(e => e.FechaRegistro).HasColumnName("fecha_registro");
            entity.Property(e => e.Nombre)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("nombre");
        });

        modelBuilder.Entity<TipoUsuario>(entity =>
        {
            entity.HasKey(e => e.Idtipousuario).HasName("PK_tipo_usuario_idtipousuario");

            entity.ToTable("tipo_usuario");

            entity.Property(e => e.Idtipousuario).HasColumnName("idtipousuario");
            entity.Property(e => e.Activo).HasColumnName("activo");
            entity.Property(e => e.Eliminado).HasColumnName("eliminado");
            entity.Property(e => e.FechaRegistro).HasColumnName("fecha_registro");
            entity.Property(e => e.Nombre)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("nombre");
        });

        modelBuilder.Entity<Transporte>(entity =>
        {
            entity.HasKey(e => e.Idtransporte).HasName("PK_transporte_idtransporte");

            entity.ToTable("transporte");

            entity.Property(e => e.Idtransporte).HasColumnName("idtransporte");
            entity.Property(e => e.Activo).HasColumnName("activo");
            entity.Property(e => e.Eliminado).HasColumnName("eliminado");
            entity.Property(e => e.FechaRegistro).HasColumnName("fecha_registro");
            entity.Property(e => e.Idmarcatransporte).HasColumnName("idmarcatransporte");
            entity.Property(e => e.Idtipotransporte).HasColumnName("idtipotransporte");
            entity.Property(e => e.Placa)
                .HasMaxLength(16)
                .IsUnicode(false)
                .HasColumnName("placa");
        });

        modelBuilder.Entity<TransporteSucursal>(entity =>
        {
            entity.HasKey(e => e.Idtransporteusuario).HasName("PK_transporte_sucursal_idtransporteusuario");

            entity.ToTable("transporte_sucursal");

            entity.Property(e => e.Idtransporteusuario).HasColumnName("idtransporteusuario");
            entity.Property(e => e.Activo).HasColumnName("activo");
            entity.Property(e => e.Eliminado).HasColumnName("eliminado");
            entity.Property(e => e.FechaRegistro).HasColumnName("fecha_registro");
            entity.Property(e => e.Idsucursal).HasColumnName("idsucursal");
            entity.Property(e => e.Idtransporte).HasColumnName("idtransporte");

            entity.HasOne(d => d.IdsucursalNavigation).WithMany(p => p.TransporteSucursals)
                .HasForeignKey(d => d.Idsucursal)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("transporte_sucursal$transporte_sucursal_ibfk_1");

            entity.HasOne(d => d.IdtransporteNavigation).WithMany(p => p.TransporteSucursals)
                .HasForeignKey(d => d.Idtransporte)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("transporte_sucursal$transporte_sucursal_ibfk_2");
        });

        modelBuilder.Entity<TransporteUsuario>(entity =>
        {
            entity.HasKey(e => e.Idtransporteusuario).HasName("PK_transporte_usuario_idtransporteusuario");

            entity.ToTable("transporte_usuario");

            entity.Property(e => e.Idtransporteusuario).HasColumnName("idtransporteusuario");
            entity.Property(e => e.Activo).HasColumnName("activo");
            entity.Property(e => e.Eliminado).HasColumnName("eliminado");
            entity.Property(e => e.FechaRegistro).HasColumnName("fecha_registro");
            entity.Property(e => e.Idtransporte).HasColumnName("idtransporte");
            entity.Property(e => e.Idusuario).HasColumnName("idusuario");

            entity.HasOne(d => d.IdtransporteNavigation).WithMany(p => p.TransporteUsuarios)
                .HasForeignKey(d => d.Idtransporte)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("transporte_usuario$transporte_usuario_ibfk_2");

            entity.HasOne(d => d.IdusuarioNavigation).WithMany(p => p.TransporteUsuarios)
                .HasForeignKey(d => d.Idusuario)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("transporte_usuario$transporte_usuario_ibfk_1");
        });

        modelBuilder.Entity<Usuario>(entity =>
        {
            entity.HasKey(e => e.Idusuario).HasName("PK_usuarios_idusuario");

            entity.ToTable("usuarios");

            entity.Property(e => e.Idusuario).HasColumnName("idusuario");
            entity.Property(e => e.Activo).HasColumnName("activo");
            entity.Property(e => e.Apellidos)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("apellidos");
            entity.Property(e => e.Bloqueado)
                .HasMaxLength(2)
                .IsUnicode(false)
                .HasColumnName("bloqueado");
            entity.Property(e => e.Eliminado).HasColumnName("eliminado");
            entity.Property(e => e.FechaRegistro).HasColumnName("fecha_registro");
            entity.Property(e => e.Idtipousuario).HasColumnName("idtipousuario");
            entity.Property(e => e.IntentosLogin).HasColumnName("intentos_login");
            entity.Property(e => e.Logueado)
                .HasMaxLength(2)
                .IsUnicode(false)
                .HasColumnName("logueado");
            entity.Property(e => e.Nombres)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("nombres");

            entity.HasOne(d => d.IdtipousuarioNavigation).WithMany(p => p.Usuarios)
                .HasForeignKey(d => d.Idtipousuario)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("usuarios$usuarios_ibfk_1");
        });

        modelBuilder.Entity<UsuarioPassword>(entity =>
        {
            entity.HasKey(e => e.Idusuariopassword).HasName("PK_usuario_password_idusuariopassword");

            entity.ToTable("usuario_password");

            entity.Property(e => e.Idusuariopassword).HasColumnName("idusuariopassword");
            entity.Property(e => e.Activo).HasColumnName("activo");
            entity.Property(e => e.Eliminado).HasColumnName("eliminado");
            entity.Property(e => e.FechaCreacion).HasColumnName("fecha_creacion");
            entity.Property(e => e.FechaRegistro).HasColumnName("fecha_registro");
            entity.Property(e => e.FechaVencimiento).HasColumnName("fecha_vencimiento");
            entity.Property(e => e.Idusuario).HasColumnName("idusuario");
            entity.Property(e => e.Pwd)
                .HasMaxLength(255)
                .HasColumnName("pwd");

            entity.HasOne(d => d.IdusuarioNavigation).WithMany(p => p.UsuarioPasswords)
                .HasForeignKey(d => d.Idusuario)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("usuario_password$usuario_password_ibfk_1");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
