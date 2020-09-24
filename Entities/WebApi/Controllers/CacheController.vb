
Imports System.Web.Http
Imports DAL
Imports Entities.Entities

Namespace Controllers

    <CustomExceptionFilter>
    Public Class CacheController
        Inherits ApiController 
        
        Private ReadOnly _daocache As IDaoCache

        public sub New (daocache As IDaoCache)
            _daocache = daocache
        End sub

        <HttpGet>
        <ActionName("GetCache")>
        public Function GetCache() as CacheResponse 

            dim resp = new CacheResponse()

            dim cache = _daoCache.GetCache()

            resp.DtoCache.Durations = cache.Durations
            resp.DtoCache.ProjectTypes = cache.ProjectTypes
            resp.DtoCache.Resources = cache.Resources
            resp.DtoCache.Statuses = cache.Statuses

            return resp
        End Function
                                         
    End Class
End Namespace