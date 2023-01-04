import { Injectable } from '@angular/core';
import { ProductoModel } from '../models/producto.model';
import { Observable, of} from "rxjs";
import { map, catchError, tap} from "rxjs/operators";
import { HttpClient,HttpHeaders } from "@angular/common/http";
import { environment } from '../environments/environment';

@Injectable({
  providedIn: 'root'
})

export class ProductoService {

  constructor(private httpClient: HttpClient) { }

  httpOptions = {
    headers: new HttpHeaders({ 'Content-Type': 'application/json' })
  };

  getAll(): Observable<any> {
    
    let _url=environment.apiUrl+ "Producto";
    return this.httpClient.get<ProductoModel[]>(_url);
  }
  deleteProducto(id:any) : Observable<void>{

    let _url=environment.apiUrl+ "Producto/" + id;

    let httpdeleteOptions = {
      headers: new HttpHeaders({ 'Content-Type': 'application/json' }),
      body:id
    };

    return this.httpClient.delete<void>(_url, httpdeleteOptions)
                        .pipe(
            
           );
  }

  getByID(id: number){

    let _url=environment.apiUrl + "Producto/";
    return this.httpClient.get(_url + id);

  }
  saveArticulo(producto:ProductoModel): Observable<any> {

    let _url=environment.apiUrl + "Producto";
    return this.httpClient.post<ProductoModel>(_url, producto, this.httpOptions);
               
  }

  Update(producto:ProductoModel): Observable<ProductoModel>{
    
    let _url=environment.apiUrl + "Producto";

    return this.httpClient.put<ProductoModel>(_url, producto);

  }


}