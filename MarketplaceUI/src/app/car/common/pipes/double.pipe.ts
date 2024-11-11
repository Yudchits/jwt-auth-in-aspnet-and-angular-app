import { Pipe, PipeTransform } from '@angular/core';

@Pipe({
  name: 'double'
})
export class DoublePipe implements PipeTransform {

  transform(value: any, args?: any): string {
    let result: string = value;
    if (Number.isInteger(value)) {
      result = `${value}.0`;
    }
    return result;
  }

}