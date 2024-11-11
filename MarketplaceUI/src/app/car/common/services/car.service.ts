import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Result } from 'src/app/shared/common/helpers/result';
import { environment } from 'src/environments/environment';
import { Car } from '../models/car.model';
import { map } from 'rxjs/operators';

@Injectable({
  providedIn: 'root'
})
export class CarService {

  private apiUrl: string = `${environment.resourceApi}/api`;
  private getAllUrl: string = '/car/getAll';

  constructor(private http: HttpClient) { }

  getAll(): Observable<Car[]> {
    return this.http.get<Result<Car[]>>(this.apiUrl + this.getAllUrl)
      .pipe(
        map((result: Result<Car[]>) => {
          return result.data;
        })
      );
  }
}
