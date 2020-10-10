import { Injectable } from '@angular/core';
import { Dog } from './dog';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class DogService {
  constructor(private httpClient: HttpClient) { }

  url: string = "api/dog";

  get(): Observable<Dog[]> {
    return this.httpClient.get<Dog[]>(this.url)
  }
  send(dog) {
    this.httpClient.post(this.url, dog)
  }
}
