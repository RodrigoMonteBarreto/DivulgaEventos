import { DatePipe } from '@angular/common';
import { Pipe, PipeTransform } from '@angular/core';
import { Constants } from '../util/constants';

@Pipe({
  name: 'DateTimeFormatPipe'
})
export class DateTimeFormatPipePipe extends DatePipe implements PipeTransform {

  transform(value: any, args?: any): any {

    const date = new Date(value);

// Agora você pode usar o pipe DatePipe com o objeto de data

    return super.transform(date, Constants.DATE_TIME_FMT);
  }


}
