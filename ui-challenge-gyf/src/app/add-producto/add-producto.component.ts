import { HttpParams } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { NgForm } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { CategoriaModel } from 'src/models/categoria.model';
import { ProductoModel } from 'src/models/producto.model';
import { CategoriaService } from 'src/services/categoria.service';
import { ProductoService } from 'src/services/producto.service';

@Component({
  selector: 'app-add-producto',
  templateUrl: './add-producto.component.html',
  styleUrls: []
})

export class AddProductoComponent implements OnInit {

  data: any;
  productoID:string;
  model: CategoriaModel = new CategoriaModel();
  _producto: ProductoModel = new ProductoModel();
  _errors: string[]=[];

  constructor(private categoriaservice: CategoriaService,
              private productoservice: ProductoService,
              private route: ActivatedRoute,
              private router : Router) { }
             
   ngOnInit() {
    this.makeQuery()

    this.productoID = this.route.snapshot.paramMap.get('ProductoID') || '';

        if(this.productoID != "")
            {
              this._producto.ProductoID = parseInt(this.productoID);

              this.productoservice.getByID(this._producto.ProductoID)
              .subscribe( (resp: any) => this._producto=resp );
            }

}

  makeQuery() {
    this.categoriaservice.getAll().subscribe((resp) => {
      this.data = resp;
      });
    }

    save(form:NgForm) {

      if(this.isValid() == true)
      {
        console.log(this._producto.ProductoID)
        if(this._producto.ProductoID == undefined)
        {  
        this.productoservice.saveArticulo(this._producto)
                            .subscribe(resp=> this.router.navigate(["/"]));
        }
        else
        {
        this.productoservice.update(this._producto)
                            .subscribe(resp=> this.router.navigate(["/"]));
        }
    }; 
  };

    isValid()
    
    {
      this._errors=[];
      let isvalid=true;
      if(this._producto.Precio > 1000000)
      {
        this._errors.push("El precio debe ser menor que $1.000.000");
         isvalid=false;
      }
      if(this._producto.Precio <= 0)
      {
        this._errors.push("El precio debe ser mayor que $0");
         isvalid=false;
      }
      if(this._producto.CategoriaID == undefined)
      {
        this._errors.push("Seleccione una categoria");
         isvalid=false;
      }
      return isvalid;
    }

}
