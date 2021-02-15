import { Injectable } from '@angular/core';
import { Observable, of } from 'rxjs';
import { Response } from '../../interfaces/common/response';

@Injectable({
  providedIn: 'root'
})
export class ResponseService {
  private response: Response;

  constructor() { }

  public doResponse(operation = 'operation', hasError: boolean, value: any): Observable<any> {
    if (hasError) {
      if (value.status === 409) {
        const resp: Response = {
          ownHandle: true,
          code: 409,
          message: value.error,
          object: value
        };
        this.response = resp;
      } else {
        const resp: Response = {
          ownHandle: true,
          code: 500,
          message: 'Fatal Error',
          object: value
        };
        this.response = resp;
      }
    } else {
      const resp: Response = {
        ownHandle: true,
        code: 200,
        message: 'OK',
        object: value
      };
      this.response = resp;
    }
    return of(this.response);
  }
}