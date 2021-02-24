import { HttpClient, HttpParams } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { RandomUser } from './random-user';

@Injectable({ providedIn: 'root' })
export class RandomUserService {
    randomUserUrl = 'https://api.randomuser.me/';

    getUsers(
        pageIndex: number,
        pageSize: number,
        sortField: string | null,
        sortOrder: string | null,
        filters: Array<{ key: string; value: string[] }>
    ): Observable<{ results: RandomUser[] }> {
        let params = new HttpParams()
            .append('page', `${pageIndex}`)
            .append('results', `${pageSize}`)
            .append('sortField', `${sortField}`)
            .append('sortOrder', `${sortOrder}`);
        filters.forEach(filter => {
            filter.value.forEach(value => {
                params = params.append(filter.key, value);
            });
        });
        return this.http.get<{ results: RandomUser[] }>(`${this.randomUserUrl}`, { params });
    }

    constructor(private http: HttpClient) { }
}