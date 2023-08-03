import { Injectable } from '@angular/core';
import { ActivatedRouteSnapshot, RouterStateSnapshot, UrlTree } from '@angular/router';
import { MessageService } from 'primeng/api';
import { Observable, map } from 'rxjs';
import { AuthorizeService } from 'src/app/features/api-authorization/authorize.service';

@Injectable({
  providedIn: 'root',
})
export class AdminGuard {
  constructor(
    private authorizeService: AuthorizeService,
    private messageService: MessageService) { }

  canActivate(
    route: ActivatedRouteSnapshot,
    state: RouterStateSnapshot): Observable<boolean | UrlTree> | Promise<boolean | UrlTree> | boolean | UrlTree {
    return this.authorizeService.hasRole('Admin').pipe(
      map(hasAdminRole => {
        if (hasAdminRole) {
          return true;
        } else {
          this.messageService.add({ severity: 'error', summary: 'Error', detail: 'Admin role is required for this operation.' });
          return false;
        }
      })
    );
  }

}
