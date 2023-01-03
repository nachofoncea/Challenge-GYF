import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { ProductoService } from '../../services/producto.service'

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
  }





