using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Assignment2.EntityModels;
using Assignment2.Models;

namespace Assignment2.Controllers
{
    public class Manager
    {
        private DataContext ds = new DataContext();

        public IMapper mapper;

        public Manager()
        {

            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Artist, ArtistBaseViewModel>();

                cfg.CreateMap<MediaType, MediaTypeBaseViewModel>();

                cfg.CreateMap<Album, AlbumBaseViewModel>();

                cfg.CreateMap<Track, TrackBaseViewModel>();
                cfg.CreateMap<Track, TrackWithDetailViewModel>();
                cfg.CreateMap<TrackAddViewModel, Track>();

                cfg.CreateMap<Playlist, PlaylistBaseViewModel>();
                cfg.CreateMap<Playlist, PlaylistWithDetailViewModel>();
                //cfg.CreateMap<TrackAddViewModel, PlaylistWithDetailViewModel>();
                cfg.CreateMap<Track, TrackAddViewModel>();
                cfg.CreateMap<PlaylistBaseViewModel, PlaylistEditTracksFormViewModel>();

                cfg.CreateMap<PlaylistWithDetailViewModel, PlaylistEditTracksFormViewModel>();
            });

            mapper = config.CreateMapper();

            ds.Configuration.ProxyCreationEnabled = false;

            ds.Configuration.LazyLoadingEnabled = false;
        }

        /**************************** Album ****************************/
        public IEnumerable<AlbumBaseViewModel> AlbumGetAll()
        {
            return mapper.Map<IEnumerable<Album>, IEnumerable<AlbumBaseViewModel>>(ds.Albums.OrderBy(i => i.Title));
        }

        public AlbumBaseViewModel AlbumGetById(int id)
        {
            var obj = ds.Albums.Find(id);

            return obj == null ? null : mapper.Map<Album, AlbumBaseViewModel>(obj);
        }

        /************************** Media Type **************************/
        public IEnumerable<MediaTypeBaseViewModel> MediaTypeGetAll()
        {
            return mapper.Map<IEnumerable<MediaType>, IEnumerable<MediaTypeBaseViewModel>>(ds.MediaTypes.OrderBy(i => i.Name));
        }

        public MediaTypeBaseViewModel MediaTypeGetById(int id)
        {
            var obj = ds.MediaTypes.Find(id);

            return obj == null ? null : mapper.Map<MediaType, MediaTypeBaseViewModel>(obj);
        }

        /**************************** Artist ****************************/
        public IEnumerable<ArtistBaseViewModel> AritstGetAll()
        {
            return mapper.Map<IEnumerable<Artist>, IEnumerable<ArtistBaseViewModel>>(ds.Artists.OrderBy(i => i.Name));
        }

        /**************************** Track ****************************/
        public IEnumerable<TrackBaseViewModel> TrackGetAll()
        {
            return mapper.Map<IEnumerable<Track>, IEnumerable<TrackBaseViewModel>>(ds.Tracks.OrderBy(i => i.Name));
        }

        public IEnumerable<TrackWithDetailViewModel> TrackGetAllWithDetails()
        {
            var obj = ds.Tracks.Include("Album.Artist").Include("MediaType");

            return mapper.Map<IEnumerable<Track>, IEnumerable<TrackWithDetailViewModel>>(obj.OrderBy(i => i.Name));
        }

        public TrackWithDetailViewModel TrackGetByIdWithDetail(int id)
        {
            var obj = ds.Tracks.Include("Album.Artist").Include("MediaType").SingleOrDefault(i => i.TrackId == id);

            return obj == null ? null : mapper.Map<Track, TrackWithDetailViewModel>(obj);
        }

        public TrackBaseViewModel TrackAdd(TrackAddViewModel newTrack)
        {
            var albumObj = ds.Albums.Find(newTrack.AlbumId);
            var mediaObj = ds.MediaTypes.Find(newTrack.MediaTypeId);

            if (albumObj == null || mediaObj == null)
            {
                return null;
            }
            else
            {
                var addedItem = ds.Tracks.Add(mapper.Map<TrackAddViewModel, Track>(newTrack));
                ds.SaveChanges();

                return addedItem == null ? null : mapper.Map<Track, TrackWithDetailViewModel>(addedItem);
            }
        }

        /************************** Playlist **************************/
        public IEnumerable<PlaylistBaseViewModel> PlaylistGetAll()
        {
            var obj = ds.Playlists.Include("Tracks");

            return mapper.Map<IEnumerable<Playlist>, IEnumerable<PlaylistBaseViewModel>>(obj.OrderBy(i => i.Name));
        }

        public PlaylistWithDetailViewModel PlaylistGetByIdWithDetail(int id)
        {
            var obj = ds.Playlists.Include("Tracks").SingleOrDefault(i => i.PlaylistId == id);
       
            return obj == null ? null : mapper.Map<Playlist, PlaylistWithDetailViewModel>(obj);
        }

        public PlaylistWithDetailViewModel PlaylistEdit (PlaylistEditTracksViewModel playlist)
        {
            var obj = ds.Playlists.Include("Tracks").SingleOrDefault(t => t.PlaylistId == playlist.PlaylistId);
            
            if(obj == null){
               return null;
            }
            else
            {
                obj.Tracks.Clear();
               
                foreach(var item in playlist.TrackIds)
                {
                    var addedObj = ds.Tracks.Find(item);
                    obj.Tracks.Add(addedObj);
                }

                ds.SaveChanges();

                return mapper.Map<Playlist, PlaylistWithDetailViewModel>(obj);
            }
        }
    }
}