import { Component, OnInit } from '@angular/core';
import { CategoriaModel } from 'src/models/categoria.model';
import { CategoriaService } from 'src/services/categoria.service';

@Component({
  selector: 'app-add-producto',
  templateUrl: './add-producto.component.html',
  styleUrls: []
})
export class AddProductoComponent implements OnInit {
  data: any;
  model: CategoriaModel= new CategoriaModel();

  constructor(private service: CategoriaService) { }

  ngOnInit(): void {
    this.makeQuery()
  }

  makeQuery() {
    this.service.getAll().subscribe((resp) => {
      this.data = resp;
      
      });
    }
}
