import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { ProductoService } from '../../services/producto.service'
import SweetAlert from 'sweetalert2'

@Component({
  selector: 'app-root',
  templateUrl: './home.component.html',
  styleUrls: []
})

export class HomeComponent implements OnInit {
  
  datos: any;

constructor(private service: ProductoService,
            private router: Router) {}

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
        title: '¿Borrar el comprobante?',
        text: "",
        icon: 'warning',
        showCancelButton: true,
        confirmButtonText: 'Confirmar',
        cancelButtonText: 'Cancelar',
        reverseButtons: true
      }).then((resp) => {
        if (resp.value) { 
            this.service.DeleteProducto(id)
           .subscribe(this.datos.splice(idx,1)
           );
    }});
    }

  }





