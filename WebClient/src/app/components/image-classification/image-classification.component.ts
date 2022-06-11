import { Component, OnInit } from '@angular/core';
import { ApiService } from 'src/app/services/api.service';

@Component({
  selector: 'app-image-classification',
  templateUrl: './image-classification.component.html',
  styleUrls: ['./image-classification.component.scss']
})
export class ImageClassificationComponent implements OnInit {

  type!: string;
  image!: File;
  isFileUploaded = false;

  result: any;

  types = [
    {
      label: 'Plant',
      value: 'Plant'
    },
    {
      label: 'Simpson',
      value: 'Simpson'
    }
  ];

  constructor(private apiService: ApiService) { }

  ngOnInit(): void {
  }

  customUploader(event: any) {
    this.image = event.files[0];
    this.isFileUploaded = true;
  }

  onRemoveFile() {
    this.isFileUploaded = false;
  }

  onSubmit() {
    this.apiService.classifyImage(this.image, this.type).subscribe(r => {
      this.result = r;
    });
  }

}
