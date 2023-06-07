import { HttpClient } from '@angular/common/http';
import { Component, inject } from '@angular/core';
import { environment } from '../environments/environment';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.scss'],
})
export class AppComponent {
  http = inject(HttpClient);
  title = 'ng-config-env';
  apiUrl = environment.apiUrl;
  cfg = this.http.get(this.apiUrl + '/settings');
}
