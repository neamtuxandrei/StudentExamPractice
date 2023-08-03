import { Injectable } from '@angular/core';
import { ActivatedRouteSnapshot, RouterStateSnapshot, UrlTree } from '@angular/router';
import { MessageService } from 'primeng/api';
import { Observable, map } from 'rxjs';
import { AuthorizeService } from 'src/app/features/api-authorization/authorize.service';

@Injectable({
  providedIn: 'root'
})
export class StudentGuard {
  constructor(
    private authorizeService: AuthorizeService,
    private messageService: MessageService) { }

  canActivate(
    route: ActivatedRouteSnapshot,
    state: RouterStateSnapshot): Observable<boolean | UrlTree> | Promise<boolean | UrlTree> | boolean | UrlTree {
    return this.authorizeService.hasRole('Student').pipe(
      map(hasStudentRole => {
        if (hasStudentRole) {
          return true;
        } else {
          this.messageService.add({ severity: 'error', summary: 'Error', detail: 'Student role is required for this operation.' });
          return false;
        }
      })
    );
  }

}
