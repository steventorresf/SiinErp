import { HttpClient } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { Observable } from "rxjs";
import { tap, catchError } from "rxjs/operators";
import { Constants } from "src/app/interfaces/common/constants";
import { City } from "src/app/interfaces/general/city";
import { ResponseService } from "../common/response.service";

const apiUrl = Constants.API_ENDPOINT + 'General/api/Cities';
const httpOptions = Constants.HTTP_OPTIONS;

@Injectable({
  providedIn: 'root'
})
export class CityService {

  /**
   * Service constructor
   * @param http Injecting the HttpClient class
   * @param rspSrv ResponseService service injection
   */
  constructor(private http: HttpClient, private rspSrv: ResponseService) { }

  /**
   * Method to get all data of the entity
   */
  getAll(): Observable<Response> {
    return this.http.get<City[]>(`${apiUrl}`)
      .pipe(
        tap(objs => this.rspSrv.doResponse('fetched', false, objs)),
        catchError(err => this.rspSrv.doResponse('err', true, err))
      );
  }

  /**
   * Method to get all data of the entity By State Code
   */
  getByState(id: string): Observable<Response> {
    return this.http.get<City[]>(`${apiUrl}/${id}`)
      .pipe(
        tap(objs => this.rspSrv.doResponse('fetched', false, objs)),
        catchError(err => this.rspSrv.doResponse('err', true, err))
      );
  }

  /**
   * Method to persist the entity
   * @param obj Entity Object
   */
  add(obj: any): Observable<any> {
    return this.http.post<City>(apiUrl, obj, httpOptions).pipe(
      tap((o: any) => this.rspSrv.doResponse('add', false, o)),
      catchError(err => this.rspSrv.doResponse('err', true, err))
    );
  }

  /**
   * Method to merge the entity
   * @param id Entity id
   * @param obj Entity Object
   */
  update(id: string, obj: City): Observable<Response> {
    const url = `${apiUrl}/${id}`;
    return this.http.put(url, obj, httpOptions).pipe(
      tap(obj => this.rspSrv.doResponse('updated', false, obj)),
      catchError(err => this.rspSrv.doResponse('err', true, err))
    );
  }
}