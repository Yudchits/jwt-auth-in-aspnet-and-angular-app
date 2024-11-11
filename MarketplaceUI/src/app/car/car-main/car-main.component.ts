import { AfterViewInit, ChangeDetectorRef, Component, ElementRef, HostListener, QueryList, ViewChild, ViewChildren } from '@angular/core';
import { CarService } from '../common/services/car.service';
import { Car } from '../common/models/car.model';
import { ImageService } from 'src/app/shared/common/services/image.service';

@Component({
  selector: 'app-car-main',
  templateUrl: './car-main.component.html',
  styleUrls: ['./car-main.component.css']
})
export class CarMainComponent implements AfterViewInit {

  cars: Car[] = [];
  currentIndex: number = 0;

  @ViewChildren('carCards') carCardRefs: QueryList<ElementRef>;
  @ViewChild('cardTitle') cardTitleRef: ElementRef;
  @ViewChild('cardImage') cardImageRef: ElementRef;
  @ViewChild('cardBody') cardBodyRef: ElementRef;

  private currentPhotoWidth: number;
  private currentPhotoHeight: number;
  private ratio: number; 

  constructor(
    private carService: CarService, 
    private changeDetector: ChangeDetectorRef,
    private imageService: ImageService
  ) { }

  ngAfterViewInit(): void {
    this.carService.getAll().subscribe(result => {
      if (result && result.length > 0) {
        this.cars = result;
        this.changeDetector.detectChanges();
        this.initPhotoSize();
      }
    });
  }

  @HostListener('window:resize')
  onWindowResize() {
    this.initPhotoSize();
  }

  private initPhotoSize(): void {
    this.imageService.getImageSize(this.cars[this.currentIndex].photo)
      .subscribe({
        next: (result) => {
          this.ratio = result.width / result.height;

          if (this.ratio > 1) {
            this.currentPhotoWidth = 50;
            this.currentPhotoHeight = this.currentPhotoWidth / this.ratio;
          } else {
            this.currentPhotoHeight = 50;
            this.currentPhotoWidth = this.currentPhotoHeight * this.ratio;
          }
  
          this.resizePhoto();
        }
      })
  }

  private resizePhoto(): void {
    const windowWidth = window.innerWidth;
    const windowHeight = window.innerHeight;

    const xPadding = 20;
    const yPadding = 40;

    const cardTitleHeight = this.cardTitleRef.nativeElement.clientHeight;
    const cardImageMarginTop = 15;
    const cardBodyMarginTop = 15;

    const cardBodyHeight = this.cardBodyRef.nativeElement.clientHeight;

    const widthLimit = windowWidth - xPadding;
    const heightLimit = windowHeight - yPadding - cardTitleHeight - cardImageMarginTop 
      - cardBodyMarginTop - cardBodyHeight;

    while (
      this.currentPhotoWidth < widthLimit 
      && ((this.currentPhotoWidth + 1) / this.ratio < heightLimit)
    ) {
      this.currentPhotoWidth++;
    }

    this.currentPhotoHeight = this.currentPhotoWidth / this.ratio;

    this.cardImageRef.nativeElement.style.width = this.currentPhotoWidth + 'px';
    this.cardImageRef.nativeElement.style.height = this.currentPhotoHeight + 'px';
  }

  onPreviousCardClick(): void {
  }

  onNextCardClick(): void {

  }
}