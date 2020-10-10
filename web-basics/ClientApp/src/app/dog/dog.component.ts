import { Component, OnInit } from '@angular/core';
import { Dog } from './dog';
import { DogService } from './dog.service';

export class DogModel {
  constructor(
    public name: string,
    public age: number
  ) { }
}

@Component({
  selector: 'app-dog',
  templateUrl: './dog.component.html',
  styleUrls: ['./dog.component.css']
})
export class DogComponent implements OnInit {

  constructor(
    private dogService: DogService,
  ) { }

  dogs: Dog[];

  name: string;
  age: number;

  ngOnInit() {
    this.dogService.get().subscribe(data => {
      this.dogs = data;
    });
  }

  addDog() {
    this.dogService.send(new DogModel(this.name, this.age))
  }
}
