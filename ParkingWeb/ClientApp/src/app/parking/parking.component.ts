import { HttpClient, HttpErrorResponse } from '@angular/common/http';
import { Component, Inject, OnInit } from '@angular/core';
import { Router } from '@angular/router';

@Component({
  selector: 'app-parking',
  templateUrl: './parking.component.html',
  styleUrls: ['./parking.component.css'],
})

export class ParkingComponent implements OnInit {
  currentUrl?: string | undefined;
  parkinglist: IParking[] | undefined;
  baseUrl: string | undefined;
  parkinginputs: IParking;


  constructor(private router: Router,
    private client: HttpClient,
    @Inject('BASE_URL') _baseUrl: string) {
    this.parkinglist = [];
    this.baseUrl = _baseUrl;
    this.parkinginputs = { Slot: "", Status: "", VehicleColor: "", VehicleNo: "", VehicleType: "" }
  }

  ngOnInit(): void {
    this.currentUrl = this.router.url;
    this.client.get<IParking[]>(this.baseUrl + "parkingservice").subscribe(result => {
      this.parkinglist = result;
      console.log(JSON.stringify(this.parkinglist));
    });
  }

  postCheckIn(): void {
    const payload = JSON.stringify({
      "vehicleNo": this.parkinginputs.VehicleNo,
      "vehicleType": this.parkinginputs.VehicleType,
      "vehicleColor": this.parkinginputs.VehicleColor,
      "status": "I",
      "slot": this.parkinginputs.Slot
    });
    this.client.post(
      this.baseUrl + "parkingservice/checkin",
      payload, {
      headers: {
        "Content-Type": "application/json"
      }
    }).subscribe(result => {
      console.log(result);
      alert("Check In Vehicle " + this.parkinginputs.VehicleNo + " Success!");
    }, err => { alert(JSON.stringify(err)); });

    this.ClearInputs();
  }

  postCheckOut(): void {
    alert("Check Out Vehicle " + this.parkinginputs.VehicleNo + " Success!");
    this.ClearInputs();
  }



  ClearInputs() {
    this.parkinginputs = { Slot: "", Status: "", VehicleColor: "", VehicleNo: "", VehicleType: "" }
  }

}

interface IParking {
  Id?: number;
  Slot?: string;
  VehicleNo?: string;
  VehicleType?: string;
  VehicleColor?: string;
  Status?: string;
  DateTimeIn?: any;
}

interface IResponseModel {
  Message?: string;
  Success?: boolean;
  Data?: any;
}
