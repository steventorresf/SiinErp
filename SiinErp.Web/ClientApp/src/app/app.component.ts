import { Component } from '@angular/core';
import { Menu } from './interfaces/common/menu';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.scss']
})
export class AppComponent {

  isCollapsed = true;

  menu: Menu[] = [
    {
      icon: 'setting',
      name: 'General',
      route: '',
      childs: [
        { icon: '', name: 'Paises', route: '/general/paises', childs: [] },
        { icon: '', name: 'Empresas', route: '/general/empresas', childs: [] },
        { icon: '', name: 'Tablas', route: '/general/tablas', childs: [] },
        { icon: '', name: 'Tipos de Documento', route: '/general/tipos/documento', childs: [] },
        { icon: '', name: 'Parametros', route: '/general/parametros', childs: [] },
        { icon: '', name: 'Terceros', route: '/general/terceros', childs: [] },
        { icon: '', name: 'Periodos', route: '/general/periodos', childs: [] },
        { icon: '', name: 'Ciudades', route: '/general/ciudades', childs: [] },
        { icon: '', name: 'Usuarios', route: '/general/usuarios', childs: [] }
      ]
    },
    {
      icon: 'shopping-cart',
      name: 'Compras',
      route: '',
      childs: [
        { icon: '', name: 'Proveedores', route: '/compras/proveedores', childs: [] },
        { icon: '', name: 'Ordenes', route: '/compras/ordenes', childs: [] }
      ]
    },
    {
      icon: 'barcode',
      name: 'Inventario',
      route: '',
      childs: [
        { icon: '', name: 'Articulos', route: '/inventario/articulos', childs: [] },
        { icon: '', name: 'Entradas', route: '/inventario/entradas', childs: [] },
        { icon: '', name: 'Movimientos', route: '/inventario/movimientos', childs: [] }
      ]
    },
    {
      icon: 'fund',
      name: 'Ventas',
      route: '',
      childs: [
        { icon: '', name: 'Clientes', route: '/ventas/clientes', childs: [] },
        { icon: '', name: 'Vendedores', route: '/ventas/vendedores', childs: [] },
        { icon: '', name: 'Lista de Precios', route: '/ventas/lista/precios', childs: [] },
        { icon: '', name: 'Punto de Venta', route: '/ventas/punto/venta', childs: [] },
        { icon: '', name: 'Facturacion', route: '/ventas/facturacion', childs: [] },
        { icon: '', name: 'Caja', route: '/ventas/caja', childs: [] }
      ]
    }
  ];
}
