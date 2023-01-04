import { Component, OnInit } from '@angular/core';
import { VentaModel } from 'src/models/venta.model';
import { ProductoService } from 'src/services/producto.service';

@Component({
  selector: 'app-venta',
  templateUrl: './venta.component.html',
  styleUrls: []
})
export class VentaComponent implements OnInit {
 
  datos:any
  presupuesto:number;
  _errors: string[]=[];

  model: VentaModel = new VentaModel()

  constructor(private service: ProductoService) { }

  ngOnInit(): void {}


calcular(presupuesto:number){
  if(this.isValid() == true)
  {
  this.service.CalcularVenta(presupuesto).subscribe((resp) => {
    this.datos = resp;
    });
  }
}

isValid()
    
{
  this._errors=[];
  let isvalid=true;
  if(this.model.Presupuesto > 1000000)
  {
    this._errors.push("El precio debe ser menor que $1.000.000");
     isvalid=false;
  }
  if(this.model.Presupuesto <= 0)
  {
    this._errors.push("El precio debe ser mayor que $0");
     isvalid=false;
  }
  return isvalid;
}

}
