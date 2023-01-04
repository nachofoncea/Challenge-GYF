import { Injectable } from '@angular/core';
import { ProductoModel } from '../models/producto.model';
import { Observable, of} from "rxjs";
import { map, catchError, tap} from "rxjs/operators";
import { HttpClient,HttpHeaders } from "@angular/common/http";
import { environment } from '../environments/environment';
import { CategoriaModel } from 'src/models/categoria.model';

@Injectable({
  providedIn: 'root'
})

export class CategoriaService {

  constructor(private httpClient: HttpClient) { }

  httpOptions = {
    headers: new HttpHeaders({ 'Content-Type': 'application/json' })
  };

  getAll(): Observable<any> {
    
    let _url=environment.apiUrl+ "Categoria";
    return this.httpClient.get<CategoriaModel[]>(_url);
  }
}