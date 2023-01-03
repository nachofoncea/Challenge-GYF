import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { AddProductoComponent } from './add-producto/add-producto.component';
import { HomeComponent } from './home/home.component';
import { VentaComponent } from './venta/venta.component';

const routes: Routes = [
  { path: '', component: HomeComponent },
  { path:'VentaComponent', component: VentaComponent},
  { path:'addproducto', component: AddProductoComponent},
  { path:'', pathMatch: 'full', redirectTo:'/home'},

];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
