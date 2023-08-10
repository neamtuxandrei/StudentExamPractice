import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { HttpClientModule, HTTP_INTERCEPTORS } from '@angular/common/http';
import { RouterModule } from '@angular/router';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';

import { AppComponent } from './app.component';
import { HomeComponent } from './features/pages/home/home.component';
import { CounterComponent } from './features/pages/counter/counter.component';
import { FetchDataComponent } from './features/pages/fetch-data/fetch-data.component';
import { ApiAuthorizationModule } from 'src/app/features/api-authorization/api-authorization.module';
import { AuthorizeInterceptor } from 'src/app/core/interceptors/authorize.interceptor';
import { SharedModule } from './shared/shared.module';
import { CoreModule } from './core/core.module';
import { FeaturesModule } from './features/features.module';
import { AppRoutingModule } from './app-routing.module';
import { ToastModule } from 'primeng/toast';
import { MessageService } from 'primeng/api';
import { StudentService } from './features/pages/admin/student.service';

@NgModule({
  declarations: [
    AppComponent,
    HomeComponent,
    CounterComponent,
    FetchDataComponent,
  ],
  imports: [
    BrowserModule.withServerTransition({ appId: 'ng-cli-universal' }),
    AppRoutingModule, // import this before child router
    BrowserAnimationsModule,
    HttpClientModule,
    FormsModule,
    ApiAuthorizationModule,
    SharedModule,
    CoreModule,
    FeaturesModule,
    ToastModule,
  ],
  providers: [
    { provide: HTTP_INTERCEPTORS, useClass: AuthorizeInterceptor, multi: true },
    MessageService,
    StudentService
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
