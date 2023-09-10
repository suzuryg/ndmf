﻿using nadena.dev.ndmf;
using nadena.dev.ndmf.fluent;
using nadena.dev.ndmf.runtime.samples;
using nadena.dev.ndmf.sample;
using UnityEngine;

[assembly: ExportsPlugin(typeof(SetViewpointPlugin))]

namespace nadena.dev.ndmf.sample
{
    public class SetViewpointPlugin : Plugin<SetViewpointPlugin>
    {
        public override string QualifiedName => "nadena.dev.av3-build-framework.sample.set-viewpoint";
        protected override void Configure()
        {
            InPhase(BuildPhase.Transforming).Run("Set viewpoint", ctx =>
            {
                var obj = ctx.AvatarRootObject.GetComponentInChildren<SetViewpoint>();
                if (obj != null)
                {
                    ctx.AvatarDescriptor.ViewPosition =
                        Quaternion.Inverse(ctx.AvatarRootTransform.rotation) * (
                            obj.transform.position - ctx.AvatarRootTransform.position);
                }
            });
        }
    }
}
