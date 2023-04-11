using MA_GameFramework.Utilities;
using MA_GameFramework.Utilities.GameInputAdapters;
using MA_GameFramework.Utilities.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MA_GameFramework.Controllers
{

    /// <summary>
    /// Provide a BaseInputController.
    /// </summary>
    /// <typeparam name="TInput">Type that the InputController handles.</typeparam>
    public abstract class BaseInputController<TInput> : 
        IInputController<TInput>,
        Utilities.Interfaces.IObservable<TInput>
    {

        #region Fields
        protected event EventHandler<GenericEventArgs<TInput>>? _notifyInput;
        #endregion

        #region Properties
        public List<TInput> AcceptedInput { get; protected set; }
        public List<Utilities.Interfaces.IObserver<TInput>> Observers { get; protected set; }
        #endregion

        #region Constructor
        public BaseInputController()
        {
            AcceptedInput = new List<TInput>();
            Observers = new List<Utilities.Interfaces.IObserver<TInput>>();
        }
        #endregion

        #region Methods
        public virtual void AddKey(TInput key)
        {
            if (!AcceptedInput.Contains(key))
                AcceptedInput.Add(key);
        }

        public virtual void AddKeys(params TInput[] keys)
        {
            foreach (var key in keys)
                AddKey(key);
        }

        public virtual bool HandleInput(TInput key)
        {

            if (!AcceptedInput.Contains(key))
                return false;

            NotifyObservers(key);
            return true;
        }

        public virtual void AddObservers(params Utilities.Interfaces.IObserver<TInput>[] observers)
        {
            Observers.AddRange(observers);
            Observers.ForEach(o => _notifyInput += o.Notify);
        }

        public virtual void RemoveObserver(Utilities.Interfaces.IObserver<TInput> observer)
        {
            Observers.Remove(observer);
            _notifyInput -= observer.Notify;
        }

        public virtual void NotifyObservers(TInput args)
        {
            _notifyInput?.Invoke(this, new GenericEventArgs<TInput>(args));
        }
        #endregion

    }

    /// <summary>
    /// Provide a BaseInputController.
    /// </summary>
    /// <typeparam name="TInput">Input that the InputController handles.</typeparam>
    /// <typeparam name="TObservable">Type of observables.</typeparam>
    public abstract class BaseInputController<TInput, TObservable> : 
        IInputController<TInput>,
        Utilities.Interfaces.IObservable<TObservable>
    {

        #region Fields
        protected event EventHandler<GenericEventArgs<TObservable>>? _notifyInput;
        protected IGameInputAdapter<TInput, TObservable> _gameInputAdapter;
        #endregion

        #region Properties
        public List<TInput> AcceptedInput { get; protected set; }

        public List<Utilities.Interfaces.IObserver<TObservable>> Observers { get; protected set; }
        #endregion

        #region Constructor
        public BaseInputController()
        {
            AcceptedInput = new List<TInput>();
            Observers = new List<Utilities.Interfaces.IObserver<TObservable>>();
            _gameInputAdapter = GameInputAdapterFactory.CreateGameInputAdapter<TInput, TObservable>();
        }

        public BaseInputController(IGameInputAdapter<TInput, TObservable> gameInputAdapter)
        {
            _gameInputAdapter = gameInputAdapter;
        }
        #endregion

        #region Methods
        public virtual void AddKey(TInput key)
        {
            if (!AcceptedInput.Contains(key))
                AcceptedInput.Add(key);
        }

        public virtual void AddKeys(params TInput[] keys)
        {
            foreach (var key in keys)
                AddKey(key);
        }

        public virtual bool HandleInput(TInput key)
        {

            if (false)
                return false;

            TObservable? val = _gameInputAdapter.GetMap(key);

            if (val == null)
                return false;

            NotifyObservers(val);
            return true;

        }

        public virtual void AddObservers(params Utilities.Interfaces.IObserver<TObservable>[] observers)
        {
            Observers.AddRange(observers);
            Observers.ForEach(o => _notifyInput += o.Notify);
        }

        public virtual void RemoveObserver(Utilities.Interfaces.IObserver<TObservable> observer)
        {
            Observers.Remove(observer);
            _notifyInput -= observer.Notify;
        }

        public virtual void NotifyObservers(TObservable args)
        {
            _notifyInput?.Invoke(this, new GenericEventArgs<TObservable>(args));
        }
        #endregion

    }

}
