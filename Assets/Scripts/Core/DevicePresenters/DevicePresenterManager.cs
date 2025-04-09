using System;
using System.Collections.Generic;
using R3;

namespace Perelesoq.TestAssignment.Core.DevicePresenters
{
    public sealed class DevicePresenterManager : IDisposable
    {
        private readonly List<DevicePresenter> _presenters = new();

        public void Add(DevicePresenter presenter)
        {
            _presenters.Add(presenter);
            presenter.Disposables = new();
        }

        public void Start()
        {
            foreach (var presenter in _presenters)
            {
                presenter.Start();
            }
        }

        public void Dispose()
        {
            foreach (var presenter in _presenters)
            {
                presenter.Disposables.Dispose();
                presenter.Dispose();
            }
            _presenters.Clear();
        }
    }

    public abstract class DevicePresenter : IDisposable
    {
        public CompositeDisposable Disposables { get; set; }

        public abstract void Start();

        public virtual void Dispose()
        {

        }
    }
}
