import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Crud } from 'src/app/interfaces/common/crud';
import { Pais } from 'src/app/interfaces/general/pais';

@Injectable({
  providedIn: 'root'
})
export class PaisService extends Crud<Pais> {
  constructor(protected http: HttpClient) {
    super(http, 'General/api/Pais');
  }
}