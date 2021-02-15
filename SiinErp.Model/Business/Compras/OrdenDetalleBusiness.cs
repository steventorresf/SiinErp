﻿using SiinErp.Model.Abstract.Compras;
using SiinErp.Model.Abstract.General;
using SiinErp.Model.Context;
using SiinErp.Model.Entities.Compras;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SiinErp.Model.Business.Compras
{
    public class OrdenDetalleBusiness : IOrdenDetalleBusiness
    {
        private readonly IErrorBusiness errorBusiness;
        private readonly SiinErpContext context;

        public OrdenDetalleBusiness(IErrorBusiness errorBusiness, SiinErpContext context)
        {
            this.errorBusiness = errorBusiness;
            this.context = context;
        }

        public void Create(OrdenDetalle entity)
        {
            try
            {
                context.OrdenesDetalles.Add(entity);
                context.SaveChanges();
            }
            catch (Exception ex)
            {
                errorBusiness.Create("CreateOrdenCompraDetalle", ex.Message, null);
                throw;
            }
        }

        public List<OrdenDetalle> GetOrdenDetalle(int IdOrden)
        {
            try
            {
                List<OrdenDetalle> Lista = (from det in context.OrdenesDetalles.Where(x => x.IdOrden == IdOrden)
                                            join art in context.Articulos on det.IdArticulo equals art.IdArticulo
                                            select new OrdenDetalle()
                                            {
                                                IdDetalleOrden = det.IdDetalleOrden,
                                                IdOrden = det.IdOrden,
                                                IdArticulo = det.IdArticulo,
                                                Cantidad = det.Cantidad,
                                                Margen = det.Margen,
                                                CantidadEje = det.CantidadEje,
                                                VrUnitario = det.VrUnitario,
                                                VrBruto = det.Cantidad * det.VrUnitario,
                                                PcDscto = det.PcDscto,
                                                PcIva = det.PcIva,
                                                VrNeto = (det.Cantidad * det.VrUnitario) - (det.Cantidad * det.VrUnitario * det.PcDscto / 100) + (det.Cantidad * det.VrUnitario * det.PcIva / 100),
                                                Estado = det.Estado,
                                                FechaLlegada = det.FechaLlegada,
                                                FechaPactada = det.FechaPactada,
                                                Servicio = det.Servicio,
                                                Articulo = art,
                                                CantidadRecibida = 0
                                            }).ToList();
                return Lista;
            }
            catch (Exception ex)
            {
                errorBusiness.Create("GetOrdenCompraDetalle", ex.Message, null);
                throw;
            }
        }

        public void UpdateOrdenDetalle(int IdOrdenDetalle, OrdenDetalle entity)
        {
            try
            {
                OrdenDetalle obDet = context.OrdenesDetalles.Find(IdOrdenDetalle);
                obDet.Cantidad = entity.Cantidad;
                obDet.VrUnitario = entity.VrUnitario;
                obDet.PcDscto = entity.PcDscto;
                obDet.Margen = entity.Margen;
                context.SaveChanges();

                UpdateVrNetoOrden(entity.IdOrden);
            }
            catch (Exception ex)
            {
                errorBusiness.Create("UpdateOrdenCompraDetalle", ex.Message, null);
                throw;
            }
        }

        public void DeleteOrdenDetalle(int IdOrdenDetalle)
        {
            try
            {
                OrdenDetalle entity = context.OrdenesDetalles.Find(IdOrdenDetalle);
                context.OrdenesDetalles.Remove(entity);
                context.SaveChanges();
                UpdateVrNetoOrden(entity.IdOrden);
            }
            catch (Exception ex)
            {
                errorBusiness.Create("DeleteOrdenCompraDetalle", ex.Message, null);
                throw;
            }
        }

        public void UpdateVrNetoOrden(int IdOrden)
        {
            try
            {
                decimal VrBruto = 0;
                decimal VrDscto = 0;
                decimal VrIva = 0;
                decimal VrNeto = 0;
                List<OrdenDetalle> Lista = context.OrdenesDetalles.Where(x => x.IdOrden == IdOrden).ToList();
                foreach (OrdenDetalle det in Lista)
                {
                    VrBruto += det.Cantidad * det.VrUnitario;
                    VrDscto += det.Cantidad * det.VrUnitario * det.PcDscto / 100;
                    VrIva += det.Cantidad * det.VrUnitario * det.PcIva / 100;
                    VrNeto += (det.Cantidad * det.VrUnitario) - (det.Cantidad * det.VrUnitario * det.PcDscto / 100) + (det.Cantidad * det.VrUnitario * det.PcIva / 100);
                }
                Orden entity = context.Ordenes.Find(IdOrden);
                entity.ValorBruto = VrBruto;
                entity.ValorDscto = VrDscto;
                entity.ValorIva = VrIva;
                entity.ValorNeto = VrNeto;
                context.SaveChanges();
            }
            catch (Exception ex)
            {
                errorBusiness.Create("UpdateVrNetoOrden", ex.Message, null);
                throw;
            }
        }
    }
}