import { Injectable } from '@angular/core';
import { Account, Role } from './account';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class AccountService {

  constructor(private httpClient: HttpClient) { }

  url: string = "api/accounts";

  get(): Observable<Account[]> {
    return this.httpClient.get<Account[]>(this.url);
  }

  delete(id: number): Observable<{}> {
    return this.httpClient.delete(`${this.url}/${id}`);
  }

  create(email: string, password: string, role: Role): Observable<Account> {
    return this.httpClient.post<Account>(this.url, { email, password, role });
  }

  changeRole(id: number, role: number): Observable<Account> {
    return this.httpClient.put<Account>(this.url, { id, role });
  }
}
