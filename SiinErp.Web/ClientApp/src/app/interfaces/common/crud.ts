import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { Constants } from './constants';

export class Crud<T> {
  protected readonly apiUrl = `${this.baseUrl}${this.uriComplement}`;
  constructor(
    protected readonly http: HttpClient,
    protected readonly uriComplement: string,
    protected readonly baseUrl: string = Constants.API_ENDPOINT
  ) {}

  create(body: T): Observable<T> {
    return this.http.post<T>(this.apiUrl, body);
  }

  read(id: any): Observable<T> {
    const url = this.entityUrl(id);
    return this.http.get<T>(url);
  }

  readAll(): Observable<T> {
    return this.http.get<T>(this.apiUrl);
  }

  update(id: any, body: T): Observable<T> {
    const url = this.entityUrl(id);
    return this.http.put<T>(url, body);
  }

  delete(id: any): Observable<T> {
    const url = this.entityUrl(id);
    return this.http.delete<T>(url);
  }

  protected entityUrl(id: any): string {
    return [this.apiUrl, id].join('/');
  }
}