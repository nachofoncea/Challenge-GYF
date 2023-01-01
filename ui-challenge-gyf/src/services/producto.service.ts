import { Injectable } from '@angular/core';
import { ProductoModel } from '../models/producto.model';
import { Observable } from 'rxjs';
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
}