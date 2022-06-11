import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export class ApiService {

  constructor(private http: HttpClient) { }

  classifyImage(image: File, type: string) {
    const formData = new FormData();
    formData.append("image", image, image.name);

    let endpoint = type == 'Plant' ? "PlantDisease" : "SimpsonsCharacters";

    return this.http.post(`https://localhost:7022/api/${endpoint}Classification`, formData);
  }
}
