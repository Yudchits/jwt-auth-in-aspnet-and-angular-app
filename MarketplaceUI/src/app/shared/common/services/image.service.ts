import { Injectable } from '@angular/core';
import { fromEvent, Observable, throwError } from 'rxjs';
import { catchError, map } from 'rxjs/operators';

export interface ImageSize {
  width: number;
  height: number;
}

@Injectable({
  providedIn: 'root'
})
export class ImageService {

  constructor() { }

  getImageSize(photoUrl: string): Observable<ImageSize> {
    return new Observable<ImageSize>(observer => {
      const image = new Image();
      image.src = photoUrl;

      fromEvent(image, 'load').pipe(
        map(() => ({
          width: image.width,
          height: image.height
        })),
        catchError(error => {
          observer.error(error);
          return throwError(() => new Error('Image failed to load.'));
        })
      ).subscribe({
        next: (size: ImageSize) => {
          observer.next(size);
          observer.complete();
        },
        error: err => observer.error(err)
      });
    });
  }
}
