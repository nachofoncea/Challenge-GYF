import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { ProductoService } from '../../services/producto.service'
import SweetAlert from 'sweetalert2'
import { VentaComponent } from '../venta/venta.component';
import { MatDialog } from '@angular/material/dialog';


@Component({
  selector: 'app-root',
  templateUrl: './home.component.html',
  styleUrls: []
})

export class HomeComponent implements OnInit {
  
  datos: any;



constructor(private service: ProductoService,
            private router: Router,
            public dialog: MatDialog) {}


  ngOnInit() {
    this.makeQuery();
  }
  
  navigateAddProducto(){
    this.router.navigate(['/AddProductoComponent'])
  }

  makeQuery() {
    this.service.getAll().subscribe((resp) => {
      this.datos = resp;
      
      });
    }

    deleteProducto(id: number, idx: any) {

      SweetAlert.fire({
        title: '¿Desea borrar el producto?',
        text: "",
        icon: 'warning',
        showCancelButton: true,
        confirmButtonText: 'Confirmar',
        cancelButtonText: 'Cancelar',
        reverseButtons: true
      }).then((resp) => {
        if (resp.value) { 
            this.service.deleteProducto(id)
           .subscribe(this.datos.splice(idx,1)
           );
    }});
    }

    openDialog() {
      this.dialog.open(VentaComponent);
      }

  }



