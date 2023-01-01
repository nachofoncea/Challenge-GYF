import { Component, OnInit } from '@angular/core';
import { ProductoModel } from '../../models/producto.model';
import { ProductoService } from '../../services/producto.service'

@Component({
  selector: 'app-root',
  templateUrl: './home.component.html',
  styleUrls: []
})
export class HomeComponent implements OnInit {
  
  datos: any;

  constructor(private service: ProductoService) {}

  ngOnInit() {
    this.makeQuery();
  }

  makeQuery() {
    this.service.getAll().subscribe((resp) => {
      this.datos = resp;
      
      });

    }
  }




